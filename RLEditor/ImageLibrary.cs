using System;
using System.Collections.Generic;
using System.Drawing;

namespace RLEditor
{
    /// <summary>
    /// Stores the common unchangable data of pieces.
    /// </summary>
    class BaseImageInfo
    {
        /// <summary>
        /// Use this to create the base-info of a new terrain piece.
        /// </summary>
        /// <param name="newImage"></param>
        /// <param name="isSteel"></param>
        public BaseImageInfo(Bitmap newImage, bool isSteel = false)
            : this(newImage, isSteel ? C.OBJ.STEEL : C.OBJ.TERRAIN, 1, new Rectangle(0, 0, 0, 0),
               0, 0, 0, 0)
        {
            if (newImage == null)
            {
                ObjectType = C.OBJ.NULL; // null placeholder
                IsMissingFromPiecesDirectory = true;
            }
        }

        /// <summary>
        /// Use this to create the base-info of a new object piece.
        /// </summary>
        public BaseImageInfo(Bitmap newImage, C.OBJ objType, int numFrames, Rectangle triggerRect,
            int leftMargin = 0, int topMargin = 0, int rightMargin = 0, int bottomMargin = 0)
        {
            if (newImage == null)
            {
                newImage = new Bitmap(1, 1); // null placeholder
                IsMissingFromPiecesDirectory = true;
            }

            this.images = new Dictionary<RotateFlipType, List<Bitmap>>();
            this.images[RotateFlipType.RotateNoneFlipNone] = SeparateFrames(newImage, numFrames, true);
            this.Width = this.baseImages[0].Width;
            this.Height = this.baseImages[0].Height;
            this.ObjectType = objType;
            this.TriggerRect = triggerRect;
            this.PrimaryImageLocation = new Rectangle(leftMargin, topMargin, this.Width - leftMargin - rightMargin, this.Height - topMargin - bottomMargin);
        }

        Dictionary<RotateFlipType, List<Bitmap>> images;
        List<Bitmap> baseImages => images[RotateFlipType.RotateNoneFlipNone];
        List<Bitmap> imagesWithDescriptions;
        List<Bitmap> imagesWithNames;
        List<Bitmap> imagesWithNameAndData;
        List<Bitmap> imagesWithDescriptionAndData;

        public Bitmap Image(RotateFlipType rotFlipType)
        {
            if (!images.ContainsKey(rotFlipType))
                CreateRotatedImages(rotFlipType);
            return images[rotFlipType][0];
        }
        public Bitmap Image(RotateFlipType rotFlipType, int index)
        {
            if (!images.ContainsKey(rotFlipType))
                CreateRotatedImages(rotFlipType);
            return images[rotFlipType][index % images[rotFlipType].Count];
        }
        public Bitmap ImageWithDescription(int index, string pieceKey)
        {
            if (imagesWithDescriptions == null)
                CreateImagesWithDescriptions(pieceKey);
            return imagesWithDescriptions[index % imagesWithDescriptions.Count];
        }
        public Bitmap ImageWithName(int index, string pieceKey)
        {
            if (imagesWithNames == null)
                CreateImagesWithNames(pieceKey);
            return imagesWithNames[index % imagesWithNames.Count];
        }
        public Bitmap ImageWithDescriptionAndData(int index, string pieceKey)
        {
            if (imagesWithDescriptionAndData == null)
                CreateImagesWithDescriptionAndData(pieceKey);
            return imagesWithDescriptionAndData[index % imagesWithDescriptionAndData.Count];
        }
        public Bitmap ImageWithNameAndData(int index, string pieceKey)
        {
            if (imagesWithNameAndData == null)
                CreateImagesWithNameAndData(pieceKey);
            return imagesWithNameAndData[index % imagesWithNameAndData.Count];
        }
        public Bitmap WindowImageWithDirection(RotateFlipType rotFlipType, int index)
        {
            // Warning: Ignore rotFlipType for actual image and use it only for the directional arrow!
            Bitmap image = (Bitmap)Image(RotateFlipType.RotateNoneFlipNone, index).Clone();
            bool isFlipped = rotFlipType.In(RotateFlipType.RotateNoneFlipX, RotateFlipType.RotateNoneFlipXY, RotateFlipType.Rotate90FlipY, RotateFlipType.Rotate90FlipXY);
            string directionString = isFlipped ? "←" : "→";
            Point bottomRightCorner = new Point(image.Width, image.Height);
            image.WriteText(directionString, bottomRightCorner, C.RLColors[C.RLColor.Text], 12, ContentAlignment.BottomRight, new Size(20, 16));
            return image;
        }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int DefaultWidth { get; private set; }
        public int DefaultHeight { get; private set; }
        public int MarkerX { get; private set; }
        public int MarkerY { get; private set; }
        public C.OBJ ObjectType { get; private set; }
        public Rectangle TriggerRect { get; private set; }
        public Rectangle PrimaryImageLocation { get; private set; }
        public Rectangle? NineSlicingArea { get; private set; }
        public bool IsMissingFromPiecesDirectory { get; private set; } = false;

        /// <summary>
        /// Separates the various frames in one bitmap.
        /// </summary>
        private List<Bitmap> SeparateFrames(Bitmap newBitmap, int numFrames, bool isVert)
        {
            List<Bitmap> imageFrames = new List<Bitmap>();

            int newWidth = newBitmap.Width;
            int newHeight = newBitmap.Height;
            numFrames = Math.Max(numFrames, 1);

            if (isVert)
            {
                newHeight = newHeight / numFrames;
            }
            else
            {
                newWidth = newWidth / numFrames;
            }

            for (int index = 0; index < numFrames; index++)
            {
                int startX = (isVert) ? 0 : index * newWidth;
                int startY = (isVert) ? index * newHeight : 0;
                Rectangle frameRect = new Rectangle(startX, startY, newWidth, newHeight);
                imageFrames.Add(newBitmap.Crop(frameRect));
            }

            return imageFrames;
        }

        /// <summary>
        /// Creates rotated images of the desired orientation, if these do not yet exist.
        /// </summary>
        private void CreateRotatedImages(RotateFlipType rotFlipType)
        {
            images[rotFlipType] = new List<Bitmap>();
            foreach (Bitmap imageFrame in baseImages)
            {
                Bitmap rotImage = (Bitmap)imageFrame.Clone();
                rotImage.RotateFlip(rotFlipType);
                images[rotFlipType].Add(rotImage);
            }
        }

        /// <summary>
        /// Creates images with the piece description in the Piece Browser (prefers trigger type for objects)
        /// </summary>
        private void CreateImagesWithDescriptions(string pieceKey)
        {
            imagesWithDescriptions = new List<Bitmap>();

            foreach (Bitmap imageFrame in baseImages)
            {
                Bitmap newImage = new Bitmap(C.PicPieceSize.Width, C.PicPieceSize.Height);
                int posX = (newImage.Width - imageFrame.Width) / 2;
                int posY = (newImage.Height - imageFrame.Height) / 2;
                newImage.DrawOn(imageFrame, new Point(posX, posY), 254);

                // Type
                string pieceDesc = C.ObjectDescriptions.TryGetValue(ObjectType, out string displayName)
                                   ? displayName
                                   : ObjectType.ToString();

                // Show Name instead of Type when in Terrain/Steel/Rulers tab
                if (ObjectType.In(C.OBJ.TERRAIN, C.OBJ.STEEL, C.OBJ.RULER))
                    pieceDesc = System.IO.Path.GetFileNameWithoutExtension(pieceKey);

                DrawDataString(newImage, pieceDesc, 0, 0, C.RLColors[C.RLColor.Text], 8);

                imagesWithDescriptions.Add(newImage);
            }
        }

        /// <summary>
        /// Creates images with the piece name in the Piece Browser (prefers name for objects)
        /// </summary>
        private void CreateImagesWithNames(string pieceKey)
        {
            imagesWithNames = new List<Bitmap>();

            foreach (Bitmap imageFrame in baseImages)
            {
                Bitmap newImage = new Bitmap(C.PicPieceSize.Width, C.PicPieceSize.Height);
                int posX = (newImage.Width - imageFrame.Width) / 2;
                int posY = (newImage.Height - imageFrame.Height) / 2;
                newImage.DrawOn(imageFrame, new Point(posX, posY), 254);

                string pieceDesc = System.IO.Path.GetFileNameWithoutExtension(pieceKey);

                DrawDataString(newImage, pieceDesc, 0, 0, C.RLColors[C.RLColor.Text], 8);

                imagesWithNames.Add(newImage);
            }
        }

        /// <summary>
        /// Creates images with data in the piece browser (prefers trigger type for objects)
        /// </summary>
        private void CreateImagesWithDescriptionAndData(string pieceKey)
        {
            imagesWithDescriptionAndData = new List<Bitmap>();

            foreach (Bitmap imageFrame in baseImages)
            {
                Bitmap newImage = new Bitmap(C.PicPieceSize.Width, C.PicPieceSize.Height);
                int posX = (newImage.Width - imageFrame.Width) / 2;
                int posY = (newImage.Height - imageFrame.Height) / 2;
                newImage.DrawOn(imageFrame, new Point(posX, posY), 254);

                // Type
                string pieceDesc = C.ObjectDescriptions.TryGetValue(ObjectType, out string displayName)
                                   ? displayName
                                   : ObjectType.ToString();

                // Show Name instead of Type when in Terrain/Steel/Rulers tab
                if (ObjectType.In(C.OBJ.TERRAIN, C.OBJ.STEEL, C.OBJ.RULER))
                    pieceDesc = System.IO.Path.GetFileNameWithoutExtension(pieceKey);

                // Size
                string pieceSize = Width.ToString() + " x " + Height.ToString();

                DrawDataString(newImage, pieceDesc, 0, 0, C.RLColors[C.RLColor.Text], 8);
                DrawDataString(newImage, pieceSize, 0, 64, Color.SkyBlue, 8);

                imagesWithDescriptionAndData.Add(newImage);
            }
        }

        /// <summary>
        /// Creates images with data in the Piece Browser (prefers name for objects)
        /// </summary>
        private void CreateImagesWithNameAndData(string pieceKey)
        {
            imagesWithNameAndData = new List<Bitmap>();

            foreach (Bitmap imageFrame in baseImages)
            {
                Bitmap newImage = new Bitmap(C.PicPieceSize.Width, C.PicPieceSize.Height);
                int posX = (newImage.Width - imageFrame.Width) / 2;
                int posY = (newImage.Height - imageFrame.Height) / 2;
                newImage.DrawOn(imageFrame, new Point(posX, posY), 254);

                // Show Name
                string pieceDesc = System.IO.Path.GetFileNameWithoutExtension(pieceKey);

                // Size
                string pieceSize = Width.ToString() + " x " + Height.ToString();

                DrawDataString(newImage, pieceDesc, 0, 0, C.RLColors[C.RLColor.Text], 8);
                DrawDataString(newImage, pieceSize, 0, 64, Color.SkyBlue, 8);

                imagesWithNameAndData.Add(newImage);
            }
        }

        private void DrawDataString(Bitmap image, String text, int xOffset, int yOffset, Color color, int fontSize)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Font font = new Font("Tahoma", fontSize, FontStyle.Regular);
                SizeF textSize = g.MeasureString(text, font);

                int margin = 4;
                int textX = image.Width - (int)textSize.Width - margin - xOffset;
                int textY = image.Height - (int)textSize.Height - margin - yOffset;

                // Draw text background
                Rectangle textBackground = new Rectangle(textX - 2, textY - 2, (int)textSize.Width + 4, (int)textSize.Height + 4);
                using (Brush bgBrush = new SolidBrush(Color.FromArgb(0, 0, 51))) // #000033 with no transparency
                {
                    g.FillRectangle(bgBrush, textBackground);
                }

                // Draw text
                using (Brush textBrush = new SolidBrush(color))
                {
                    g.DrawString(text, font, textBrush, textX, textY);
                }
            }
        }
    }

    /// <summary>
    /// Provides images and associated data of pieces.
    /// <para> It loads them upon first usage of said piece. </para>
    /// </summary>
    static class ImageLibrary
    {
        static ImageLibrary()
        {
            imageDict = new Dictionary<string, BaseImageInfo>();
        }

        // The key is the file path below the "styles\\pieces" folder!
        static Dictionary<string, BaseImageInfo> imageDict;

        /// <summary>
        /// Clears the current imageDict
        /// </summary>
        public static void Clear()
        {
            imageDict.Clear();
        }

        private static readonly List<string> rulerKeys = new List<string>();
        public static IReadOnlyList<string> RulerKeys => rulerKeys;
        public static void RegisterRuler(string key)
        {
            if (!rulerKeys.Contains(key))
                rulerKeys.Add(key);
        }

        private static RLEditForm mainForm;

        // Method to set the editor form, this must be called early in your app
        public static void SetEditorForm(RLEditForm editorForm)
        {
            mainForm = editorForm;
        }

        /// <summary>
        /// Returns whether an image with this ImageKey exists.
        /// </summary>
        public static bool ExistsKey(string imageKey)
        {
            if (imageDict.ContainsKey(imageKey))
                return true;
            else
                return AddNewImage(imageKey);
        }

        /// <summary>
        /// This checks whether an image exists or may be loaded. It does not actually load the image itself.
        /// </summary>
        public static bool IsImageLoadable(string imageKey)
        {
            string filePath = C.AppPathPieces + imageKey + ".png";
            if (imageDict.ContainsKey(imageKey))
                return true;
            else if (!System.IO.File.Exists(filePath))
                return false;
            else
            {
                try
                {
                    System.IO.File.Open(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read).Dispose();
                }
                catch (System.IO.IOException)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Checks to see if the piece has been marked as missing from directory.
        /// </summary>
        public static bool GetIsMissing(string imageKey)
        {
            return imageDict.TryGetValue(imageKey, out BaseImageInfo info) && info.IsMissingFromPiecesDirectory;
        }

        /// <summary>
        /// Returns a correctly oriented image corresponding to the key, or null if image cannot be found. 
        /// <para> Warning: The Bitmap is passed by reference, so NEVER change its value! </para>
        /// </summary>
        public static Bitmap GetImage(string imageKey, RotateFlipType rotFlipType = RotateFlipType.RotateNoneFlipNone)
        {
            return GetImage(imageKey, rotFlipType, 0);
        }

        /// <summary>
        /// Returns a correctly oriented image corresponding to the key and index, or null if image cannot be found. 
        /// <para> Warning: The Bitmap is passed by reference, so NEVER change its value! </para>
        /// </summary>
        public static Bitmap GetImage(string imageKey, RotateFlipType rotFlipType, int index)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                {
                    mainForm.missingPieces.Add(imageKey);
                    return null;
                }
            }

            return imageDict[imageKey].Image(rotFlipType, index);
        }

        /// <summary>
        /// Populates the Piece Browser with images & descriptions
        /// </summary>
        public static Bitmap GetImageWithDescription(string imageKey, int index)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                {
                    mainForm.missingPieces.Add(imageKey);
                    return null;
                }
            }

            return imageDict[imageKey].ImageWithDescription(index, imageKey);
        }

        /// <summary>
        /// Populates the Piece Browser with images (prefers piece names for objects)
        /// </summary>
        public static Bitmap GetImageWithName(string imageKey, int index)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                {
                    mainForm.missingPieces.Add(imageKey);
                    return null;
                }
            }

            return imageDict[imageKey].ImageWithName(index, imageKey);
        }

        /// <summary>
        /// Populates the Piece Browser with images & data
        /// </summary>
        public static Bitmap GetImageWithDescriptionAndData(string imageKey, int index)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                {
                    mainForm.missingPieces.Add(imageKey);
                    return null;
                }
            }

            return imageDict[imageKey].ImageWithDescriptionAndData(index, imageKey);
        }

        /// <summary>
        /// Populates the Piece Browser with images & data (prefers names for objects)
        /// </summary>
        public static Bitmap GetImageWithNameAndData(string imageKey, int index)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                {
                    mainForm.missingPieces.Add(imageKey);
                    return null;
                }
            }

            return imageDict[imageKey].ImageWithNameAndData(index, imageKey);
        }

        /// <summary>
        /// Returns the image with the directional arrow in the Piece Browser
        /// </summary>
        public static Bitmap GetWindowImageWithDirection(string imageKey, RotateFlipType rotFlipType, int index)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                {
                    mainForm.missingPieces.Add(imageKey);
                    return null;
                }
            }

            return imageDict[imageKey].WindowImageWithDirection(rotFlipType, index);
        }

        public static (int Left, int Right) GetMargins(string imageKey)
        {
            // Retrieve BaseImageInfo associated with the imageKey
            var baseImageInfo = imageDict[imageKey];

            // Extract margins from BaseImageInfo
            int leftMargin = Math.Abs(baseImageInfo.PrimaryImageLocation.X);
            int rightMargin = Math.Abs(baseImageInfo.Width - baseImageInfo.PrimaryImageLocation.Right);

            return (leftMargin, rightMargin);
        }

        /// <summary>
        /// Gets the smallest rectangle which bounds all solid pixels in the image.
        /// </summary>
        public struct SolidPixelKey
        {
            public string ImageKey;
            public int Rotation;
            public bool IsFlipped;

            public override bool Equals(object obj)
            {
                if (!(obj is SolidPixelKey))
                    return false;

                var other = (SolidPixelKey)obj;
                return ImageKey == other.ImageKey
                    && Rotation == other.Rotation
                    && IsFlipped == other.IsFlipped;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 17;
                    hash = hash * 23 + (ImageKey?.GetHashCode() ?? 0);
                    hash = hash * 23 + Rotation.GetHashCode();
                    hash = hash * 23 + IsFlipped.GetHashCode();
                    return hash;
                }
            }
        }

        public static Dictionary<SolidPixelKey, Rectangle> SolidPixelRects = new Dictionary<SolidPixelKey, Rectangle>();

        public static Rectangle SolidPixelRect(Bitmap bmp, string key, int rotation, bool flipped)
        {
            var cacheKey = new SolidPixelKey
            {
                ImageKey = key,
                Rotation = rotation,
                IsFlipped = flipped
            };

            if (SolidPixelRects.TryGetValue(cacheKey, out var rect))
                return rect;

            rect = ComputeSolidPixelRect(bmp);
            SolidPixelRects[cacheKey] = rect;
            return rect;
        }

        public static Rectangle ComputeSolidPixelRect(Bitmap bmp)
        {
            int left = 0, right = bmp.Width - 1, top = 0, bottom = bmp.Height - 1;

            bool HasSolidPixelInColumn(int x) { for (int y = 0; y < bmp.Height; y++) if (bmp.GetPixel(x, y).A != 0) return true; return false; }
            bool HasSolidPixelInRow(int y) { for (int x = 0; x < bmp.Width; x++) if (bmp.GetPixel(x, y).A != 0) return true; return false; }

            while (left <= right && !HasSolidPixelInColumn(left)) left++;
            while (right >= left && !HasSolidPixelInColumn(right)) right--;
            while (top <= bottom && !HasSolidPixelInRow(top)) top++;
            while (bottom >= top && !HasSolidPixelInRow(bottom)) bottom--;

            if (left > right || top > bottom) return new Rectangle(0, 0, 0, 0); // fully transparent

            return new Rectangle(left, top, right - left + 1, bottom - top + 1);
        }

        public static bool GetIsFullyTransparent(Bitmap bmp, string key)
        {
            var rect = SolidPixelRect(bmp, key, 0, false);
            return rect.Width == 0 || rect.Height == 0;
        }

        /// <summary>
        /// Returns the width of the piece corresponding to the key, or -1 if image cannot be found. 
        /// </summary>
        /// <param name="imageKey"></param>
        public static int GetWidth(string imageKey)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                    return 0;
            }

            return imageDict[imageKey].Width;
        }

        /// <summary>
        /// Returns the height of the piece corresponding to the key, or -1 if image cannot be found. 
        /// </summary>
        /// <param name="imageKey"></param>
        public static int GetHeight(string imageKey)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                    return 0;
            }

            return imageDict[imageKey].Height;
        }

        /// <summary>
        /// Returns the default width of the piece corresponding to the key, or -1 if image cannot be found. 
        /// </summary>
        /// <param name="imageKey"></param>
        public static int GetDefaultWidth(string imageKey)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                    return 0;
            }

            return imageDict[imageKey].DefaultWidth;
        }

        /// <summary>
        /// Returns the default height of the piece corresponding to the key, or -1 if image cannot be found. 
        /// </summary>
        /// <param name="imageKey"></param>
        public static int GetDefaultHeight(string imageKey)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                    return 0;
            }

            return imageDict[imageKey].DefaultHeight;
        }

        /// <summary>
        /// Returns the Exit Marker X-pos corresponding to the key, or -1 if image cannot be found. 
        /// </summary>
        /// <param name="imageKey"></param>
        public static int GetMarkerX(string imageKey)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                    return 0;
            }

            return imageDict[imageKey].MarkerX;
        }

        /// <summary>
        /// Returns the Exit Marker Y-pos corresponding to the key, or -1 if image cannot be found. 
        /// </summary>
        /// <param name="imageKey"></param>
        public static int GetMarkerY(string imageKey)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                    return 0;
            }

            return imageDict[imageKey].MarkerY;
        }

        /// <summary>
        /// Returns the object type of the piece corresponding to the key, or C.OBJ.NULL if image cannot be found. 
        /// </summary>
        /// <param name="imageKey"></param>
        public static C.OBJ GetObjType(string imageKey)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                    return C.OBJ.NULL;
            }

            return imageDict[imageKey].ObjectType;
        }

        /// <summary>
        /// Returns the trigger area of the piece corresponding to the key, or an empty rectangle if image cannot be found. 
        /// </summary>
        /// <param name="imageKey"></param>
        public static Rectangle GetTrigger(string imageKey)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                    return new Rectangle(0, 0, 0, 0);
            }

            return imageDict[imageKey].TriggerRect;
        }

        /// <summary>
        /// Loads a new image into the ImageLibrary. Returns false, if image cannot be found.
        /// </summary>
        /// <param name="imageKey"></param>
        static bool AddNewImage(string imageKey)
        {
            try
            {
                imageDict[imageKey] = LoadStylesFromFile.ImageInfo(imageKey);

                return true;
            }
            catch (Exception Ex)
            {
                Utility.LogException(Ex);
                return false;
            }
        }

        /// <summary>
        /// Adds by hand a new image to the ImagelIbrary, assuming the ImageKey doesn't exist yet. 
        /// </summary>
        /// <param name="imageKey"></param>
        /// <param name="image"></param>
        /// <param name="objType"></param>
        /// <param name="triggerRect"></param>
        public static void AddNewImage(string imageKey, Bitmap image, C.OBJ objType, Rectangle triggerRect)
        {
            if (imageDict.ContainsKey(imageKey))
                return;

            try
            {
                imageDict[imageKey] = new BaseImageInfo(image, objType, 1, triggerRect);
            }
            catch (Exception Ex)
            {
                Utility.LogException(Ex);
                imageDict[imageKey] = new BaseImageInfo(new Bitmap(1, 1));
            }
        }


        /// <summary>
        /// Creates the image key from a file path (relative or absolute). 
        /// </summary>
        /// <param name="filePath"></param>
        public static string CreatePieceKey(string filePath)
        {
            string fullPath = System.IO.Path.GetFullPath(filePath);
            string relativePath = fullPath.Remove(0, C.AppPathPieces.Length);
            return System.IO.Path.ChangeExtension(relativePath, null);
        }

        /// <summary>
        /// Creates the image key from the style and piece name.
        /// </summary>
        public static string CreatePieceKey(string styleName, string pieceName, bool isObject)
        {
            return styleName + C.DirSep + pieceName;
        }

        /// <summary>
        /// Transforms the piece location from level file location (using only the primary image)
        /// to editor location (using the merge of primary and secondary animations)
        /// </summary>
        /// <param name="levelFileLocation"></param>
        public static Point LevelFileToEditorCoordinates(string imageKey, Point levelFileLocation,
          bool rotate, bool flip, bool invert)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                    return levelFileLocation;
            }

            var img = imageDict[imageKey];
            var primaryImageLocation = img.PrimaryImageLocation;
            var boundsRect = new Rectangle(0, 0, img.Width, img.Height);

            if (rotate)
            {
                int oldX = primaryImageLocation.X;
                primaryImageLocation.X = boundsRect.Height - primaryImageLocation.Y - primaryImageLocation.Height;
                primaryImageLocation.Y = oldX;

                int oldW = primaryImageLocation.Width;
                primaryImageLocation.Width = primaryImageLocation.Height;
                primaryImageLocation.Height = oldW;

                if (flip)
                    primaryImageLocation.X = boundsRect.Bottom - primaryImageLocation.Left - primaryImageLocation.Width;
                if (invert)
                    primaryImageLocation.Y = boundsRect.Right - primaryImageLocation.Top - primaryImageLocation.Height;
            }
            else
            {
                if (flip)
                    primaryImageLocation.X = boundsRect.Right - primaryImageLocation.Right;
                if (invert)
                    primaryImageLocation.Y = boundsRect.Bottom - primaryImageLocation.Bottom;
            }

            return new Point(levelFileLocation.X - primaryImageLocation.X,
                             levelFileLocation.Y - primaryImageLocation.Y);
        }

        /// <summary>
        /// Transforms the piece location from editor location (using the merge of primary and secondary animations)
        /// to level file location (using only the primary image)
        /// </summary>
        /// <param name="imageKey"></param>
        /// <param name="editorLocation"></param>
        public static Point EditorToLevelFileCoordinates(string imageKey, Point editorLocation,
          bool rotate, bool flip, bool invert)
        {
            if (!imageDict.ContainsKey(imageKey))
            {
                bool success = AddNewImage(imageKey);
                if (!success)
                    return editorLocation;
            }

            var img = imageDict[imageKey];
            var primaryImageLocation = img.PrimaryImageLocation;
            var boundsRect = new Rectangle(0, 0, img.Width, img.Height);

            if (rotate)
            {
                int oldX = primaryImageLocation.X;
                primaryImageLocation.X = boundsRect.Height - primaryImageLocation.Y - primaryImageLocation.Height;
                primaryImageLocation.Y = oldX;

                int oldW = primaryImageLocation.Width;
                primaryImageLocation.Width = primaryImageLocation.Height;
                primaryImageLocation.Height = oldW;

                if (flip)
                    primaryImageLocation.X = boundsRect.Bottom - primaryImageLocation.Left - primaryImageLocation.Width;
                if (invert)
                    primaryImageLocation.Y = boundsRect.Right - primaryImageLocation.Top - primaryImageLocation.Height;
            }
            else
            {
                if (flip)
                    primaryImageLocation.X = boundsRect.Right - primaryImageLocation.Right;
                if (invert)
                    primaryImageLocation.Y = boundsRect.Bottom - primaryImageLocation.Bottom;
            }

            return new Point(editorLocation.X + primaryImageLocation.X,
                             editorLocation.Y + primaryImageLocation.Y);
        }
    }
}
