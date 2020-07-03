using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour {
    public GameObject[] panels;
    public int initialPanel = 0;

    GameObject _lastPanel;
    GameObject _activePanel;

    // Start is called before the first frame update
    void Start() {
        foreach (GameObject panel in panels) {
            panel.SetActive(false);
        }
        _activePanel = panels[initialPanel];
        _activePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        
    }

    GameObject GetPanelByName(string name) {
        foreach (GameObject panel in panels) {
            if ( panel.name == name ) {
                return panel;                
            }
        }

        return null;
    }

    public void LoadPanel(string panelName) {
        GameObject nextPanel = GetPanelByName(panelName);

        if ( nextPanel != null) {
            _lastPanel = _activePanel;
            nextPanel.SetActive(true);
            _activePanel.SetActive(false);
            _activePanel = nextPanel;
        } else {
            Debug.Log("Asked to navigate to bad panel: " + panelName);
        }   
    }

    public void LoadPreviousPanel() {
        if (_lastPanel != null) {
            var nextPanel = _lastPanel;
            _lastPanel = _activePanel;
            _activePanel = nextPanel;
            _activePanel.SetActive(true);
            _lastPanel.SetActive(false);
        } else {
            Debug.Log("Asked to go back but have no last panel");
        }
    }

}
