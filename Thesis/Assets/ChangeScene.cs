using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public Button startButton;
    // Use this for initialization
    void Start () {
        startButton.onClick.RemoveAllListeners();
        startButton.onClick.AddListener(Change);
	}
	
    private void Change()
    {
        SceneManager.LoadScene("chooseCharacterScene");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
