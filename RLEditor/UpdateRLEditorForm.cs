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
            but_RotatePieces.SetInterval(1000);
            but_InvertPieces.SetInterval(1000);
            but_FlipPieces.SetInterval(1000);
            but_MoveBackOne.SetInterval(150);
            but_MoveFrontOne.SetInterval(150);
            but_PieceLeft.SetInterval(100, MouseButtons.Left);
            but_PieceLeft.SetInterval(30, MouseButtons.Right);
            but_PieceRight.SetInterval(100, MouseButtons.Left);
            but_PieceRight.SetInterval(30, MouseButtons.Right);
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
                    but_PieceRight.StopRepeatAction();
                    but_PieceLeft.StopRepeatAction();
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
        /// <param name="MyForm"></param>
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
        /// <param name="picPiece"></param>
        /// <param name="pieceKey"></param>
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
            List<LevelPiece> selectionList = CurLevel.SelectionList();

            bool piecesSelected = selectionList.Count > 0;

            but_MoveBack.Enabled = piecesSelected;
            but_MoveFront.Enabled = piecesSelected;
            but_MoveBackOne.Enabled = piecesSelected;
            but_MoveFrontOne.Enabled = piecesSelected;

            bool onlyHatchesSelected = selectionList.All(p => p is GadgetPiece gp && gp.ObjType == C.OBJ.HATCH);

            but_FlipSpawnDirection.Visible = piecesSelected && onlyHatchesSelected;

            bool oneWaySelected = selectionList.Any(p => p is GadgetPiece gp && gp.ObjType == C.OBJ.ONE_WAY_WALL);

            but_RotatePieces.Enabled = !oneWaySelected;
            but_InvertPieces.Enabled = !oneWaySelected;
            but_FlipPieces.Enabled = !oneWaySelected;

            bool hasSpecialGadget = selectionList.OfType<GadgetPiece>()
                 .Any(g => g.ObjType.In(C.OBJ.STEEL, C.OBJ.RULER));
            if (hasSpecialGadget)
            {
                check_Pieces_NoOv.Enabled = false; check_Pieces_NoOv.Checked = false;
                check_Pieces_Erase.Enabled = false; check_Pieces_Erase.Checked = false;
                check_Pieces_OneWay.Enabled = false; check_Pieces_OneWay.Checked = false;
                check_Pieces_OnlyOnTerrain.Enabled = false; check_Pieces_OnlyOnTerrain.Checked = false;
                check_Pieces_Invisible.Enabled = false; check_Pieces_Invisible.Checked = false;
                check_Pieces_Fake.Enabled = false; check_Pieces_Fake.Checked = false;
            }

            bool singleSteelSelected = selectionList.Count == 1 && selectionList[0] is GadgetPiece ste && ste.ObjType == C.OBJ.STEEL;
            if (singleSteelSelected)
            {
                var gadget = (GadgetPiece)selectionList[0];

                lblSteelAreaWidth.Visible = true; lblSteelAreaHeight.Visible = true;
                num_SteelAreaWidth.Visible = true; num_SteelAreaHeight.Visible = true;
                num_SteelAreaWidth.Value = Math.Max(1, gadget.SpecWidth);
                num_SteelAreaHeight.Value = Math.Max(1, gadget.SpecHeight);
                check_Pieces_NegativeSteel.Visible = true;
            }
            else
            {
                lblSteelAreaHeight.Visible = false; lblSteelAreaWidth.Visible = false;
                num_SteelAreaHeight.Visible = false; num_SteelAreaWidth.Visible = false;
                check_Pieces_NegativeSteel.Visible = false;
            }

            bool singleRulerSelected = selectionList.Count == 1 && selectionList[0] is GadgetPiece && ((GadgetPiece)selectionList[0]).ObjType == C.OBJ.RULER;
            if (singleRulerSelected)
            {
                var r = (GadgetPiece)selectionList[0];

                if (r.Key.Contains("Custom"))
                {
                    lblRulerWidth.Visible = true; lblRulerHeight.Visible = true;
                    num_RulerWidth.Visible = true; num_RulerHeight.Visible = true;
                    num_RulerWidth.Value = Math.Max(1, r.SpecWidth);
                    num_RulerHeight.Value = Math.Max(1, r.SpecHeight);
                }
                else
                {
                    lblRulerWidth.Visible = false; lblRulerHeight.Visible = false;
                    num_RulerWidth.Visible = false; num_RulerHeight.Visible = false;
                }
            }

            if (hasSpecialGadget || singleSteelSelected || singleRulerSelected)
                return;

            check_Pieces_NoOv.Enabled = selectionList.Count() > 0;
            // Set check-mark correctly, without firing the CheckedChanged event
            check_Pieces_NoOv.CheckedChanged -= check_Pieces_NoOv_CheckedChanged;
            check_Pieces_NoOv.Checked = selectionList.Exists(p => (p is GadgetPiece && (p as GadgetPiece).IsNoOverwrite)
                                                               || (p is TerrainPiece && (p as TerrainPiece).IsNoOverwrite));
            check_Pieces_NoOv.CheckedChanged += check_Pieces_NoOv_CheckedChanged;

            check_Pieces_Erase.Enabled = selectionList.Exists(p => (p is TerrainPiece tp));
            // Set check-mark correctly, without firing the CheckedChanged event
            check_Pieces_Erase.CheckedChanged -= check_Pieces_Erase_CheckedChanged;
            check_Pieces_Erase.Checked = selectionList.Exists(p => p is TerrainPiece && (p as TerrainPiece).IsErase);
            check_Pieces_Erase.CheckedChanged += check_Pieces_Erase_CheckedChanged;

            check_Pieces_OneWay.Enabled = selectionList.Exists(p => (p is TerrainPiece tp) && !tp.IsSteel);
            // Set check-mark correctly, without firing the CheckedChanged event
            check_Pieces_OneWay.CheckedChanged -= check_Pieces_OneWay_CheckedChanged;
            check_Pieces_OneWay.Checked = selectionList.Exists(p => p is TerrainPiece && (p as TerrainPiece).IsOneWay);
            check_Pieces_OneWay.CheckedChanged += check_Pieces_OneWay_CheckedChanged;

            check_Pieces_OnlyOnTerrain.Enabled = selectionList.Exists(p => p is GadgetPiece);
            // Set check-mark correctly, without firing the CheckedChanged event
            check_Pieces_OnlyOnTerrain.CheckedChanged -= check_Pieces_OnlyOnTerrain_CheckedChanged;
            check_Pieces_OnlyOnTerrain.Checked = selectionList.Exists(p => p is GadgetPiece && (p as GadgetPiece).IsOnlyOnTerrain);
            check_Pieces_OnlyOnTerrain.CheckedChanged += check_Pieces_OnlyOnTerrain_CheckedChanged;

            check_Pieces_Invisible.Enabled = selectionList.Count() > 0;
            // Set check-mark correctly, without firing the CheckedChanged event
            check_Pieces_Invisible.CheckedChanged -= check_Pieces_Invisible_CheckedChanged;
            check_Pieces_Invisible.Checked = selectionList.Exists(p => (p is GadgetPiece && (p as GadgetPiece).IsInvisible)
                                                               || (p is TerrainPiece && (p as TerrainPiece).IsInvisible));
            check_Pieces_Invisible.CheckedChanged += check_Pieces_Invisible_CheckedChanged;

            check_Pieces_Fake.Enabled = selectionList.Count() > 0;
            // Set check-mark correctly, without firing the CheckedChanged event
            check_Pieces_Fake.CheckedChanged -= check_Pieces_Fake_CheckedChanged;
            check_Pieces_Fake.Checked = selectionList.Exists(p => (p is GadgetPiece && (p as GadgetPiece).IsFake)
                                                               || (p is TerrainPiece && (p as TerrainPiece).IsFake));
            check_Pieces_Fake.CheckedChanged += check_Pieces_Fake_CheckedChanged;
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
                posLeft = tabLvlProperties.Left - 6;
                posTop = this.Height - height;
                width = this.Width - 12;
                rightButtonOffset = 36;
            }

            panelPieceBrowser.Left = posLeft;
            panelPieceBrowser.Top = posTop;
            panelPieceBrowser.Width = width;
            panelPieceBrowser.Height = height;

            bool showRandom = curSettings.ShowRandomButton;
            but_StyleRandom.Top = 0;
            but_StyleRandom.Left = 5;
            but_StyleRandom.Visible = showRandom ? true : false;
            combo_PieceStyle.Top = 0;
            combo_PieceStyle.Left = showRandom ? but_StyleRandom.Right + 5 : 5;
            combo_PieceStyle.Width = showRandom ? 200 : 265;

            but_PieceTerr.Top = 0;
            but_PieceSteel.Top = 0;
            but_PieceObj.Top = 0;
            but_PieceRulers.Top = 0;

            but_PieceLeft.Top = pieceBrowserTop;
            but_PieceRight.Top = pieceBrowserTop;
            but_PieceRight.Left = panelPieceBrowser.Width - rightButtonOffset;

            but_AddSteelArea.Top = 0;
            but_AddSteelArea.Left = but_PieceRight.Right - 4 - but_AddSteelArea.Width;
        }

        private void UpdateCropButtons()
        {
            bool cropActive = curRenderer.CropTool.Active;

            but_ApplyCrop.Visible = cropActive;
            but_CancelCrop.Visible = cropActive;
            but_CropLevel.Enabled = !cropActive;
            but_CropLevel.Width = cropActive ? but_ApplyCrop.Width : but_CancelCrop.Right - but_CropLevel.Left;
        }

        /// <summary>
        /// Positions pic_Level at the correct place and resizes it accordingly.
        /// </summary>
        private void RepositionPicLevel()
        {
            if (!repositionAfterZooming)
                return;
            
            pic_Level.Left = 264;

            Size newPicLevelSize = new Size(this.Width - 276, this.Height - 178);

            // Check for scroll bars. This method resizes pic_Level accordingly (if necessary).
            newPicLevelSize = CheckEnableLevelScrollbars(newPicLevelSize);

            pic_Level.Size = newPicLevelSize;
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
            Point mousePosPicLevel = pic_Level.PointToClient(MousePosition);

            if (curRenderer.MouseDragAction != C.DragActions.DragNewPiece
                || MouseButtons != MouseButtons.Left)
            {
                // Stop timer and make PicBox invisible
                dragNewPieceTimer.Enabled = false;
                pic_DragNewPiece.Visible = false;
                if (curRenderer.MouseDragAction == C.DragActions.DragNewPiece)
                {
                    curRenderer.DeleteDraggingVars();
                }
            }
            else if (curRenderer.IsPointInLevelArea(mousePosPicLevel))
            {
                // Display the piece via the renderer in the level
                pic_DragNewPiece.Visible = false;

                curRenderer.MouseCurPos = mousePosPicLevel;
                pic_Level.Image = curRenderer.CombineLayers(dragNewPieceKey);
            }
            else
            {
                // Display the piece via the picture box.
                if (!pic_DragNewPiece.Visible)
                {
                    dragNewPieceTimer.Interval = 50;
                    pic_DragNewPiece.BringToFront();
                    pic_DragNewPiece.Visible = true;
                    pic_Level.Image = curRenderer.CombineLayers();
                }
                // Reposition the PicBox
                int newPosX = mousePos.X - pic_DragNewPiece.Width / 2;
                int newPosY = mousePos.Y - pic_DragNewPiece.Height / 2;
                pic_DragNewPiece.Location = new Point(newPosX, newPosY);
            }
        }
    }
}
