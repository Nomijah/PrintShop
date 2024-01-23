using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace PrintShop.BLL
{
    internal static class ImageProcessing
    {
        public static Image ResizeImage(Image srcImage, int heightInPixels)
        {
            float ratio = (float)heightInPixels / (float)srcImage.Height;
            int newWidth = (int)(srcImage.Width * ratio);
            Image b = new Bitmap(newWidth, heightInPixels);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(srcImage, 0, 0, newWidth, heightInPixels);
            g.Dispose();
            return b;
        }

        public static byte[] ImageToByte(Image image)
        {
            using (var stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        public static Stream BytesToStream(byte[] image)
        {
            return new MemoryStream(image);
        }

        public static byte[] StreamToBytes(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return System.Text.Encoding.UTF8.GetBytes(reader.ReadToEnd());
            }
        }

        public static byte[] WaterMarkTest(Image image, string watermarkText)
        {
            using (Bitmap bitmap = new Bitmap(image))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    // Set brush color and opacity, I use two brushes to get a shadow effect for visibility.
                    Brush brush = new SolidBrush(Color.FromArgb(70, 0, 0, 0));
                    Brush brushB = new SolidBrush(Color.FromArgb(70, 255, 255, 255));
                    Font font = new Font("Arial", 80, FontStyle.Italic, GraphicsUnit.Pixel);
                    // Create borders for alignment of text, number two a bit bigger to offset the shadow.
                    Rectangle rect1 = new Rectangle(1, 1, bitmap.Width, bitmap.Height);
                    Rectangle rect2 = new Rectangle(1, 1, bitmap.Width +8, bitmap.Height +8);
                    // Set string alignment.
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    // Used to adjust position due to rotation making the text not centered.
                    graphics.TranslateTransform(-(bitmap.Width/12), bitmap.Height/5);
                    // Rotate text.
                    graphics.RotateTransform(-15);
                    // Draw shadow and foreground text.
                    graphics.DrawString(watermarkText, font, brushB, rect2, stringFormat);
                    graphics.DrawString(watermarkText, font, brush, rect1, stringFormat);
                    graphics.Dispose();
                    // Convert to byte array.
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, ImageFormat.Jpeg);
                        ms.Position = 0;
                        return ms.ToArray();
                    }
                }
            }
        }
    }
}
