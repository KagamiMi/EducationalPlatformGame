using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject girlCharacter;
    public GameObject boyCharacter;
    private GameObject character;
    private Vector3 distance;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetString("character") == girlCharacter.tag)
        {
            character = girlCharacter;
        }
        else
        {
            character = boyCharacter;
        }
        distance = transform.position - character.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = character.transform.position + distance;
	}
}
