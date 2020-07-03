# Vorpal's Magnificent Menu

This is a menu system, including a basic start menu and an options menu. Should work on all PC systems but may not follow best practices for mobile games. This includes both example scenes you can use as is, or scripting tools you can use for your own custom built menus. This project is licensed under MIT (aside from the included assets) and may be used in both commercial and free games. 

## Usage

1. Import the package either by downloading and importing from disk, or [directly from git](https://docs.unity3d.com/Manual/upm-git.html).
2. Add 'MainMenu' to your build as the first scene
3. Make sure your first game scene is either scene 1, or adjust `Initial Scene` under Canvas>MainMenuPanel>PlayButton
4. Customize as needed, particulary audio, images and text.

### Advanced Usage

All scripts are in C# and will use Debug.Log to indicate problems that may arise. Scripts are generally written defensively and with clear variable names.

* PanelManager Script - This script is meant to show and hide panels. It takes an array of panels and will default to having panel 0 be the active one. It will only allow one panel to be active at a time and supports basic 'Back' functionality through the `LoadPreviousPanel()` call.
+ PanelLoader Script - Add this on top of a Unity button to call the PanelManager script. It expects the PanelManager script to be on a gameobject named "PanelManager". Buttons can load a panel by name or act as a blind back button.
+ QualityDropdown, ResolutionDropdown and ScreenModeDropdown - These scripts expect to have a TextMeshPro dropdown child and will grab the first dropdown child component. They will prefill the appropriate options for the platform and select the active option automatically. `ScreenModeDropdown` can be edited to rename the screen modes but I have attempted to choose obvious names that would be familar to most gamers. These scripts will load settings from PlayerPrefs and apply them if needed. Note that all resolution/screen/quality settings are applied automatically and instantly.
+ MasterVolumeSlider script - This script expects to have a Slider child and will grab the first slider child component. It will set the volume slider to the appropriate level and works by adjusting the AudioListener component available in the scene (regardless it's position). This method isn't ideal but avoids the need for Audio Mix groups and is relatively straightforward. Note that if your AudioListener does not persist between scenes, you will need to retrieve the set audio level from PlayerPrefs.
+ QuitGame - This script should be applied to a button and will quit the game on click.
+ LoadScene - This script should be applied to a button and will load the indicate scene by index. 

#### Player Prefs used

+ `MasterVolume` float 0f to 1f
+ `Quality` int aligns to QualityLevel
+ `Resolution` string in the form of WIDTHxHEIGHT such as 1920x1080. We always use the current refreshRate and screenMode. Utility functions for parsing/serializing Resolution objects are in `ResolutionDropdown` script.
+ `ScreenMode` int aligned to the FullScreenModes Enum object. You will need to cast this to set/get it with Screen.fullScreenMode, see the ScreenModeDropdown for examples.

#### Using your own Font

We ship with the public domain Monogram font which is a neutral pixel font. You may use this in your own games. If you wish to import your own font, note that we use TextMeshPro (TMP) fields and thus you will need to bring in your own TMP font for use. You can convert most fonts by using Window -> TextMesh Pro -> Font Asset Creator and selecting a valid character range such as ASCII. See [here](https://forum.unity.com/threads/use-other-fonts-in-textmesh-pro.527960/) for details and help.

## Included Assets

If you use the included music or font assets, please credit the following either by keeping the default credit footer intact or reproducing the credits alongside other game credits as appropriate.

### Menu Music

'50's Bit' by [Joshua McLean](https://joshua-mclean.itch.io) from the [FREE Music Pack 3: Chiptune](https://joshua-mclean.itch.io/free-music-pack-3) used in accordance with CCI 4.0 Attribution license. Please support the artist on [Patreon](https://www.patreon.com/JoshuaMcLean).

### Font

[Monogram](https://datagoblin.itch.io/monogram) by [DataGoblin](https://datagoblin.itch.io) used in accordance with CC0 1.0 Public Domain license. 

## License 

Please note the following does not extend to included assets mentioned in the **Included Assets** sections.

Copyright 2020 Vorpalhex

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.