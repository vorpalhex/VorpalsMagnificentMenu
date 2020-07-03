using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QualityDropdown : MonoBehaviour {
    TMP_Dropdown _dropdown;

    // Start is called before the first frame update
    void Start() {
        _dropdown = GetComponentInChildren<TMP_Dropdown>();
        if (_dropdown == null) {
            Debug.Log("Could not find dropdown child!");
            return;
        }

        String[] qualities = QualitySettings.names;
        int activeQuality = QualitySettings.GetQualityLevel();
        int preferredQuality = PlayerPrefs.GetInt("Quality", activeQuality);
        QualitySettings.SetQualityLevel(preferredQuality, true);
        List<string> qualityOptions = new List<string>();

        foreach(var quality in qualities) {
            qualityOptions.Add(quality);
        }

        _dropdown.ClearOptions();
        _dropdown.AddOptions(qualityOptions);
        _dropdown.SetValueWithoutNotify(preferredQuality);

        _dropdown.onValueChanged.AddListener(delegate (int choice) { SetQuality(choice); } );
    }

    // Update is called once per frame
    void Update() {
        
    }

    void SetQuality(int choice) {
        PlayerPrefs.SetInt("Quality", choice);
        QualitySettings.SetQualityLevel(choice, true);
    }
}
