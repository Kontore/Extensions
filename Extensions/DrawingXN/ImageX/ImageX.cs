using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Tigerros.Extensions.DrawingXN {
	/// <summary>
	/// Extension methods for the <see cref="Image"/>.
	/// Has all the methods that the <see cref="BitmapX"/> has, but those that use the extra capabilities of the <see cref="Bitmap"/>
	/// transform the given <see cref="Image"/> into a <see cref="Bitmap"/>.
	/// </summary>
	public static class ImageX {
		/// <summary>
		/// Gets the colors of all pixels in this image.
		/// </summary>
		/// <returns>A 2D <see cref="Color"/> array. The first dimension is the width, and the second is the height.</returns>
		public static Color[,] GetPixels2D(this Image image)
			=> new Bitmap(image).GetPixels2D();

		/// <summary>
		/// Gets the colors of all pixels in this image.
		/// </summary>
		/// <returns>A <see cref="Color"/> array that contains all the pixels. Starts from the top left corner, then every row from left to right.</returns>
		public static Color[] GetPixels(this Image image)
			=> new Bitmap(image).GetPixels();

		/// <summary>
		/// Resize the image to the specified width and height.
		/// </summary>	
		/// <param name="image">The image to resize.</param>
		/// <param name="width">The width to resize to.</param>
		/// <param name="height">The height to resize to.</param>
		/// <returns>The resized image.</returns>
		public static Bitmap Resize(this Image image, int width, int height, bool keepAspectRatio = false) {
			double ratioX = (double)width / image.Width;
			double ratioY = (double)height / image.Height;
			double ratio = ratioX < ratioY ? ratioX : ratioY;
			int newWidth = Convert.ToInt32(image.Width * ratio);
			int newHeight = Convert.ToInt32(image.Height * ratio);

			var destRect = new Rectangle(0, 0, keepAspectRatio ? newWidth : width, keepAspectRatio ? newHeight : height);
			var destImage = new Bitmap(keepAspectRatio ? newWidth : width, keepAspectRatio ? newHeight : height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage)) {
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighSpeed;
				graphics.InterpolationMode = InterpolationMode.Low;
				graphics.SmoothingMode = SmoothingMode.HighSpeed;
				graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

				using (var wrapMode = new ImageAttributes()) {
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}
	}
}
