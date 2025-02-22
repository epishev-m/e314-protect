# CHANGELOG

## [2.0.0] - 2025-02-22

Migration to E314.Exceptions

### Breaking Changes

- The E314.Require module has been updated to use custom exceptions from the E314.Exceptions module instead of System.Exception. This change impacts how exceptions are thrown and handled.
- Existing code that relies on catching System.Exception for validation errors will need to be updated to handle the new exception types ('ArgNullException', 'ArgOutOfRangeException', 'InvOpException, etc.).

## [1.0.0] - 2025-02-14

First stable release of `E314.Protect`.

### Added

- Static utility class `Requires` for validating method arguments and object states. Throws descriptive exceptions when validation fails.
  - `NotNull`: Validates that a parameter is not `null`.
  - `NotEmpty`: Validates that strings or collections are not empty.
  - `InRange`: Validates that numeric values are within a specified range.
  - `Ensure`: Validates that a given condition is true.
  - `NoNullElements`: Validates that collections do not contain `null` elements.
