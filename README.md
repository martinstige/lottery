# Lottery Drawing App 🎰

A fun and exciting command-line lottery drawing application built with .NET 10.

## Features

- 🎲 Random winner selection from a list of names
- ✨ Animated drawing process with visual effects
- 🎉 Celebratory winner announcement
- 🎨 Colorful console output
- ⚡ Fast and easy to use

## Requirements

- .NET 10.0 SDK or later

## Building the Application

Navigate to the LotteryApp directory and build:

```bash
cd LotteryApp
dotnet build
```

## Usage

Run the application with a list of names as command-line arguments:

```bash
dotnet run -- <name1> <name2> <name3> ...
```

### Examples

Draw a winner from 3 participants:
```bash
dotnet run -- Alice Bob Charlie
```

Draw a winner from multiple participants:
```bash
dotnet run -- Alice Bob Charlie Diana Eve Frank George Hannah
```

### Publishing a Standalone Executable

To create a standalone executable:

```bash
cd LotteryApp
dotnet publish -c Release -r win-x64 --self-contained
```

Replace `win-x64` with your target platform:
- `win-x64` for Windows 64-bit
- `linux-x64` for Linux 64-bit
- `osx-x64` for macOS 64-bit

The executable will be in `bin/Release/net10.0/[platform]/publish/`

## How It Works

1. The app displays all participants
2. Press ENTER to start the drawing
3. Watch the exciting animation as names spin through
4. The winner is revealed with a celebration message!

## Error Handling

If no names are provided, the app will display usage instructions and exit.
