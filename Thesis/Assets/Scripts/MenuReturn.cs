using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuReturn : MonoBehaviour {

    public Button returnButton;
	// Use this for initialization
	void Start () {
        returnButton.onClick.RemoveAllListeners();
        returnButton.onClick.AddListener(Return);
    }
	
    void Return ()
    {
        SceneManager.LoadScene("startingScene");
    }
}
