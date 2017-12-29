using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterChoice : MonoBehaviour {

    public Text name;

    private void OnMouseOver()
    {
        name.enabled = true;
        if (Input.GetMouseButtonDown(0))
        {
            PlayerPrefs.SetString("character",name.text);
            SceneManager.LoadScene("gameScene");

        }
    }

    private void OnMouseExit()
    {
        name.enabled = false;
    }

    // Use this for initialization
    void Start () {
        name.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
