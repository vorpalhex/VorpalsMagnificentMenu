using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelLoader : MonoBehaviour {
    // Start is called before the first frame update
    public bool isBackButton = false;
    public GameObject panelTarget;
    PanelManager _PanelManager;

    void Start() {
        var PanelManagerContainer = GameObject.Find("PanelManager");
        _PanelManager = PanelManagerContainer.GetComponent<PanelManager>();

        if (_PanelManager == null) {
            Debug.Log("Could not find PanelManager");
        }
        var thisButton = GetComponent<Button>();
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
        if (isBackButton) {
            _PanelManager.LoadPreviousPanel();
        } else if(panelTarget != null) { 
            _PanelManager.LoadPanel(panelTarget.name);
        } else {
            Debug.Log("No panel name and not configured as a back button!");
        }
    }
}
