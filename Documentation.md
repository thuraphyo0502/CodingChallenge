# Old Phone Keypad – Technical Documentation

## 1. Overview

This project implements an **old-style multi-tap phone keypad**.  
The user enters a sequence of numeric keypad presses (e.g., `777` meaning “R”), including special keys:

- `*` : Backspace  
- `(space)` : Delay / separator  
- `#` : End of input  

The application converts the keypad presses into text exactly as old phones worked.

---

## 2. Features

- Supports multi-tap keypad input (2 → A, 22 → B, 222 → C)  
- Accepts delays between characters  
- Backspace support (`*`)  
- Terminates input on `#`  
- Includes test cases covering typical, edge, and error scenarios

---

## 3. Project Structure

```
CodingChallenge/
│
├── CodingChallenge/ # Project file
│ └── Modules.cs/
│   └── OldPhoneKeyPad.cs # Conversion logic
│   └── Program.cs # Console runner
├── OldPhoneKeyPadTests/ # Test project file
│ └── Modules.cs/
│   └── OldPhoneKeyPadTests.cs # Unit tests
├── README.md # Basic overview & run instructions
├── Docs/ # Documentation folder
│ └── Documentation.cs/

```
---

## 4. Conversion Logic

### Class: `OldPhoneKeyPad`

#### 4.1 Keypad Mapping

The keypad is represented as:

| Key | Characters |
|-----|------------|
| 0   | " "        |
| 1   | "&'("      |
| 2   | "ABC"      |
| 3   | "DEF"      |
| 4   | "GHI"      |
| 5   | "JKL"      |
| 6   | "MNO"      |
| 7   | "PQRS"     |
| 8   | "TUV"      |
| 9   | "WXYZ"     |

The **index of the string equals the numeric key**.

---

## 5. API Documentation

### Method: `Process()`

- Starts the interactive console loop.  
- Responsibilities:  
  - Reads user input  
  - Validates input ends with `#`  
  - Prints converted output or an error message

### Method: `ConvertToText(string input)`

- Converts keypad presses to text.

**Parameters:**  
- `input`: A sequence of characters (`0–9`, `*`, ` `, `#`)  

**Returns:**  
- `string`: The decoded text

**Examples:**
- ConvertToText("44 444 44666#") → "HIHO"
- ConvertToText("2 22 222#") → "ABC"
- ConvertToText("8 88777444666*664#") → "TURING"

### Method: `IsValidInput(string input)`

- Validates that input ends with `#`.

### Method: `RemoveLastCharacter(ref StringBuilder)`

- Handles backspace functionality.

---

## 6. Test Coverage

The project contains **unit tests** validating the functionality of `OldPhoneKeyPad`.

### Common sequences
- `222 2 22#` → `CAB`  
- `33#` → `E`  
- `4433555 555666096667775553#` → `HELLO WORLD`  
- `44 444 44666#` → `HIHO`  

### Sequences with backspace
- `227*#` → `B`  
- `8 88777444666*664#` → `TURING`  

### Edge cases
- Empty string → returns empty string  
- Missing `#` → invalid input handled gracefully  

Tests are implemented using **xUnit** and follow **Arrange-Act-Assert** formatting.  
All test cases are located in `/OldPhoneKeyPadTests/Modules/OldPhoneKeyPadTests.cs`.

---

## 7. Assumptions

- Only one space is needed to separate different key presses.  
- Input must contain a final `#` symbol.  

---

## 8. Future Improvements

- Add error handling for invalid characters  
- Improve performance
- Convert class into a reusable NuGet package

---

## 9. Summary

This documentation describes the input logic, behavior, constraints, structure, and test coverage of the `OldPhoneKeyPad` project.
