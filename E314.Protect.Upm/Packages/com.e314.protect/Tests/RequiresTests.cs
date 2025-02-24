using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using E314.Exceptions;
using NUnit.Framework;

namespace E314.Protect.Tests
{

internal sealed class RequiresTests
{
	[Test]
	public void Requires_NotException()
	{
		// Arrange
		var list = new List<object> { new() };

		// Act & Assert
		Assert.DoesNotThrow(() => Requires.NotNull(new object(), string.Empty));
		Assert.DoesNotThrow(() => Requires.NotEmpty("text", string.Empty));
		Assert.DoesNotThrow(() => Requires.InRange(0, 0, 3, string.Empty));
		Assert.DoesNotThrow(() => Requires.InRange(3, 0, 3, string.Empty));
		Assert.DoesNotThrow(() => Requires.InRange(2, 0, 3, string.Empty));
		Assert.DoesNotThrow(() => Requires.Ensure(true, string.Empty));
		Assert.DoesNotThrow(() => Requires.NotEmpty(list, string.Empty));
		Assert.DoesNotThrow(() => Requires.NoNullElements(list, string.Empty));
		Assert.DoesNotThrow(() => Requires.NotDisposed(false));
	}

	[Test]
	[SuppressMessage("ReSharper", "CollectionNeverUpdated.Local")]
	public void Requires_Exception()
	{
		// Arrange
		var emptyList = new List<object>();
		var nullElementList = new List<object> { null };

		// Act & Assert
		Assert.Throws<ArgNullException>(() => Requires.NotNull(null, string.Empty));
		Assert.Throws<ArgException>(() => Requires.NotEmpty(null, string.Empty));
		Assert.Throws<ArgException>(() => Requires.NotEmpty("", string.Empty));
		Assert.Throws<ArgException>(() => Requires.NotEmpty(" ", string.Empty));
		Assert.Throws<ArgOutOfRangeException>(() => Requires.InRange(-1, 0, 3, string.Empty));
		Assert.Throws<ArgOutOfRangeException>(() => Requires.InRange(4, 0, 3, string.Empty));
		Assert.Throws<InvOpException>(() => Requires.Ensure(false, string.Empty));
		Assert.Throws<ArgException>(() => Requires.NotEmpty(emptyList, string.Empty));
		Assert.Throws<ArgException>(() => Requires.NoNullElements(nullElementList, string.Empty));
		Assert.Throws<InvOpException>(() => Requires.InvalidOperation(string.Empty));
		Assert.Throws<ObjDisposedException>(() => Requires.NotDisposed(true));
	}
}

}