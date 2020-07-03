using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScreenModeDropdown : MonoBehaviour {
    TMP_Dropdown _dropdown;
    Dictionary<string, FullScreenMode> screenModes = new Dictionary<string, FullScreenMode>();

    // Start is called before the first frame update
    void Start() {

        //Customize your available screen modes here
        //The main thing to customize being the labels for them!
        
         /* Enums
         * ExclusiveFullScreen	Exclusive Mode.
         * FullScreenWindow	    Fullscreen window.
         * MaximizedWindow   	Maximized window.
         * Windowed	            Windowed.
         */
        screenModes.Add("Exclusive Fullscreen", FullScreenMode.ExclusiveFullScreen);
        screenModes.Add("Borderless", FullScreenMode.FullScreenWindow);
        screenModes.Add("Windowed", FullScreenMode.Windowed);

        _dropdown = GetComponentInChildren<TMP_Dropdown>();
        if (_dropdown == null) {
            Debug.Log("Could not find dropdown child!");
            return;
        }
       
        var currentScreenMode = Screen.fullScreenMode;
        var prefScreenMode = PlayerPrefs.GetInt("ScreenMode", (int) currentScreenMode);
        Screen.fullScreenMode = (FullScreenMode) prefScreenMode;
        List<string> screenModeOptions = new List<string>();
        
        int index = 0;
        int selectedScreenModeOption = 0;
        foreach(var option in screenModes) {
            screenModeOptions.Add(option.Key);

            if ( (int) option.Value == prefScreenMode) {
                selectedScreenModeOption = index;
            }
            index++;
        }
        
        _dropdown.ClearOptions();
        _dropdown.AddOptions(screenModeOptions);
        _dropdown.SetValueWithoutNotify(selectedScreenModeOption);

        _dropdown.onValueChanged.AddListener(delegate (int choice) { ApplyScreenMode(choice); } );
    }

    // Update is called once per frame
    void Update() {
        
    }

    void ApplyScreenMode(int choice) {
        var screenModeKey = _dropdown.options[choice].text;
        var screenMode = screenModes[screenModeKey];
        Screen.fullScreenMode = screenMode;
        PlayerPrefs.SetInt("ScreenMode", (int) screenMode);
    }
}
