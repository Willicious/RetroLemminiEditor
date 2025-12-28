using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace NLEditor
{
    /// <summary>
    /// This stored all data of a gadget. Inherits from LevelPiece.
    /// </summary>
    [Serializable]
    class GadgetPiece : LevelPiece
    {
        public GadgetPiece(string key, Point pos)
            : base(key, true, pos)
        {
            IsNoOverwrite = !ObjType.In(C.OBJ.ONE_WAY_WALL, C.OBJ.PAINT, C.OBJ.LEMMING);
            IsOnlyOnTerrain = (ObjType.In(C.OBJ.ONE_WAY_WALL, C.OBJ.PAINT));
            SpecWidth = Utility.EvaluateResizable(0, DefaultWidth, base.Width, MayResizeHoriz());
            SpecHeight = Utility.EvaluateResizable(0, DefaultHeight, base.Height, MayResizeVert());
        }

        public GadgetPiece(string key, Point pos,
                           int rotation,
                           bool isInvert, bool isNoOverwrite, bool isOnlyOnTerrain,
                           int specWidth = -1, int specHeight = -1)
            : base(key, true, pos, rotation, isInvert)
        {
            IsNoOverwrite = isNoOverwrite;
            IsOnlyOnTerrain = isOnlyOnTerrain;
            SpecWidth = Utility.EvaluateResizable(specWidth, DefaultWidth, base.Width, MayResizeHoriz());
            SpecHeight = Utility.EvaluateResizable(specHeight, DefaultHeight, base.Height, MayResizeVert());
        }

        public bool IsNoOverwrite { get; set; }
        public bool IsOnlyOnTerrain { get; set; }

        public override LevelPiece Clone()
        {
            return new GadgetPiece(Key, Pos, Rotation, IsInvert, IsNoOverwrite, IsOnlyOnTerrain,
                                   SpecWidth, SpecHeight);
        }


        /// <summary>
        /// Compares two GadgetPieces for equality.
        /// </summary>
        /// <param name="piece"></param>
        public bool Equals(GadgetPiece piece)
        {
            return base.Equals(piece)
                && this.IsNoOverwrite == piece.IsNoOverwrite
                && this.IsOnlyOnTerrain == piece.IsOnlyOnTerrain
                && this.SpecWidth == piece.SpecWidth
                && this.SpecHeight == piece.SpecHeight;
        }

        /// <summary>
        /// Returns the position of the trigger area.
        /// </summary>
        public Rectangle TriggerRect
        {
            get
            {
                Rectangle trigRect = ImageLibrary.GetTrigger(Key);

                // Adjust to resizing
                if (IsRotatedInPlayer)
                {
                    // When both resized and rotated:
                    // To get the new height value, we add the new "width" increment, and subtract the original object height (which is now the width!)
                    if (ResizeMode == C.Resize.Both || ResizeMode == C.Resize.Vert)
                        trigRect.Height += Width - ImageLibrary.GetHeight(Key);

                    // Vice versa to get the new width value
                    if (ResizeMode == C.Resize.Both || ResizeMode == C.Resize.Horiz)
                        trigRect.Width += Height - ImageLibrary.GetWidth(Key);
                }
                else
                {   // When resized but not rotated:
                    // To get the new width value, we add the new "width" increment, and subtract the original object width
                    if (ResizeMode.In(C.Resize.Both, C.Resize.Horiz))
                        trigRect.Width += Width - ImageLibrary.GetWidth(Key);

                    // Vice versa to get the new height value
                    if (ResizeMode.In(C.Resize.Both, C.Resize.Vert))
                        trigRect.Height += Height - ImageLibrary.GetHeight(Key);
                }

                if (ObjType != C.OBJ.ONE_WAY_WALL) // For all objects except one-way-walls
                {
                    // Rotate the trigger area correctly
                    if (IsRotatedInPlayer)
                    {
                        int origImageHeight = ImageRectangle.Width;
                        trigRect = new Rectangle(origImageHeight - trigRect.Bottom, trigRect.X, trigRect.Height, trigRect.Width);
                    }

                    // Adjust to flipping
                    if (IsFlippedInPlayer && ObjType != C.OBJ.HATCH)
                    {
                        trigRect.X = ImageRectangle.Width - trigRect.Right;
                    }

                    // Adjust to inverting
                    if (IsInvertedInPlayer)
                    {
                        trigRect.Y = ImageRectangle.Height - trigRect.Bottom;
                    }
                }

                // Shift to position relative to level
                trigRect.X += PosX;
                trigRect.Y += PosY;
                return trigRect;
            }
        }

        public override Bitmap Image
        {
            get
            {
                Bitmap image;

                if (ObjType == C.OBJ.HATCH)
                {
                    image = ImageLibrary.GetWindowImageWithDirection(Key, GetRotateFlipType(), GetFrameIndex());
                }
                else
                {
                    image = base.Image;
                }

                if (ResizeMode == C.Resize.None)
                {
                    return image;
                }
                else if (Width < 1 || Height < 1)
                {
                    return new Bitmap(1, 1); // should never happen
                }
                else
                {
                    Rectangle? nineSliceArea = ImageLibrary.GetNineSliceArea(Key, GetRotateFlipType());
                    if (nineSliceArea == null)
                    {
                        return image.PaveArea(new Rectangle(0, 0, Width, Height));
                    }
                    else
                    {
                        return image.NineSliceArea(new Rectangle(0, 0, Width, Height), nineSliceArea.Value);
                    }
                }
            }
        }

        public override int Width => Utility.EvaluateResizable(SpecWidth, DefaultWidth, base.Width, MayResizeHoriz());
        public override int Height => Utility.EvaluateResizable(SpecHeight, DefaultHeight, base.Height, MayResizeVert());

        /// <summary>
        /// Returns the correct frame to load the image.
        /// </summary>
        protected override int GetFrameIndex()
        {
            return base.GetFrameIndex();
        }


        public override bool MayRotate()
        {
            return !(ObjType.In(C.OBJ.HATCH, C.OBJ.LEMMING));
        }

        public override bool MayFlip()
        {
            return true;
        }

        public override bool MayInvert()
        {
            return !(ObjType.In(C.OBJ.HATCH, C.OBJ.LEMMING));
        }

        /// <summary>
        /// Rotates the piece around the center of a specified rectangle, if allowed for this piece.
        /// </summary>
        /// <param name="borderRect"></param>
        public override void RotateInRect(Rectangle borderRect)
        {
            base.RotateInRect(borderRect);

            if (MayRotate())
            {
                // Swap special height and special width;
                int oldSpecWidth = SpecWidth;
                SpecWidth = SpecHeight;
                SpecHeight = oldSpecWidth;
            }
        }

        /// <summary>
        /// Sets the width of resizable objects taking rotation into account.
        /// </summary>
        /// <param name="newWidth"></param>
        public void SetSpecWidth(int newWidth)
        {
            if (MayResizeHoriz())
                SpecWidth = Math.Max(newWidth, 1);
        }

        /// <summary>
        /// Sets the height of resizable objects taking rotation into account.
        /// </summary>
        /// <param name="newHeight"></param>
        public void SetSpecHeight(int newHeight)
        {
            if (MayResizeVert())
                SpecHeight = Math.Max(newHeight, 1);
        }
    }
}
