using System;
using System.Diagnostics;

namespace Kontore.Extensions.MiscellaneousXN {
	/// <summary>
	/// Extension methods for the <see cref="Stopwatch"/>.
	/// </summary>
	public static class StopwatchX {
		/// <summary>
		/// Executes and action and returns the stopwatch used to time that action.
		/// </summary>
		/// <param name="stopwatch">The stopwatch used to time the action.</param>
		/// <param name="action">The action to execute.</param>
		/// <returns>The stopwatch after it has been restarted and stopped.</returns>
		public static Stopwatch Time(this Stopwatch stopwatch, Action action) {
			stopwatch.Restart();
			action();
			stopwatch.Stop();
			return stopwatch;
		}
	}
}
