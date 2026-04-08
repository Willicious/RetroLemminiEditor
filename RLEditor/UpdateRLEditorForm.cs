using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static RLEditor.Settings;

namespace RLEditor
{
    /// <summary>
    /// Main Form: This part defines the methods updating the form members
    /// </summary>
    partial class RLEditForm
    {
        private int pieceBrowserTop = 26;

        /// <summary>
        /// Initializes the intervals for all repeat buttons.
        /// </summary>
        private void SetRepeatButtonIntervals()
        {
            btnRotate.SetInterval(1000);
            btnInvert.SetInterval(1000);
            btnFlip.SetInterval(1000);
            btnDrawSooner.SetInterval(150);
            btnDrawLater.SetInterval(150);
            btnPieceLeft.SetInterval(100, MouseButtons.Left);
            btnPieceLeft.SetInterval(30, MouseButtons.Right);
            btnPieceRight.SetInterval(100, MouseButtons.Left);
            btnPieceRight.SetInterval(30, MouseButtons.Right);
        }

        /// <summary>
        /// Displays the correct piece images for the piece selection.
        /// </summary>
        public void LoadPiecesIntoPictureBox()
        {
            if (pieceCurStyle == null)
            {
                ClearPiecesPictureBox();
                return;
            }

            // Get correct list of piece names
            List<string> pieceKeys;

            switch (pieceDoDisplayKind)
            {
                case C.SelectPieceType.Terrain:
                    pieceKeys = pieceCurStyle?.TerrainKeys;
                    break;
                case C.SelectPieceType.Steel:
                    pieceKeys = pieceCurStyle?.SteelKeys;
                    break;
                case C.SelectPieceType.Objects:
                    pieceKeys = pieceCurStyle?.ObjectKeys;
                    break;
                case C.SelectPieceType.Rulers:
                    pieceKeys = new List<string>(ImageLibrary.RulerKeys);
                    break;
                default:
                    throw new ArgumentException();
            }

            if (pieceKeys == null || pieceKeys.Count == 0)
            {
                ClearPiecesPictureBox();
                return;
            }

            // load correct pictures
            for (int i = 0; i < picPieceList.Count; i++)
            {
                string pieceKey = pieceKeys[(pieceStartIndex + i) % pieceKeys.Count];
                if (!ImageLibrary.IsImageLoadable(pieceKey))
                {
                    // Make sure to stop the repeat-buttons from firing again.
                    btnPieceRight.StopRepeatAction();
                    btnPieceLeft.StopRepeatAction();
                }

                int frameIndex = ImageLibrary.GetObjType(pieceKey) == C.OBJ.HATCH ? ImageLibrary.GetFrameCount(pieceKey) : 0;
                Bitmap pieceImage;

                bool preferObjectName = curSettings.PreferObjectName;

                if (curSettings.CurrentPieceBrowserMode == PieceBrowserMode.ShowDescriptions)
                {
                    if (preferObjectName)
                        pieceImage = ImageLibrary.GetImageWithName(pieceKey, frameIndex);
                    else
                        pieceImage = ImageLibrary.GetImageWithDescription(pieceKey, frameIndex);
                }
                else if (curSettings.CurrentPieceBrowserMode == PieceBrowserMode.ShowData)
                {
                    if (preferObjectName)
                        pieceImage = ImageLibrary.GetImageWithNameAndData(pieceKey, frameIndex);
                    else
                        pieceImage = ImageLibrary.GetImageWithDescriptionAndData(pieceKey, frameIndex);
                }
                else
                    pieceImage = ImageLibrary.GetImage(pieceKey, RotateFlipType.RotateNoneFlipNone, frameIndex);

                picPieceList[i].Image = pieceImage;
                SetToolTipsForPicPiece(picPieceList[i], pieceKey);
            }

            return;
        }

        /// <summary>
        /// Clears all piece selection PictureBoxes.
        /// </summary>
        private void ClearPiecesPictureBox()
        {
            picPieceList.ForEach(pic =>
                {
                    pic.Image = null;
                    SetToolTipsForPicPiece(pic, null);
                });
        }

        /// <summary>
        /// Sets the correct tool tips for piece selection picture boxes.
        /// </summary>
        private void SetToolTipsForPicPiece(PictureBox picPiece, string pieceKey)
        {
            string toolTipText = "unknown";
            C.OBJ pieceObjType = (pieceKey == null) ? C.OBJ.NULL : ImageLibrary.GetObjType(pieceKey);
            if (C.ObjectDescriptions.ContainsKey(pieceObjType))
            {
                toolTipText = C.ObjectDescriptions[pieceObjType];
            }
            if (pieceKey != null && ImageLibrary.GetWidth(pieceKey) > 0 && ImageLibrary.GetHeight(pieceKey) > 0)
            {
                toolTipText += $" ({ImageLibrary.GetWidth(pieceKey)} x {ImageLibrary.GetHeight(pieceKey)})";
            }

            toolTipPieces.SetToolTip(picPiece, toolTipText);
        }

        /// <summary>
        /// Updates the background color of the main level image and the piece selection according to the current main style.
        /// </summary>
        private void UpdateBackgroundColor()
        {
            if (CurLevel.MainStyle == null)
                return;
            Color backColor = CurLevel.MainStyle?.GetColor(C.StyleColor.BACKGROUND) ?? C.RLColors[C.RLColor.BackDefault];

            picPieceList.ForEach(pic => pic.BackColor = backColor);
            curRenderer?.CreateBackgroundLayer();
        }

        /// <summary>
        /// Enables actionable commands for selected pieces and sets checkbox checks correctly.
        /// </summary>
        private void UpdateFlagsForPieceActions()
        {
            bool levelHasPieces = CurLevel.TerrainList.Count > 0 || CurLevel.GadgetList.Count > 0;

            btnShowPiecesList.Enabled = levelHasPieces;
            openPiecesListToolStripMenuItem.Enabled = levelHasPieces;

            List<LevelPiece> selectionList = CurLevel.SelectionList();
            bool piecesSelected = selectionList.Count > 0;

            btnDrawFirst.Enabled = piecesSelected;
            btnDrawLast.Enabled = piecesSelected;
            btnDrawSooner.Enabled = piecesSelected;
            btnDrawLater.Enabled = piecesSelected;

            bool onlyHatchesSelected = selectionList.All(p => p is GadgetPiece gp && gp.ObjType == C.OBJ.HATCH);

            btnFlipSpawnDirection.Visible = piecesSelected && onlyHatchesSelected;

            bool oneWaySelected = selectionList.Any(p => p is GadgetPiece gp && gp.ObjType == C.OBJ.ONE_WAY_WALL);

            btnRotate.Enabled = !oneWaySelected;
            btnInvert.Enabled = !oneWaySelected;
            btnFlip.Enabled = !oneWaySelected;

            bool hasSpecialGadget = selectionList.OfType<GadgetPiece>()
                 .Any(g => g.ObjType.In(C.OBJ.STEEL, C.OBJ.RULER));
            if (hasSpecialGadget)
            {
                checkNoOverwrite.Enabled = false; checkNoOverwrite.Checked = false;
                checkErase.Enabled = false; checkErase.Checked = false;
                checkAllowOneWay.Enabled = false; checkAllowOneWay.Checked = false;
                checkOnlyOnTerrain.Enabled = false; checkOnlyOnTerrain.Checked = false;
                checkInvisible.Enabled = false; checkInvisible.Checked = false;
                checkFake.Enabled = false; checkFake.Checked = false;
            }

            bool singleSteelSelected = selectionList.Count == 1 && selectionList[0] is GadgetPiece ste && ste.ObjType == C.OBJ.STEEL;
            if (singleSteelSelected)
            {
                var gadget = (GadgetPiece)selectionList[0];

                lblSteelAreaWidth.Visible = true; lblSteelAreaHeight.Visible = true;
                numSteelAreaWidth.Visible = true; numSteelAreaHeight.Visible = true;
                numSteelAreaWidth.Value = Math.Max(1, gadget.SpecWidth);
                numSteelAreaHeight.Value = Math.Max(1, gadget.SpecHeight);
                checkNegativeSteel.Visible = true;
            }
            else
            {
                lblSteelAreaHeight.Visible = false; lblSteelAreaWidth.Visible = false;
                numSteelAreaHeight.Visible = false; numSteelAreaWidth.Visible = false;
                checkNegativeSteel.Visible = false;
            }

            bool singleRulerSelected = selectionList.Count == 1 && selectionList[0] is GadgetPiece && ((GadgetPiece)selectionList[0]).ObjType == C.OBJ.RULER;
            if (singleRulerSelected)
            {
                var r = (GadgetPiece)selectionList[0];

                if (r.Key.Contains("Custom"))
                {
                    lblRulerWidth.Visible = true; lblRulerHeight.Visible = true;
                    numRulerWidth.Visible = true; numRulerHeight.Visible = true;
                    numRulerWidth.Value = Math.Max(1, r.SpecWidth);
                    numRulerHeight.Value = Math.Max(1, r.SpecHeight);
                }
                else
                {
                    lblRulerWidth.Visible = false; lblRulerHeight.Visible = false;
                    numRulerWidth.Visible = false; numRulerHeight.Visible = false;
                }
            }

            if (hasSpecialGadget || singleSteelSelected || singleRulerSelected)
                return;

            checkNoOverwrite.Enabled = selectionList.Count() > 0;
            // Set check-mark correctly, without firing the CheckedChanged event
            checkNoOverwrite.CheckedChanged -= check_Pieces_NoOv_CheckedChanged;
            checkNoOverwrite.Checked = selectionList.Exists(p => (p is GadgetPiece && (p as GadgetPiece).IsNoOverwrite)
                                                               || (p is TerrainPiece && (p as TerrainPiece).IsNoOverwrite));
            checkNoOverwrite.CheckedChanged += check_Pieces_NoOv_CheckedChanged;

            checkErase.Enabled = selectionList.Exists(p => (p is TerrainPiece tp));
            // Set check-mark correctly, without firing the CheckedChanged event
            checkErase.CheckedChanged -= check_Pieces_Erase_CheckedChanged;
            checkErase.Checked = selectionList.Exists(p => p is TerrainPiece && (p as TerrainPiece).IsErase);
            checkErase.CheckedChanged += check_Pieces_Erase_CheckedChanged;

            checkAllowOneWay.Enabled = selectionList.Exists(p => (p is TerrainPiece tp) && !tp.IsSteel);
            // Set check-mark correctly, without firing the CheckedChanged event
            checkAllowOneWay.CheckedChanged -= check_Pieces_OneWay_CheckedChanged;
            checkAllowOneWay.Checked = selectionList.Exists(p => p is TerrainPiece && (p as TerrainPiece).IsOneWay);
            checkAllowOneWay.CheckedChanged += check_Pieces_OneWay_CheckedChanged;

            checkOnlyOnTerrain.Enabled = selectionList.Exists(p => p is GadgetPiece);
            // Set check-mark correctly, without firing the CheckedChanged event
            checkOnlyOnTerrain.CheckedChanged -= check_Pieces_OnlyOnTerrain_CheckedChanged;
            checkOnlyOnTerrain.Checked = selectionList.Exists(p => p is GadgetPiece && (p as GadgetPiece).IsOnlyOnTerrain);
            checkOnlyOnTerrain.CheckedChanged += check_Pieces_OnlyOnTerrain_CheckedChanged;

            checkInvisible.Enabled = selectionList.Count() > 0;
            // Set check-mark correctly, without firing the CheckedChanged event
            checkInvisible.CheckedChanged -= check_Pieces_Invisible_CheckedChanged;
            checkInvisible.Checked = selectionList.Exists(p => (p is GadgetPiece && (p as GadgetPiece).IsInvisible)
                                                               || (p is TerrainPiece && (p as TerrainPiece).IsInvisible));
            checkInvisible.CheckedChanged += check_Pieces_Invisible_CheckedChanged;

            checkFake.Enabled = selectionList.Count() > 0;
            // Set check-mark correctly, without firing the CheckedChanged event
            checkFake.CheckedChanged -= check_Pieces_Fake_CheckedChanged;
            checkFake.Checked = selectionList.Exists(p => (p is GadgetPiece && (p as GadgetPiece).IsFake)
                                                               || (p is TerrainPiece && (p as TerrainPiece).IsFake));
            checkFake.CheckedChanged += check_Pieces_Fake_CheckedChanged;
        }

        /// <summary>
        /// Repositions the controls after resizing the main form.
        /// </summary>
        public void MoveControlsOnFormResize()
        {
            scrollPicLevelHoriz.Top = this.Height - 178;
            scrollPicLevelVert.Left = this.Width - 30;

            RepositionPicLevel();

            foreach (TabControl tabControl in this.Controls.OfType<TabControl>())
            {
                tabControl.Height = this.Height - 178;
            }

            bool pieceBrowserIsWindowed = pieceBrowserWindow != null;
            int width = pieceBrowserWindow != null ? pieceBrowserWindow.Width : this.Width;

            btnLoadStyle.Top = tabPieces.Height - btnLoadStyle.Height;

            lblUpdatingLPC.Left = this.Width - lblUpdatingLPC.Width - 40;

            RepositionPieceBrowser(pieceBrowserIsWindowed, width);
            RepositionPicPieces(pieceBrowserIsWindowed, width);
        }

        /// <summary>
        /// Adds and repositions Piece Browser images based on form width
        /// </summary>
        public void RepositionPicPieces(bool windowed, int width)
        {
            bool updateImages = MovePicPiecesOnResize(windowed, width);
            if (updateImages)
            {
                UpdateBackgroundColor();
                LoadPiecesIntoPictureBox();
            }
        }

        /// <summary>
        /// Positions panelPieceBrowser at the correct place on the main form
        /// </summary>
        public void RepositionPieceBrowser(bool isWindowed, int windowWidth = 0)
        {
            int posLeft = 0;
            int posTop = 0;
            int width = 0;
            int height = 148;
            int rightButtonOffset = 0;
            
            if (isWindowed)
            {
                width = windowWidth;
                rightButtonOffset = 50;
            }
            else
            {
                posLeft = tabProperties.Left - 6;
                posTop = this.Height - height;
                width = this.Width - 12;
                rightButtonOffset = 36;
            }

            panelPieceBrowser.Left = posLeft;
            panelPieceBrowser.Top = posTop;
            panelPieceBrowser.Width = width;
            panelPieceBrowser.Height = height;

            bool showRandom = curSettings.ShowRandomButton;
            btnStyleRandom.Top = 0;
            btnStyleRandom.Left = 5;
            btnStyleRandom.Visible = showRandom ? true : false;
            comboPieceStyle.Top = 0;
            comboPieceStyle.Left = showRandom ? btnStyleRandom.Right + 5 : 5;
            comboPieceStyle.Width = showRandom ? 190 : 265;

            btnTerrain.Top = 0;
            btnSteel.Top = 0;
            btnObjects.Top = 0;
            btnRulers.Top = 0;

            btnPieceLeft.Top = pieceBrowserTop;
            btnPieceRight.Top = pieceBrowserTop;
            btnPieceRight.Left = panelPieceBrowser.Width - rightButtonOffset;

            btnAddSteelArea.Top = 0;
            btnAddSteelArea.Left = btnPieceRight.Right - 4 - btnAddSteelArea.Width;
        }

        private void UpdateCropButtons()
        {
            bool cropActive = curRenderer.CropTool.Active;

            btnApplyCrop.Visible = cropActive;
            btnCancelCrop.Visible = cropActive;
            btnCropLevel.Enabled = !cropActive;
            btnCropLevel.Width = cropActive ? btnApplyCrop.Width : btnCancelCrop.Right - btnCropLevel.Left;
        }

        /// <summary>
        /// Positions pic_Level at the correct place and resizes it accordingly.
        /// </summary>
        private void RepositionPicLevel()
        {
            if (!repositionAfterZooming)
                return;
            
            picLevel.Left = 264;

            Size newPicLevelSize = new Size(this.Width - 276, this.Height - 178);

            // Check for scroll bars. This method resizes pic_Level accordingly (if necessary).
            newPicLevelSize = CheckEnableLevelScrollbars(newPicLevelSize);

            picLevel.Size = newPicLevelSize;
            curRenderer.EnsureScreenPosInLevel();
        }

        /// <summary>
        /// Checks whether the level fits into the picLevel and enables scrollbars if necessary.
        /// <para> Warning: Always call RepositionPicLevel() instead of this method! </para>
        /// </summary>
        private Size CheckEnableLevelScrollbars(Size newPicBoxSize)
        {
            Rectangle displayedLevelRect = curRenderer.GetLevelBmpRect(newPicBoxSize);
            bool displayScrollHoriz = false;
            bool displayScrollVert = false;

            displayScrollHoriz = (displayedLevelRect.Width + 1 < CurLevel.Width);
            displayScrollVert = (displayedLevelRect.Height + 1 < CurLevel.Height);

            if (displayScrollHoriz)
                newPicBoxSize.Height -= 16;
            if (displayScrollVert)
                newPicBoxSize.Width -= 16;

            // Check whether shrinking the level size made other scrollbar necessary, too
            if (displayScrollHoriz ^ displayScrollVert)
            {
                displayedLevelRect = curRenderer.GetLevelBmpRect(newPicBoxSize);
                if (!displayScrollHoriz && displayedLevelRect.Width + 1 < CurLevel.Width)
                {
                    displayScrollHoriz = true;
                    newPicBoxSize.Height -= 16;
                }
                if (!displayScrollVert && displayedLevelRect.Height + 1 < CurLevel.Height)
                {
                    displayScrollVert = true;
                    newPicBoxSize.Width -= 16;
                }
            }

            // Update displayed level area
            displayedLevelRect = curRenderer.GetLevelBmpRect(newPicBoxSize);

            // Set scrollPicLevelHoriz
            if (displayScrollHoriz)
            {
                int maxValue = CurLevel.Width + (Renderer.AllowedGrayBorder + 18) - displayedLevelRect.Width + 1;
                scrollPicLevelHoriz.Minimum = -Renderer.AllowedGrayBorder;
                scrollPicLevelHoriz.Maximum = maxValue;
                scrollPicLevelHoriz.SmallChange = 8;
                scrollPicLevelHoriz.LargeChange = 16;
                scrollPicLevelHoriz.Value = Math.Max(Math.Min(displayedLevelRect.Left, maxValue - 1), -Renderer.AllowedGrayBorder);
            }
            scrollPicLevelHoriz.Enabled = displayScrollHoriz;
            scrollPicLevelHoriz.Visible = displayScrollHoriz;
            curRenderer.ScrollHorizActive = displayScrollHoriz;

            // Set scrollPicLevelVert
            if (displayScrollVert)
            {
                int maxValue = CurLevel.Height + (Renderer.AllowedGrayBorder + 8) - displayedLevelRect.Height + 1;
                scrollPicLevelVert.Minimum = -Renderer.AllowedGrayBorder;
                scrollPicLevelVert.Maximum = maxValue;
                scrollPicLevelVert.SmallChange = 4;
                scrollPicLevelVert.LargeChange = 8;
                scrollPicLevelVert.Value = Math.Max(Math.Min(displayedLevelRect.Top, maxValue - 1), -Renderer.AllowedGrayBorder);
            }
            scrollPicLevelVert.Enabled = displayScrollVert;
            scrollPicLevelVert.Visible = displayScrollVert;
            curRenderer.ScrollVertActive = displayScrollVert;

            // Finally resize scrollbars correctly
            if (scrollPicLevelHoriz.Enabled)
                scrollPicLevelVert.Height = newPicBoxSize.Height + 2;
            else 
                scrollPicLevelVert.Height = newPicBoxSize.Height - 2;

            if (scrollPicLevelVert.Enabled)
                scrollPicLevelHoriz.Width = newPicBoxSize.Width - 8;
            else
                scrollPicLevelHoriz.Width = newPicBoxSize.Width - 4;
                
            scrollPicLevelHoriz.Left = 268;
            scrollPicLevelVert.Left = scrollPicLevelVert.Parent.ClientRectangle.Width - scrollPicLevelVert.Width;

            return newPicBoxSize;
        }

        /// <summary>
        /// Sets the scrollbar values for the editor screen position correctly.
        /// </summary>
        private void UpdateScrollBarValues()
        {
            if (scrollPicLevelHoriz.Enabled)
            {
                scrollPicLevelHoriz.Value = Math.Max(Math.Min(curRenderer.ScreenPosX, scrollPicLevelHoriz.Maximum - 1), scrollPicLevelHoriz.Minimum);
            }
            if (scrollPicLevelVert.Enabled)
            {
                scrollPicLevelVert.Value = Math.Max(Math.Min(curRenderer.ScreenPosY, scrollPicLevelVert.Maximum - 1), scrollPicLevelVert.Minimum);
            }
        }


        /// <summary>
        /// Moves the picture boxes to select new pieces to the correct position.
        /// </summary>
        private bool MovePicPiecesOnResize(bool windowed, int width)
        {
            int posTop = pieceBrowserTop;
            if (windowed) posTop = 26; // For Piece Browser window
            picPieceList.ForEach(pic => pic.Top = posTop);

            int numPicPieces = (width - 170) / 90 + 1;

            while (picPieceList.Count > numPicPieces)
            {
                PictureBox oldPicPieces = picPieceList[picPieceList.Count - 1];
                picPieceList.Remove(oldPicPieces);
                this.Controls.Remove(oldPicPieces);
                oldPicPieces.Dispose();
            }

            bool needUpdatePicPieceImages = (picPieceList.Count < numPicPieces);
            while (picPieceList.Count < numPicPieces)
            {
                picPieceList.Add(CreatePicPiece());
            }

            for (int picPieceIndex = 0; picPieceIndex < numPicPieces; picPieceIndex++)
            {
                picPieceList[picPieceIndex].Left = 36 + picPieceIndex * (width - 170) / (numPicPieces - 1);
            }

            return needUpdatePicPieceImages;
        }

        /// <summary>
        /// Creates a new picture box for selecting new pieces.
        /// </summary>
        private PictureBox CreatePicPiece()
        {
            PictureBox picPiece = new PictureBox();
            picPiece.Size = C.PicPieceSize;
            picPiece.Top = pieceBrowserTop;
            picPiece.BorderStyle = BorderStyle.Fixed3D;
            picPiece.SizeMode = PictureBoxSizeMode.CenterImage;

            picPiece.Click += new EventHandler(picPieces_Click);
            picPiece.MouseDown += new MouseEventHandler(picPieces_MouseDown);
            picPiece.MouseUp += new MouseEventHandler(pic_Level_MouseUp);

            panelPieceBrowser.Controls.Add(picPiece);

            return picPiece;
        }

        /// <summary>
        /// Updates the dragNewPiecePicBox.
        /// </summary>
        private void UpdateNewPiecePicBox()
        {
            Point mousePos = PointToClient(MousePosition);
            Point mousePosPicLevel = picLevel.PointToClient(MousePosition);

            if (curRenderer.MouseDragAction != C.DragActions.DragNewPiece
                || MouseButtons != MouseButtons.Left)
            {
                // Stop timer and make PicBox invisible
                dragNewPieceTimer.Enabled = false;
                picDragNewPiece.Visible = false;
                if (curRenderer.MouseDragAction == C.DragActions.DragNewPiece)
                {
                    curRenderer.DeleteDraggingVars();
                }
            }
            else if (curRenderer.IsPointInLevelArea(mousePosPicLevel))
            {
                // Display the piece via the renderer in the level
                picDragNewPiece.Visible = false;

                curRenderer.MouseCurPos = mousePosPicLevel;
                picLevel.Image = curRenderer.CombineLayers(dragNewPieceKey);
            }
            else
            {
                // Display the piece via the picture box.
                if (!picDragNewPiece.Visible)
                {
                    dragNewPieceTimer.Interval = 50;
                    picDragNewPiece.BringToFront();
                    picDragNewPiece.Visible = true;
                    picLevel.Image = curRenderer.CombineLayers();
                }
                // Reposition the PicBox
                int newPosX = mousePos.X - picDragNewPiece.Width / 2;
                int newPosY = mousePos.Y - picDragNewPiece.Height / 2;
                picDragNewPiece.Location = new Point(newPosX, newPosY);
            }
        }
    }
}
