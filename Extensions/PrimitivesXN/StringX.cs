using System;
using System.Text;

namespace Tigerros.Extensions.StringXN {
	/// <summary>
	/// Extension methods for the <see cref="string"/>.
	/// </summary>
	public static class StringX {
		/// <summary>
		/// Retrieves a substring from this instance.
		///	The substring starts at a specified character position and continues until the <paramref name="predicate"/> is met.
		/// </summary>
		/// <param name="s"></param>
		/// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
		/// <param name="predicate">A function to test each character for a condition.</param>
		/// <returns>The retrieved substring.</returns>
		public static string SubstringUntil(this string s, int startIndex, Predicate<char> predicate) {
			StringBuilder result = new StringBuilder();

			for (int i = startIndex; !predicate(s[i]); i++) {
				result.Append(s[i]);
			}

			return result.ToString();
		}

		/// <summary>
		/// Parses the specified string into an enum value of the type <typeparamref name="TEnum"/>.
		/// </summary>
		/// <typeparam name="TEnum">The enum to convert to.</typeparam>
		/// <param name="enumValue">The string value to parse.</param>
		/// <returns>The enum value.</returns>
		public static TEnum ToEnum<TEnum>(this string enumValue)
			=> (TEnum)Enum.Parse(typeof(TEnum), enumValue);
	}
}
