using System;
using System.Drawing;

namespace RLEditor
{
    /// <summary>
    /// Abstract class for all pieces.
    /// </summary>
    [Serializable]
    abstract class LevelPiece
    {
        public LevelPiece(string key, bool isObj, Point pos,
                          int rotation = 0, bool isInvert = false)
        {
            this.Key = key;

            this.Name = System.IO.Path.GetFileName(key);
            this.Style = System.IO.Path.GetDirectoryName(key);

            System.Diagnostics.Debug.Assert(ImageLibrary.CreatePieceKey(Style, Name, isObj) == Key, "Style and name of level piece incompatible with key.");

            this.PosX = pos.X;
            this.PosY = pos.Y;

            this.Rotation = rotation;
            this.IsInvert = isInvert;
            this.IsSelected = true;

            this.IsMissing = ImageLibrary.GetIsMissing(Key);
            this.IsDeprecated = ImageLibrary.GetIsDeprecated(ImageLibrary.GetImage(Key), Key, ObjType);
        }

        public int PosX { get; set; }
        public int PosY { get; set; }
        public Point Pos => new Point(PosX, PosY);
        public Rectangle SolidPixelOffsetRect => ImageLibrary.SolidPixelRect(Image, Key, Rotation, IsFlippedInPlayer);
        public virtual int Width => (Rotation % 2 == 0) ? ImageLibrary.GetWidth(Key) : ImageLibrary.GetHeight(Key);
        public virtual int Height => (Rotation % 2 == 0) ? ImageLibrary.GetHeight(Key) : ImageLibrary.GetWidth(Key);
        public virtual int DefaultWidth => (Rotation % 2 == 0) ? ImageLibrary.GetDefaultWidth(Key) : ImageLibrary.GetDefaultHeight(Key);
        public virtual int DefaultHeight => (Rotation % 2 == 0) ? ImageLibrary.GetDefaultHeight(Key) : ImageLibrary.GetDefaultWidth(Key);
        public string Style { get; private set; }
        public string Name { get; private set; }
        public string Key { get; private set; }

        public int SpecWidth { get; set; }
        public int SpecHeight { get; set; }

        // RULE: FIRST ROTATE CLOCKWISE - THEN INVERT
        protected int Rotation { get; private set; }
        protected bool IsInvert { get; private set; }
        public int GetRotation() => Rotation;

        // For writing the save file
        public bool IsRotatedInPlayer => (Rotation % 2 == 1);
        public bool IsInvertedInPlayer => (IsInvert && Rotation % 4 < 2) || (!IsInvert && Rotation % 4 > 1);
        public bool IsFlippedInPlayer => (Rotation % 4 > 1);

        /// <summary>
        /// Get piece image correctly rotated and flipped.
        /// </summary>
        public virtual Bitmap Image => ImageLibrary.GetImage(Key, GetRotateFlipType(), GetFrameIndex());
        public Rectangle ImageRectangle => new Rectangle(PosX, PosY, Width, Height);
        public C.OBJ ObjType => ImageLibrary.GetObjType(Key);
        public bool IsSelected { get; set; }
        public bool IsMissing { get; set; }
        public bool IsDeprecated { get; set; }

        /// <summary>
        /// Returns whether the ImageLibrary can find an image corresponding to this piece.
        /// </summary>
        public bool ExistsImage()
        {
            return ImageLibrary.ExistsKey(Key);
        }

        /// <summary>
        /// Moves the piece in the level some pixels in a given direction.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="step"></param>
        public void Move(C.DIR direction, int step, int gridSize)
        {
            switch (direction)
            {
                case C.DIR.N:
                    PosY = Math.Max(PosY - step, -1000);
                    break;
                case C.DIR.E:
                    PosX = Math.Min(PosX + step, 3400);
                    break;
                case C.DIR.S:
                    PosY = Math.Min(PosY + step, 3400);
                    break;
                case C.DIR.W:
                    PosX = Math.Max(PosX - step, -1000);
                    break;
            }
        }

        /// <summary>
        /// Moves the piece in the level to the target position and rounds it to the grid.
        /// </summary>
        /// <param name="targetPos"></param>
        public void Move(Point targetPos, int gridSize)
        {
            PosX = targetPos.X.RoundToMultiple(gridSize);
            PosY = targetPos.Y.RoundToMultiple(gridSize);
        }

        /// <summary>
        /// Creates a deep copy of the piece.
        /// </summary>
        public abstract LevelPiece Clone();

        /// <summary>
        /// Compares two LevelPieces for equality.
        /// </summary>
        /// <param name="piece"></param>
        public virtual bool Equals(LevelPiece piece)
        {
            return this.PosX == piece.PosX
                && this.PosY == piece.PosY
                && this.Key.Equals(piece.Key)
                && this.Rotation == piece.Rotation
                && this.IsInvert == piece.IsInvert;
        }

        public bool HasSameKey(LevelPiece piece)
        {
            return this.Key.Equals(piece.Key);
        }


        /// <summary>
        /// Determines whether this piece can be rotated.
        /// </summary>
        public abstract bool MayRotate();

        /// <summary>
        /// Determines whether this piece can be flipped.
        /// </summary>
        public abstract bool MayFlip();

        /// <summary>
        /// Determines whether this piece can be inverted.
        /// </summary>
        public abstract bool MayInvert();

        /// <summary>
        /// Rotates the piece around the center of a specified rectangle, if allowed for this piece.
        /// </summary>
        /// <param name="borderRect"></param>
        public virtual void RotateInRect(Rectangle borderRect)
        {
            if (!MayRotate())
                return;

            Rectangle newPieceRect = new Rectangle(PosX, PosY, Width, Height).RotateInRectangle(borderRect);
            PosX = newPieceRect.Left;
            PosY = newPieceRect.Top;
            Rotation = (IsInvert ? Rotation + 3 : ++Rotation) % 4;
        }


        /// <summary>
        /// Inverts the piece wrt. a specified rectangle, if allowed for this piece.
        /// </summary>
        /// <param name="borderRect"></param>
        public virtual void InvertInRect(Rectangle borderRect)
        {
            PosY = borderRect.Top + borderRect.Bottom - PosY - Height;
            if (MayInvert())
                IsInvert = !IsInvert;
        }

        /// <summary>
        /// Flips the piece wrt. a specified rectangle, if allowed for this piece.
        /// </summary>
        /// <param name="borderRect"></param>
        public virtual void FlipInRect(Rectangle borderRect)
        {
            if (ObjType != C.OBJ.HATCH)
            {
                PosX = borderRect.Left + borderRect.Right - PosX - Width;
            }

            if (MayFlip())
            {
                Rotation = (Rotation + 2) % 4;
                IsInvert = !IsInvert;
            }
        }

        /// <summary>
        /// Translates stored piece data to a RotateFlipType that can be applied to images.
        /// </summary>
        protected RotateFlipType GetRotateFlipType()
        {
            switch (Rotation)
            {
                case 0:
                    return IsInvert ? RotateFlipType.RotateNoneFlipY : RotateFlipType.RotateNoneFlipNone;
                case 1:
                    return IsInvert ? RotateFlipType.Rotate90FlipY : RotateFlipType.Rotate90FlipNone;
                case 2:
                    return IsInvert ? RotateFlipType.Rotate180FlipY : RotateFlipType.Rotate180FlipNone;
                case 3:
                    return IsInvert ? RotateFlipType.Rotate270FlipY : RotateFlipType.Rotate270FlipNone;
                default:
                    throw new InvalidOperationException("GetRotateFlipType called with invalid Rotation value " + Rotation.ToString());
            }
        }

        /// <summary>
        /// Returns the correct frame to load the image.
        /// </summary>
        protected virtual int GetFrameIndex()
        {
            if (ObjType == C.OBJ.HATCH)
                return ImageLibrary.GetFrameCount(Key);
            else
                return 0;
        }

        /// <summary>
        /// Returns the rectangle of the solid pixels in world coordinates
        /// </summary>
        public Rectangle GetSolidPixelWorldRect()
        {
            return new Rectangle(
                PosX + SolidPixelOffsetRect.Left,
                PosY + SolidPixelOffsetRect.Top,
                SolidPixelOffsetRect.Width,
                SolidPixelOffsetRect.Height
            );
        }
    }
}

// TODO - Add support for mods

// TODO - Maybe put optional stuff in an "Extras" tab

// TODO - Add "?" button next to Mods, Superlemming and Autosteel
// Clicking opens a simple dialog with explanation
