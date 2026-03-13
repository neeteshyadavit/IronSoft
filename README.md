# Old Phone Pad Decoder

This project converts input from an old phone keypad into readable text.

## Features

- Multi-press keypad decoding
- Pause detection using space
- Backspace using *
- End of message using #

## Keypad Layout

2 → ABC  
3 → DEF  
4 → GHI  
5 → JKL  
6 → MNO  
7 → PQRS  
8 → TUV  
9 → WXYZ  

## Examples

Input:
33#

Output:
E

Input:
4433555 555666#

Output:
HELLO

## Running the Project

dotnet build  
dotnet run

## Running Tests

dotnet test
