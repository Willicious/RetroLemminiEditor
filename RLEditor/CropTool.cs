using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RLEditor
{
    public class CropTool
    {
        public Rectangle LevelCropRect { get; private set; }
        public bool Active { get; set; }

        private readonly Func<Rectangle, Rectangle> levelToPicRect;
        private readonly Func<Point, Point> picToLevelPoint;
        private readonly Func<Rectangle> getLevelBounds;

        private enum DragMode
        {
            None,
            Move,
            ResizeLeft,
            ResizeRight,
            ResizeTop,
            ResizeBottom,
            ResizeTopLeft,
            ResizeTopRight,
            ResizeBottomLeft,
            ResizeBottomRight
        }

        private DragMode dragMode = DragMode.None;
        private Point dragStartLevel;
        private Rectangle originalRect;

        private const int HANDLE_SIZE = 6;

        public CropTool(
            Func<Rectangle, Rectangle> levelToPicRect,
            Func<Point, Point> picToLevelPoint,
            Func<Rectangle> getLevelBounds)
        {
            this.levelToPicRect = levelToPicRect;
            this.picToLevelPoint = picToLevelPoint;
            this.getLevelBounds = getLevelBounds;
        }

        public void Start()
        {
            Active = true;
            LevelCropRect = getLevelBounds();
        }

        public void Stop()
        {
            Active = false;
            dragMode = DragMode.None;
        }

        public void Draw(Graphics g)
        {
            if (!Active)
                return;

            Rectangle picRect = levelToPicRect(LevelCropRect);

            using (Brush darken = new SolidBrush(Color.FromArgb(120, 0, 0, 0)))
            {
                Rectangle full = levelToPicRect(getLevelBounds());

                Region outside = new Region(full);
                outside.Exclude(picRect);
                g.FillRegion(darken, outside);
            }

            using (Pen pen = new Pen(Color.Lime, 2))
            {
                pen.DashStyle = DashStyle.Dash;
                g.DrawRectangle(pen, picRect);
            }

            DrawHandles(g, picRect);
        }

        private void DrawHandles(Graphics g, Rectangle rect)
        {
            foreach (Rectangle handle in GetHandleRects(rect))
            {
                g.FillRectangle(Brushes.White, handle);
                g.DrawRectangle(Pens.Black, handle);
            }
        }

        private Rectangle[] GetHandleRects(Rectangle rect)
        {
            int hs = HANDLE_SIZE;

            return new Rectangle[]
            {
            new Rectangle(rect.Left - hs, rect.Top - hs, hs*2, hs*2),
            new Rectangle(rect.Right - hs, rect.Top - hs, hs*2, hs*2),
            new Rectangle(rect.Left - hs, rect.Bottom - hs, hs*2, hs*2),
            new Rectangle(rect.Right - hs, rect.Bottom - hs, hs*2, hs*2)
            };
        }

        public void MouseDown(Point picPoint)
        {
            if (!Active)
                return;

            Point levelPoint = picToLevelPoint(picPoint);
            Rectangle picRect = levelToPicRect(LevelCropRect);

            dragMode = HitTest(picPoint, picRect);
            if (dragMode == DragMode.None)
                return;

            dragStartLevel = levelPoint;
            originalRect = LevelCropRect;
        }

        public void MouseMove(Point picPoint)
        {
            if (!Active || dragMode == DragMode.None)
                return;

            Point levelPoint = picToLevelPoint(picPoint);
            int dx = levelPoint.X - dragStartLevel.X;
            int dy = levelPoint.Y - dragStartLevel.Y;

            Rectangle r = originalRect;

            switch (dragMode)
            {
                case DragMode.Move:
                    r.Offset(dx, dy);
                    break;

                case DragMode.ResizeLeft:
                    r.X += dx;
                    r.Width -= dx;
                    break;

                case DragMode.ResizeRight:
                    r.Width += dx;
                    break;

                case DragMode.ResizeTop:
                    r.Y += dy;
                    r.Height -= dy;
                    break;

                case DragMode.ResizeBottom:
                    r.Height += dy;
                    break;

                case DragMode.ResizeTopLeft:
                    r.X += dx;
                    r.Width -= dx;
                    r.Y += dy;
                    r.Height -= dy;
                    break;

                case DragMode.ResizeTopRight:
                    r.Width += dx;
                    r.Y += dy;
                    r.Height -= dy;
                    break;

                case DragMode.ResizeBottomLeft:
                    r.X += dx;
                    r.Width -= dx;
                    r.Height += dy;
                    break;

                case DragMode.ResizeBottomRight:
                    r.Width += dx;
                    r.Height += dy;
                    break;
            }

            if (r.Width < 1) r.Width = 1;
            if (r.Height < 1) r.Height = 1;

            Rectangle bounds = getLevelBounds();
            r = Rectangle.Intersect(r, bounds);

            LevelCropRect = r;
        }

        public void MouseUp()
        {
            dragMode = DragMode.None;
        }

        private DragMode HitTest(Point picPoint, Rectangle picRect)
        {
            Rectangle[] handles = GetHandleRects(picRect);

            if (handles[0].Contains(picPoint)) return DragMode.ResizeTopLeft;
            if (handles[1].Contains(picPoint)) return DragMode.ResizeTopRight;
            if (handles[2].Contains(picPoint)) return DragMode.ResizeBottomLeft;
            if (handles[3].Contains(picPoint)) return DragMode.ResizeBottomRight;

            if (picRect.Contains(picPoint))
                return DragMode.Move;

            return DragMode.None;
        }
    }
}
