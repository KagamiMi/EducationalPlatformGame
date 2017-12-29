using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ToScoreBoard : MonoBehaviour {

    public Button saveButton;
    public InputField name;
	// Use this for initialization
	void Start () {
        saveButton.onClick.RemoveAllListeners();
        saveButton.onClick.AddListener(ChangeScene);
	}
	
    void ChangeScene()
    {
        PlayerPrefs.SetString("name",name.text);
        SceneManager.LoadScene("highscoresScene");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
