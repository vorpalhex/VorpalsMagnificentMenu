using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour {
    Button thisButton;
    // Start is called before the first frame update
    void Start() {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnClick() {
        Application.Quit(0);
    }
}
