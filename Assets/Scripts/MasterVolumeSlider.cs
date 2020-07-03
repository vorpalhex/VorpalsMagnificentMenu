using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MasterVolumeSlider : MonoBehaviour {
    Slider _slider;

    // Start is called before the first frame update
    void Start() {
        _slider = GetComponentInChildren<Slider>();
        if (_slider == null) {
            Debug.Log("Could not find slider child!");
            return;
        }
     
        //first apply volume from prefs
        var masterVol = PlayerPrefs.GetFloat("MasterVolume", 1f);
        _slider.SetValueWithoutNotify(masterVol);
        //AudioListener.volume = masterVol > 0.01 ? Mathf.Log10(masterVol) * 20 : 0;
        AudioListener.volume = masterVol;
        //now set our listener
        _slider.onValueChanged.AddListener(ApplyVolume);

    }

    // Update is called once per frame
    void Update() {
        
    }

    void ApplyVolume(float newVol) {
        AudioListener.volume = newVol;
        //AudioListener.volume = newVol > 0.01 ? Mathf.Log10(newVol) * 20 : 0;
        PlayerPrefs.SetFloat("MasterVolume", newVol);
    }
}
