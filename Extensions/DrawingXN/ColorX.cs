using System.Drawing;
using Kontore.Extensions.MathXN;

namespace Kontore.Extensions.DrawingXN {
	public static class ColorX {
		/// <summary>
		/// Clamps the color between color <paramref name="min"/> and color <paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum color value.</param>
		/// <param name="max">The maximum color value.</param>
		/// <returns>The clamped color./returns>
		public static Color Clamp(this Color c, Color min, Color max)
			=> Color.FromArgb(c.R.Clamp(min.R, max.R), c.G.Clamp(min.G, max.G), c.B.Clamp(min.B, max.B));

		/// <summary>
		/// Clamps the color between <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum value of the RGB components.</param>
		/// <param name="max">The maximum value of the RGB components.</param>
		/// <returns>The clamped color./returns>
		public static Color Clamp(this Color c, byte min, byte max)
			=> Color.FromArgb(c.R.Clamp(min, max), c.G.Clamp(min, max), c.B.Clamp(min, max));
		
		/// <summary>
		/// Acts like <see cref="Color.FromArgb(int, int, int)"/> but it limits the numbers to an inclusive range from 0 to 255.
		/// This is to avoid exceptions when a number is negative or higher than 255.
		/// </summary>
		public static Color FromArgbClamped(int r, int g, int b)
			=> Color.FromArgb(r.Clamp(0, 255), g.Clamp(0, 255), b.Clamp(0, 255));

		#region Add
		public static Color Add(this Color a, Color b)
			=> FromArgbClamped(a.R + b.R, a.G + b.G, a.B + b.B);

		public static Color Add(this Color a, byte b)
			=> FromArgbClamped(a.R + b, a.G + b, a.B + b);

		public static Color Add(this Color a, double b)
			=> FromArgbClamped((a.R + b).Round(), (a.G + b).Round(), (a.B + b).Round());
		#endregion

		#region Sub
		public static Color Sub(this Color a, Color b)
			=> FromArgbClamped(a.R - b.R, a.G - b.G, a.B - b.B);

		public static Color Sub(this Color a, byte b)
			=> FromArgbClamped(a.R - b, a.G - b, a.B - b);

		public static Color Sub(this Color a, double b)
			=> FromArgbClamped((a.R - b).Round(), (a.G - b).Round(), (a.B - b).Round());
		#endregion

		#region Mul
		public static Color Mul(this Color a, Color b)
			=> FromArgbClamped(a.R * b.R, a.G * b.G, a.B * b.B);

		public static Color Mul(this Color a, byte b)
			=> FromArgbClamped(a.R * b, a.G * b, a.B * b);

		public static Color Mul(this Color a, double b)
			=> FromArgbClamped((a.R * b).Round(), (a.G * b).Round(), (a.B * b).Round());
		#endregion

		#region Div
		public static Color Div(this Color a, Color b)
			=> FromArgbClamped(a.R / b.R, a.G / b.G, a.B / b.B);
		
		public static Color Div(this Color a, byte b)
			=> FromArgbClamped(a.R / b, a.G / b, a.B / b);

		public static Color Div(this Color a, double b)
			=> FromArgbClamped((a.R / b).Round(), (a.G / b).Round(), (a.B / b).Round());
		#endregion

		/// <summary>
		/// Quantizes the color to the palette color determined by the factor.
		/// If the factor was 2, the two palette colors would be 0 and 255.
		/// </summary>
		/// <returns>The quantized color.</returns>
		public static Color Quantize(this Color c, int factor)
			=> FromArgbClamped(
				MathX.Round(factor * c.R / 255) * (255 / factor),
				MathX.Round(factor * c.G / 255) * (255 / factor),
				MathX.Round(factor * c.B / 255) * (255 / factor)
			);
	}
}
