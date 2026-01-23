using System;
using System.Drawing;
using System.Windows.Forms;

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
            IsNoOverwrite = !ObjType.In(C.OBJ.ONE_WAY_WALL, C.OBJ.PAINT);
            IsOnlyOnTerrain = (ObjType.In(C.OBJ.ONE_WAY_WALL, C.OBJ.PAINT));
            IsInvisible = false;
            IsFake = false;
            IsNegativeSteel = false;

            if (ObjType.In(C.OBJ.STEEL, C.OBJ.RULER))
            {
                SpecWidth = ImageLibrary.GetWidth(Key);
                SpecHeight = ImageLibrary.GetHeight(Key);
            }
        }

        public GadgetPiece(string key, Point pos, int rotation,
                           bool isInvert, bool isNoOverwrite, bool isOnlyOnTerrain,
                           bool isInvisible, bool isFake, bool isNegativeSteel,
                           int specWidth = -1, int specHeight = -1,
                           bool isSpawnLeft = false)
            : base(key, true, pos, rotation, isInvert)
        {
            IsNoOverwrite = isNoOverwrite;
            IsOnlyOnTerrain = isOnlyOnTerrain;
            IsInvisible = isInvisible;
            IsFake = isFake;
            IsNegativeSteel = isNegativeSteel;
            SpecWidth = specWidth;
            SpecHeight = specHeight;
            IsSpawnLeft = isSpawnLeft;
        }

        public bool IsNoOverwrite { get; set; }
        public bool IsOnlyOnTerrain { get; set; }
        public bool IsInvisible { get; set; }
        public bool IsFake { get; set; }
        public bool IsNegativeSteel { get; set; }

        public override LevelPiece Clone()
        {
            return new GadgetPiece(Key, Pos, Rotation, IsInvert, IsNoOverwrite, IsOnlyOnTerrain,
                                   IsInvisible, IsFake, IsNegativeSteel, SpecWidth, SpecHeight);
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
                && this.IsInvisible == piece.IsInvisible
                && this.IsFake == piece.IsFake
                && this.IsNegativeSteel == piece.IsNegativeSteel
                && this.SpecWidth == piece.SpecWidth
                && this.SpecHeight == piece.SpecHeight;
        }

        /// <summary>
        /// Returns the position and dimensions of the trigger area.
        /// </summary>
        public Rectangle TriggerRect
        {
            get
            {
                if (ObjType == C.OBJ.STEEL) // Manual steel triggers are the same size as the area itself
                {
                    return new Rectangle(PosX, PosY, Math.Max(1, SpecWidth), Math.Max(1, SpecHeight));
                }

                if (ObjType == C.OBJ.HATCH)
                {
                    int lemmingHeight = 20;
                    Point offset = TriggerMask.GetTriggerOffset(Key);

                    int lemminiSpawnPointX = PosX + (Width / 2) + 2 + offset.X;
                    int lemminiSpawnPointY = PosY + lemmingHeight + offset.Y;

                    return new Rectangle(lemminiSpawnPointX, lemminiSpawnPointY, 1, 1);
                }

                Rectangle trigRect = ImageLibrary.GetTrigger(Key);

                // Apply rotation / flipping / inverting
                if (ObjType != C.OBJ.ONE_WAY_WALL)
                {
                    if (IsRotatedInPlayer)
                    {
                        int origImageHeight = ImageRectangle.Width;
                        trigRect = new Rectangle(origImageHeight - trigRect.Bottom, trigRect.X, trigRect.Height, trigRect.Width);
                    }
                    if (IsFlippedInPlayer && ObjType != C.OBJ.HATCH)
                        trigRect.X = ImageRectangle.Width - trigRect.Right;
                    if (IsInvertedInPlayer)
                        trigRect.Y = ImageRectangle.Height - trigRect.Bottom;
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
                Bitmap image = base.Image;

                if (ObjType.In(C.OBJ.STEEL, C.OBJ.RULER))
                {
                    int finalWidth = Math.Max(1, SpecWidth);
                    int finalHeight = Math.Max(1, SpecHeight);

                    return image.PaveArea(new Rectangle(0, 0, finalWidth, finalHeight));
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
            if (ObjType == C.OBJ.HATCH)
                return ImageLibrary.GetFrameCount(Key);
            else
                return base.GetFrameIndex();
        }

        /// <summary>
        /// Rotates the piece around the center of a specified rectangle, if allowed for this piece.
        /// </summary>
        /// <param name="borderRect"></param>
        public override void RotateInRect(Rectangle borderRect)
        {
            base.RotateInRect(borderRect);

            // Swap special height and special width;
            int oldSpecWidth = SpecWidth;
            SpecWidth = SpecHeight;
            SpecHeight = oldSpecWidth;
        }

        public override int Width
        {
            get
            {
                if (ObjType.In(C.OBJ.STEEL, C.OBJ.RULER) && SpecWidth > 0)
                    return SpecWidth;

                return base.Width;
            }
        }

        public override int Height
        {
            get
            {
                if (ObjType.In(C.OBJ.STEEL, C.OBJ.RULER) && SpecHeight > 0)
                    return SpecHeight;

                return base.Height;
            }
        }
    }
}
