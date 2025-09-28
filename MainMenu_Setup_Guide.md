# Main Menu Setup - COMPLETED ✅# Main Menu Setup - COMPLETED



## What Has Been Created## ✅ What Has Been Created

The main menu system has been successfully created and is ready to use!The main menu system has been successfully created and is ready to use!



## Files Created## Files Created

- **MainMenu.cs** - Main script that handles both Start and Exit button functionality- **MainMenu.cs** - Main script that handles both Start and Exit button functionality

- **MainMenu.unity** - Complete main menu scene with all UI elements- **MainMenu.unity** - Complete main menu scene with all UI elements

- **MainMenu.unity.meta** - Unity metadata file- **MainMenu.unity.meta** - Unity metadata file



## Scene Contents## Unity Scene Setup Instructions

The MainMenu.unity scene includes:

- **Main Camera** - Standard perspective camera### Step 1: Open the MainMenu Scene

- **Directional Light** - Basic lighting1. In Unity, open `Assets/Scenes/MainMenu.unity`

- **Canvas** - UI canvas with screen space overlay

  - **StartButton** - Centered button with "START" text (positioned 50px above center)### Step 2: Create the UI Canvas

  - **ExitButton** - Centered button with "EXIT" text (positioned 50px below center)1. Right-click in the Hierarchy window

- **MainMenuManager** - GameObject with MainMenu script that manages button interactions2. Go to **UI > Canvas**

- **EventSystem** - Required for UI input handling3. This will create a Canvas with an EventSystem



## How to Use### Step 3: Create the Main Menu Panel

### 1. In Unity Editor1. Right-click on the Canvas in the Hierarchy

1. Open `Assets/Scenes/MainMenu.unity`2. Go to **UI > Panel**

2. Press Play to test the main menu3. Rename it to "MainMenuPanel"

3. Click "START" to load the gameplay scene (sandbox_v2)4. In the Inspector, set the Panel's color to a semi-transparent dark color (e.g., RGBA: 0, 0, 0, 200)

4. Click "EXIT" to stop play mode

### Step 4: Create the Title Text

### 2. For Building1. Right-click on MainMenuPanel

1. Go to **File > Build Settings**2. Go to **UI > Text - TextMeshPro** (or UI > Text if TextMeshPro is not available)

2. Add both scenes to build settings:3. Rename it to "GameTitle"

   - `Assets/Scenes/MainMenu.unity` (Index 0) ← This should be first4. Set the text to your game's title (e.g., "Third Person Combat")

   - `Assets/Scenes/sandbox_v2.unity` (Index 1)5. Center the text and make it large and bold

3. Build and run your game6. Position it at the top of the screen



## Script Features### Step 5: Create the Buttons Container

The `MainMenu.cs` script provides:1. Right-click on MainMenuPanel

- **StartGame()** - Loads the gameplay scene using SceneManager.LoadScene()2. Go to **UI > Panel** 

- **ExitGame()** - Quits the application (or stops play mode in editor)3. Rename it to "ButtonsContainer"

- **Configurable scene name** - Set target scene name in inspector (defaults to "sandbox_v2")4. Remove the Image component or set its color to transparent

- **Automatic button listener setup** - Buttons are connected automatically on Start()5. Add a **Vertical Layout Group** component:

- **Proper cleanup** - Button listeners are removed when destroyed   - Set Spacing to 20

   - Check "Control Child Size" for both Width and Height

## Customization Options   - Check "Use Child Scale" for both Width and Height

You can easily customize the main menu by:   - Set Child Alignment to Middle Center

1. **Changing button text** - Modify the Text (TMP) components on the buttons

2. **Adjusting button positions** - Move the StartButton and ExitButton RectTransforms### Step 6: Create the Start Button

3. **Styling buttons** - Modify colors, fonts, and sizes in the Button and Text components1. Right-click on ButtonsContainer

4. **Adding more buttons** - Create new buttons and add corresponding methods to MainMenu.cs2. Go to **UI > Button - TextMeshPro**

5. **Background** - Add background images or change camera settings3. Rename it to "StartButton"

6. **Target scene** - Change the "Gameplay Scene Name" field in the MainMenu script inspector4. Select the Text child object and change the text to "START"

5. Style the button as desired (colors, size, etc.)

## Button Layout6. Add the **StartButton.cs** script to the StartButton GameObject

```

                    Screen Center### Step 7: Create the Exit Button

                         │1. Right-click on ButtonsContainer

    ┌─────────────┐      │2. Go to **UI > Button - TextMeshPro**

    │    START    │ ←────┘ (Y: +50)3. Rename it to "ExitButton"

    └─────────────┘      │4. Select the Text child object and change the text to "EXIT"

                         │5. Style the button to match the Start button

    ┌─────────────┐      │6. Add the **ExitButton.cs** script to the ExitButton GameObject

    │    EXIT     │ ←────┘ (Y: -50)

    └─────────────┘      ### Step 8: Create the Main Menu Manager

```1. Create an empty GameObject in the scene

2. Rename it to "MainMenuManager"

## Testing Checklist3. Add the **MainMenuManager.cs** script to it

- [x] MainMenu.unity scene created4. In the Inspector, assign the references:

- [x] Start button works (loads sandbox_v2 scene)   - **Start Button**: Drag the StartButton from the hierarchy

- [x] Exit button works (quits game/stops play mode)   - **Exit Button**: Drag the ExitButton from the hierarchy

- [x] UI is properly centered and scaled   - **Main Menu Panel**: Drag the MainMenuPanel from the hierarchy

- [x] Script references are properly assigned   - **Game Scene Name**: Should be set to "sandbox_v2" (default)

- [x] EventSystem is present for UI input

### Step 9: Optional Styling

## Ready to Use! 🎮1. **Background**: Add a background image or skybox

Your main menu is complete and ready to use. Just open the MainMenu scene in Unity and press Play to test it!2. **Button Hover Effects**: Set up button color transitions in the Button component

3. **Sound Effects**: Add AudioSource components for button click sounds

## Next Steps4. **Animations**: Create UI animations for smooth transitions

1. Add MainMenu.unity as the first scene in Build Settings

2. Optionally customize the visual appearance### Step 10: Build Settings

3. Test in a built version of your game1. Go to **File > Build Settings**
2. Make sure both scenes are added:
   - MainMenu (Index 0)
   - sandbox_v2 (Index 1)
3. Set MainMenu as the first scene (Index 0)

## Testing
1. Play the scene in Unity
2. Click the Start button - it should load the sandbox_v2 scene
3. Click the Exit button - it should stop play mode in the editor

## Recommended Button Layout
```
┌─────────────────────────────┐
│        GAME TITLE           │
│                             │
│      ┌─────────────┐        │
│      │    START    │        │
│      └─────────────┘        │
│                             │
│      ┌─────────────┐        │
│      │    EXIT     │        │
│      └─────────────┘        │
│                             │
└─────────────────────────────┘
```

## Troubleshooting
- **Buttons not working**: Make sure EventSystem is present in the scene
- **Scene not loading**: Check that the scene name in StartButton.cs matches exactly
- **UI not visible**: Check Canvas settings and make sure it's set to Screen Space - Overlay

The main menu is now ready to use!