# Old Phone Key Pad

A simple console module that converts sequences of old mobile phone keypad presses into text using multi-tap input rules.

- Target framework: .NET 9
- Entry point: Program.cs calls OldPhoneKeyPad.Process()

## How it works

The input is a sequence of digits and special characters that simulates pressing keys on an old phone keypad:

- Digits 0–9 map to characters:
  - 0 → space
  - 1 → symbols: & ' (
  - 2 → ABC
  - 3 → DEF
  - 4 → GHI
  - 5 → JKL
  - 6 → MNO
  - 7 → PQRS
  - 8 → TUV
  - 9 → WXYZ
- Repeating the same digit cycles through the letters on that key. For example, pressing 2 once selects A, twice selects B, three times selects C.
- A space character acts as a delay/break between keys. It separates groups of the same digit presses.
- (asterisk) acts as backspace and removes the last output character.

Input must end with #. Invalid input (missing #) is rejected.

## Usage

Run the app and enter a sequence when prompted:

- Example: `44 444 44666#` → `HIHO`
  - 44 → H
  - 444 → I
  - 44 → H 
  - 666 → O
  - End on #
- Example: `8 88777444666*664#` → `TURING`
	- 8 → T
	- 88 → U
	- 777 → R
	- 444 → I
	- 666 → O, Then * Backspace removes O
	- 66 → N
	- 4 → G
	- End on #

Notes:
- Spaces only separate presses; they do not produce output except when pressing the digit 0 which maps to a space.
- If the number of presses exceeds the letter count on a key, it wraps around (modulo behavior).

## Running locally

1. Ensure .NET 9 SDK is installed.
2. From the solution directory, run:
   - `dotnet build`
   - `dotnet run --project CodingChallenge/CodingChallenge.csproj`
3. Follow the console prompt and enter your keypad sequence ending with `#`.

## Code structure

- CodingChallenge/Program.cs: Starts the interactive loop.
- CodingChallenge/Modules/OldPhoneKeyPad.cs: Conversion logic and input validation.

## Limitations

- Input is processed linearly and stops at `#`.
- Only digits, spaces, `*`, and `#` are recognized; other characters are ignored.
- Key `1` maps to `&'(` as configured; this can be adjusted in code if needed.
