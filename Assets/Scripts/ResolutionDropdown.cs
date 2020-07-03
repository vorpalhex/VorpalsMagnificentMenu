using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResolutionDropdown : MonoBehaviour {
    TMP_Dropdown _dropdown;

    // Start is called before the first frame update
    void Start() {
        _dropdown = GetComponentInChildren<TMP_Dropdown>();
        if (_dropdown == null) {
            Debug.Log("Could not find dropdown child!");
            return;
        }

        var currentResolution = Screen.currentResolution;
        var prefResolution = PlayerPrefs.GetString("Resolution", currentResolution.ToString());
        var parsedPrefResolution = ResolutionStringToResolution(prefResolution);
        Screen.SetResolution(parsedPrefResolution.width, parsedPrefResolution.height, Screen.fullScreenMode, parsedPrefResolution.refreshRate);

        Resolution[] resolutions = Screen.resolutions;
        List<string> resolutionOptions = new List<string>();

        int currentResolutionIndex = 0;
        int index = 0;
        foreach(var resolution in resolutions) {
            var resString = ResolutionToString(resolution);
            resolutionOptions.Add(resString);
            if (resString == prefResolution) {
                currentResolutionIndex = index;
            }
            index++;
        }

        _dropdown.ClearOptions();
        _dropdown.AddOptions(resolutionOptions);
        _dropdown.SetValueWithoutNotify(currentResolutionIndex);

        _dropdown.onValueChanged.AddListener(delegate (int choice) { ApplyResolution(choice); } );
    }

    // Update is called once per frame
    void Update() {
        
    }

    String ResolutionToString(Resolution res) {
        return $"{res.width}x{res.height}";
    }

    Resolution ResolutionStringToResolution(string resolutionString) {
        //"width x height @ refreshRateHz"
        var resParts = resolutionString.Split('x');
        int width = Int32.Parse(resParts[0].Trim());
        int height = Int32.Parse(resParts[1].Trim());
        int refreshRate = Screen.currentResolution.refreshRate;

        return new Resolution {width=width, height=height, refreshRate=refreshRate};
    }

    void ApplyResolution(int choice) {
        var newResolution = _dropdown.options[choice].text;
        PlayerPrefs.SetString("Resolution", newResolution);
        var parsedRes = ResolutionStringToResolution(newResolution);
        Screen.SetResolution(parsedRes.width, parsedRes.height, Screen.fullScreenMode, parsedRes.refreshRate);
    }
}
