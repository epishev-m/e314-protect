using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using E314.Exceptions;

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
	/// <param name="fileName">The full path of the source file that contains the caller. Automatically populated by the runtime.</param>
	/// <param name="methodName">The name of the method or property that invoked the exception. Automatically populated by the runtime.</param>
	/// <param name="lineNumber">The line number in the source file at which the exception was thrown. Automatically populated by the runtime.</param>
	/// <exception cref="ArgNullException">Thrown if the value is <c>null</c>.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void NotNull(
		object value,
		string paramName,
		[CallerFilePath] string fileName = "",
		[CallerMemberName] string methodName = "",
		[CallerLineNumber] int lineNumber = 0)
	{
		if (value == null)
		{
			throw new ArgNullException(
				paramName,
				"Parameter cannot be null.",
				fileName: fileName,
				methodName: methodName,
				lineNumber: lineNumber );
		}
	}

	/// <summary>
	/// Ensures that the string is not empty or whitespace.
	/// </summary>
	/// <param name="value">The string to check.</param>
	/// <param name="paramName">The name of the parameter for the error message.</param>
	/// <param name="fileName">The full path of the source file that contains the caller. Automatically populated by the runtime.</param>
	/// <param name="methodName">The name of the method or property that invoked the exception. Automatically populated by the runtime.</param>
	/// <param name="lineNumber">The line number in the source file at which the exception was thrown. Automatically populated by the runtime.</param>
	/// <exception cref="ArgException">Thrown if the string is empty or whitespace.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void NotEmpty(
		string value,
		string paramName,
		[CallerFilePath] string fileName = "",
		[CallerMemberName] string methodName = "",
		[CallerLineNumber] int lineNumber = 0)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new ArgException(
				paramName,
				"Parameter cannot be empty or whitespace.",
				fileName: fileName,
				methodName: methodName,
				lineNumber: lineNumber);
		}
	}

	/// <summary>
	/// Ensures that the numeric value is within the specified range (inclusive).
	/// </summary>
	/// <param name="value">The value to check.</param>
	/// <param name="minValue">The minimum allowed value (inclusive).</param>
	/// <param name="maxValue">The maximum allowed value (inclusive).</param>
	/// <param name="paramName">The name of the parameter for the error message.</param>
	/// <param name="fileName">The full path of the source file that contains the caller. Automatically populated by the runtime.</param>
	/// <param name="methodName">The name of the method or property that invoked the exception. Automatically populated by the runtime.</param>
	/// <param name="lineNumber">The line number in the source file at which the exception was thrown. Automatically populated by the runtime.</param>
	/// <exception cref="ArgOutOfRangeException">Thrown if the value is outside the range.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void InRange(
		int value,
		int minValue,
		int maxValue,
		string paramName,
		[CallerFilePath] string fileName = "",
		[CallerMemberName] string methodName = "",
		[CallerLineNumber] int lineNumber = 0)
	{
		if (value < minValue || value > maxValue)
		{
			throw new ArgOutOfRangeException(
				paramName,
				$"Parameter must be in range {minValue} - {maxValue}.",
				fileName: fileName,
				methodName: methodName,
				lineNumber: lineNumber);
		}
	}

	/// <summary>
	/// Ensures that the given condition is true.
	/// </summary>
	/// <param name="condition">The condition to check.</param>
	/// <param name="message">The error message if the condition fails.</param>
	/// <param name="fileName">The full path of the source file that contains the caller. Automatically populated by the runtime.</param>
	/// <param name="methodName">The name of the method or property that invoked the exception. Automatically populated by the runtime.</param>
	/// <param name="lineNumber">The line number in the source file at which the exception was thrown. Automatically populated by the runtime.</param>
	/// <exception cref="InvOpException">Thrown if the condition is false.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Ensure(
		bool condition,
		string message,
		[CallerFilePath] string fileName = "",
		[CallerMemberName] string methodName = "",
		[CallerLineNumber] int lineNumber = 0)
	{
		if (!condition)
		{
			throw new InvOpException(
				message,
				fileName: fileName,
				methodName: methodName,
				lineNumber: lineNumber);
		}
	}

	/// <summary>
	/// Ensures that the collection is not <c>null</c> and contains at least one element.
	/// </summary>
	/// <typeparam name="T">The type of elements in the collection.</typeparam>
	/// <param name="collection">The collection to check.</param>
	/// <param name="paramName">The name of the parameter for the error message.</param>
	/// <param name="fileName">The full path of the source file that contains the caller. Automatically populated by the runtime.</param>
	/// <param name="methodName">The name of the method or property that invoked the exception. Automatically populated by the runtime.</param>
	/// <param name="lineNumber">The line number in the source file at which the exception was thrown. Automatically populated by the runtime.</param>
	/// <exception cref="ArgException">Thrown if the collection is <c>null</c> or empty.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void NotEmpty<T>(
		IEnumerable<T> collection,
		string paramName,
		[CallerFilePath] string fileName = "",
		[CallerMemberName] string methodName = "",
		[CallerLineNumber] int lineNumber = 0)
	{
		if (collection == null || !collection.Any())
		{
			throw new ArgException(
				paramName,
				"Collection cannot be null or empty.",
				fileName: fileName,
				methodName: methodName,
				lineNumber: lineNumber);
		}
	}

	/// <summary>
	/// Ensures that the collection does not contain <c>null</c> elements.
	/// </summary>
	/// <typeparam name="T">The type of elements in the collection (must be a reference type).</typeparam>
	/// <param name="collection">The collection to check.</param>
	/// <param name="paramName">The name of the parameter for the error message.</param>
	/// <param name="fileName">The full path of the source file that contains the caller. Automatically populated by the runtime.</param>
	/// <param name="memberName">The name of the method or property that invoked the exception. Automatically populated by the runtime.</param>
	/// <param name="lineNumber">The line number in the source file at which the exception was thrown. Automatically populated by the runtime.</param>
	/// <exception cref="ArgException">Thrown if the collection contains any <c>null</c> elements.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void NoNullElements<T>(
		IEnumerable<T> collection,
		string paramName,
		[CallerFilePath] string fileName = "",
		[CallerMemberName] string memberName = "",
		[CallerLineNumber] int lineNumber = 0)
		where T : class
	{
		if (collection.Any(item => item == null))
		{
			throw new ArgException(
				paramName,
				"Collection cannot contain null elements.",
				fileName: fileName,
				methodName: memberName,
				lineNumber: lineNumber);
		}
	}

	/// <summary>
	/// Throws an <see cref="InvOpException"/>, indicating an invalid operation.
	/// </summary>
	/// <param name="message">The error message that explains the reason for the exception.</param>
	/// <param name="fileName">The full path of the source file that contains the caller. Automatically populated by the runtime.</param>
	/// <param name="methodName">The name of the method or property that invoked the exception. Automatically populated by the runtime.</param>
	/// <param name="lineNumber">The line number in the source file at which the exception was thrown. Automatically populated by the runtime.</param>
	/// <exception cref="InvOpException">Always thrown when this method is called.</exception>
	/// <remarks>
	/// This method is used in situations where the execution reaches a point that is considered invalid.
	/// For example, if the program logic should not allow reaching a specific state, this method can be used
	/// to explicitly indicate an error.
	/// </remarks>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void InvalidOperation(
		string message,
		[CallerFilePath] string fileName = "",
		[CallerMemberName] string methodName = "",
		[CallerLineNumber] int lineNumber = 0)
	{
		throw new InvOpException(message,
			fileName: fileName,
			methodName: methodName,
			lineNumber: lineNumber);
	}
}

}