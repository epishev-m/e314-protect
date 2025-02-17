# E314.Protect

## Description

The `E314.Protect` module provides methods for validating input data and conditions.
It prevents errors caused by invalid data by throwing exceptions with informative messages.

## Content tree

- [E314.Protect](#e314protect)
  - [Description](#description)
  - [Content tree](#content-tree)
  - [Requires](#requires)
    - [Method Parameter Validation](#method-parameter-validation)
    - [Object State Validation](#object-state-validation)
    - [Collection Validation](#collection-validation)
    - [Combined Validations](#combined-validations)
    - [Exception Handling](#exception-handling)

## Requires

Static class `Requires` provides methods for validating input data and conditions. If a check fails, a corresponding exception is thrown.

### Method Parameter Validation

Use the `NotNull`, `NotEmpty`, and `InRange` methods to validate input parameters in public methods.

When to use:

- `NotNull`: If a parameter must not be `null`. Example: objects, strings, or collections.
- `NotEmpty`: If a string or collection must not be empty. Example: username, list of items.
- `InRange`: If a numeric value must fall within a specific range. Example: health level, progress.

```csharp
public void SetPlayerName(string name)
{
    Requires.NotEmpty(name, nameof(name));
    ...
}

public void SetHealth(int health)
{
    Requires.InRange(health, 0, 100, nameof(health));
    // ...
}
```

### Object State Validation

Use the 'Ensure' method to check the internal state of an object before performing operations.

When to use:

- If a method depends on prior initialization of the object.
- If you need to ensure that the object is in the correct state.

```csharp
public void PerformAction()
{
    Requires.Ensure(IsInitialized, "Object must be initialized before use.");
    // ...
}
```

### Collection Validation

Use the `NotEmpty` and `NoNullElements` methods to validate collections.

When to use:

- `NotEmpty`: If a collection must contain at least one element. Example: player list, inventory.
- `NoNullElements`: If a collection must not contain `null` elements. Example: active tasks, objects.

```csharp
public void ProcessItems(IEnumerable<string> items)
{
    Requires.NotEmpty(items, nameof(items));
    Requires.NoNullElements(items, nameof(items)); 
    // ...
}
```

### Combined Validations

For complex methods, you can combine multiple validations to ensure all input data is correct.

When to use:

- If a method accepts multiple parameters, each requiring its own validation.

```csharp
public void InitializeGame(string playerName, int level, IEnumerable<string> inventory)
{
    Requires.NotEmpty(playerName, nameof(playerName));
    Requires.InRange(level, 1, 50, nameof(level));
    Requires.NotEmpty(inventory, nameof(inventory));
    Requires.NoNullElements(inventory, nameof(inventory));
    // ...
}
```

### Exception Handling

Add a `try-catch` block to handle exceptions thrown by the `Requires` methods.

When to use:

- If a method may throw an exception and you need to provide the user with a clear message.

```csharp
try
{
    SetPlayerName("");
}
catch (ArgumentException ex)
{
    Debug.LogError($"Error: {ex.Message}");
}
// ...
```
