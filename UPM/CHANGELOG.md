# CHANGELOG

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0] - 2025-03-21

### Changed

- The `[CallerFilePath] string fileName` parameter has been replaced with `object obj`.

## [2.1.1] - 2025-03-03

### Fixed

- Fix .asmdef names

## [2.1.0] - 2025-02-24

### Added

- `Requires.NotDisposed`: Throws a `ObjDisposedException`, indicating an attempt to use the object after it has been released.

## [2.0.0] - 2025-02-22

Migration to `E314.Exceptions`

### Breaking Changes

- The E314.Require module has been updated to use custom exceptions from the `E314.Exceptions` module instead of System.Exception. This change impacts how exceptions are thrown and handled.
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
