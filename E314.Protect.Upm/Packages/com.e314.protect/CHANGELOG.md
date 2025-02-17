# CHANGELOG

## [1.0.0] - 2025-02-14

First stable release of `E314.Protect`.

### Added

- Static utility class `Requires` for validating method arguments and object states. Throws descriptive exceptions when validation fails.
  - `NotNull`: Validates that a parameter is not `null`.
  - `NotEmpty`: Validates that strings or collections are not empty.
  - `InRange`: Validates that numeric values are within a specified range.
  - `Ensure`: Validates that a given condition is true.
  - `NoNullElements`: Validates that collections do not contain `null` elements.
