# Main Menu Setup

This project now includes a Main Menu scene with the following features:

## Main Menu Scene
- **Location**: `Assets/Scenes/MainMenu.unity`
- **Contains**: 
  - Start Button: Loads the gameplay scene (sandbox_v2)
  - Exit Button: Closes the application

## Scenes Setup
1. **MainMenu.unity** - The main menu scene with UI buttons
2. **sandbox_v2.unity** - The gameplay scene (copy of the original Sandbox scene)

## How to Use
1. Set `MainMenu.unity` as your first scene in Build Settings
2. The Start button will load `sandbox_v2.unity`
3. The Exit button will quit the application (works in builds, stops play mode in editor)

## Scripts
- **MainMenu.cs** - Handles the UI logic for the main menu buttons
  - Attached to the MainMenuManager GameObject in the MainMenu scene
  - References to the Start and Exit buttons are assigned in the inspector

## Build Settings
Both scenes have been added to the Build Settings:
1. MainMenu.unity (Index 0)
2. sandbox_v2.unity (Index 1)

The MainMenu scene should be set as the first scene to load when the game starts.