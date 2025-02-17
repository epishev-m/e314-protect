using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace E314.Protect
{

/// <summary>
/// Static class <c>Requires</c> provides methods for validating input data and conditions.
/// If a check fails, a corresponding exception is thrown.
/// </summary>
public static class Requires
{
	/// <summary>
	/// Ensures that the value is not <c>null</c>.
	/// </summary>
	/// <param name="value">The value to check.</param>
	/// <param name="paramName">The name of the parameter for the error message.</param>
	/// <exception cref="ArgumentNullException">Thrown if the value is <c>null</c>.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void NotNull(object value, string paramName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(paramName, "Parameter cannot be null.");
		}
	}

	/// <summary>
	/// Ensures that the string is not empty or whitespace.
	/// </summary>
	/// <param name="value">The string to check.</param>
	/// <param name="paramName">The name of the parameter for the error message.</param>
	/// <exception cref="ArgumentException">Thrown if the string is empty or whitespace.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void NotEmpty(string value, string paramName)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new ArgumentException("Parameter cannot be empty or whitespace.", paramName);
		}
	}

	/// <summary>
	/// Ensures that the numeric value is within the specified range (inclusive).
	/// </summary>
	/// <param name="value">The value to check.</param>
	/// <param name="minValue">The minimum allowed value (inclusive).</param>
	/// <param name="maxValue">The maximum allowed value (inclusive).</param>
	/// <param name="paramName">The name of the parameter for the error message.</param>
	/// <exception cref="ArgumentOutOfRangeException">Thrown if the value is outside the range.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void InRange(int value, int minValue, int maxValue, string paramName)
	{
		if (value < minValue || value > maxValue)
		{
			throw new ArgumentOutOfRangeException(paramName,
				$"Parameter must be in range {minValue} - {maxValue}.");
		}
	}

	/// <summary>
	/// Ensures that the given condition is true.
	/// </summary>
	/// <param name="condition">The condition to check.</param>
	/// <param name="message">The error message if the condition fails.</param>
	/// <exception cref="InvalidOperationException">Thrown if the condition is false.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Ensure(bool condition, string message)
	{
		if (!condition)
		{
			throw new InvalidOperationException(message);
		}
	}

	/// <summary>
	/// Ensures that the collection is not <c>null</c> and contains at least one element.
	/// </summary>
	/// <typeparam name="T">The type of elements in the collection.</typeparam>
	/// <param name="collection">The collection to check.</param>
	/// <param name="paramName">The name of the parameter for the error message.</param>
	/// <exception cref="ArgumentException">Thrown if the collection is <c>null</c> or empty.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void NotEmpty<T>(IEnumerable<T> collection, string paramName)
	{
		if (collection == null || !collection.Any())
		{
			throw new ArgumentException("Collection cannot be null or empty.", paramName);
		}
	}

	/// <summary>
	/// Ensures that the collection does not contain <c>null</c> elements.
	/// </summary>
	/// <typeparam name="T">The type of elements in the collection (must be a reference type).</typeparam>
	/// <param name="collection">The collection to check.</param>
	/// <param name="paramName">The name of the parameter for the error message.</param>
	/// <exception cref="ArgumentException">Thrown if the collection contains any <c>null</c> elements.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void NoNullElements<T>(IEnumerable<T> collection, string paramName)
		where T : class
	{
		if (collection.Any(item => item == null))
		{
			throw new ArgumentException("Collection cannot contain null elements.", paramName);
		}
	}
}

}