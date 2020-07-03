using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public int initialScene = 1;
    Button thisButton;
    // Start is called before the first frame update
    void Start() {
        thisButton = GetComponent<Button>();
        if (thisButton != null) {
            thisButton.onClick.AddListener(OnClick);
        } else {
            Debug.Log("Woops, LoadScene needs to be on a Button!");
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnClick() {
        SceneManager.LoadScene(initialScene, LoadSceneMode.Single);
    }
}
