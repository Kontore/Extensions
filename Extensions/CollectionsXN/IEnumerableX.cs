using System;
using System.Collections.Generic;
using System.Linq;

namespace Tigerros.Extensions.CollectionsXN {
	/// <summary>
	/// Extension methods for the <see cref="IEnumerable{T}"/>.
	/// </summary>
	public static class IEnumerableX {
		/// <summary>
		/// Applies an accumulator function over a sequence, but is capable of changing the returning type.
		/// </summary>
		/// <typeparam name="TResult">The return type.</typeparam>
		/// <typeparam name="TSource">The type of the elements of the source.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="func">An accumulator function to be invoked on each element.</param>
		/// <returns>The aggregated result of the <typeparamref name="TResult"/> type.</returns>
		public static TResult Aggregate<TResult, TSource>(this IEnumerable<TSource> source, Func<TResult, TSource, TResult> func) {
			TResult carry = default(TResult);

			foreach (var current in source) {
				carry = func(carry, current);
			}

			return carry;
		}

		/// <summary>
		/// Combines the <see cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, int, TResult})"/>
		/// and <see cref="Enumerable.Where{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/> methods to one loop instead of two.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of the source.</typeparam>
		/// <typeparam name="TResult">The type of the elements of the returned enumerable.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="selector">A transform function to apply to each element.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>An <see cref="IEnumerable{TResult}"/> containing the filtered and transformed elements.</returns>
		public static IEnumerable<TResult> SelectWhere<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, Func<TSource, bool> predicate) {
			foreach (TSource item in source)
				if (predicate(item))
					yield return selector(item);
		}
	}
}
