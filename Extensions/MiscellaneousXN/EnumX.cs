using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Tigerros.Extensions.MiscellaneousXN {
	/// <summary>
	/// Extension methods for the <see cref="Enum"/>.
	/// </summary>
	public static class EnumX {
		/// <summary>
		/// Converts an enum value to a string.
		/// </summary>
		/// <param name="enum">The enum to convert.</param>
		/// <returns>The converted string.</returns>
		public static string ConvertToString(this Enum @enum)
			=> Enum.GetName(@enum.GetType(), @enum);
	}
}
