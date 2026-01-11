using System;
using System.Drawing;

namespace RLEditor
{
    /// <summary>
    /// This stored all data of a terrain piece. Inherits from LevelPiece.
    /// </summary>
    [Serializable]
    class TerrainPiece : LevelPiece
    {
        public TerrainPiece(string key, Point pos)
            : base(key, false, pos)
        {
            IsErase = false;
            IsNoOverwrite = false;
            IsOneWay = true;
            IsInvisible = false;
            IsFake = false;
        }

        public TerrainPiece(string key, Point pos, int rotation, bool isInvert, bool isErase, bool isNoOv, bool isOneWay,
            bool isInvisible, bool isFake, int specWidth, int specHeight)
            : base(key, false, pos, rotation, isInvert)
        {
            IsErase = isErase;
            IsNoOverwrite = isNoOv;
            IsOneWay = isOneWay;
            IsInvisible = isInvisible;
            IsFake = isFake;
        }

        public bool IsErase { get; set; }
        public bool IsNoOverwrite { get; set; }
        public bool IsOneWay { get; set; }
        public bool IsSteel => ObjType == C.OBJ.STEEL;
        public bool IsInvisible { get; set; }
        public bool IsFake { get; set; }

        public override LevelPiece Clone()
        {
            return new TerrainPiece(Key, Pos, Rotation, IsInvert, IsErase, IsNoOverwrite, IsOneWay,
                                    IsInvisible, IsFake, SpecWidth, SpecHeight);
        }

        /// <summary>
        /// Compares two TerrainPieces for equality.
        /// </summary>
        /// <param name="piece"></param>
        public bool Equals(TerrainPiece piece)
        {
            return base.Equals(piece)
                && this.IsErase == piece.IsErase
                && this.IsNoOverwrite == piece.IsNoOverwrite
                && this.IsOneWay == piece.IsOneWay
                && this.SpecWidth == piece.SpecWidth
                && this.SpecHeight == piece.SpecHeight;
        }


        public override bool MayRotate()
        {
            return true;
        }

        public override bool MayFlip()
        {
            return true;
        }

        public override bool MayInvert()
        {
            return true;
        }

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

        public override Bitmap Image
        {
            get
            {
                Bitmap image = base.Image;

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
    }

}
