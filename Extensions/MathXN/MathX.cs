using System;

namespace Tigerros.Extensions.MathXN {
	/// <summary>
	/// Extension methods of various types that serve a mathematical purpose.
	/// </summary>
	public static class MathX {
		/// <summary>
		/// Clamps the <paramref name="value"/> in between <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <returns><c>value &gt; max ? max : (value &lt; min ? min : value)</c></returns>
		public static T Clamp<T>(this T value, T min, T max) where T : IComparable
			=> value.CompareTo(max) > 0 ? max : value.CompareTo(min) < 0 ? min : value;

		/// <summary>
		/// Rounds the double to the nearest integer. 0.5 rounds up.
		/// </summary>
		/// <param name="d">The double to round.</param>
		/// <returns>The nearest integer.</returns>
		public static int Round(this double d) {
			int floored = (int)d;
			double dec = d - floored;

			return dec >= 0.5 ? floored + 1 : floored;
		}
	}
}
