using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace RLEditor
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
        }

        public GadgetPiece(string key, Point pos,
                           int rotation,
                           bool isInvert, bool isNoOverwrite, bool isOnlyOnTerrain,
                           int specWidth = -1, int specHeight = -1)
            : base(key, true, pos, rotation, isInvert)
        {
            IsNoOverwrite = isNoOverwrite;
            IsOnlyOnTerrain = isOnlyOnTerrain;
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

                if (Width < 1 || Height < 1)
                {
                    return new Bitmap(1, 1); // should never happen
                }
                else
                {
                    return image.PaveArea(new Rectangle(0, 0, Width, Height));
                }
            }
        }

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
    }
}
