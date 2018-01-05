using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject girlCharacter;
    public GameObject boyCharacter;
    private GameObject character;
    private Vector3 distance;
	
	private void Start ()
    {
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
	
	
	private void LateUpdate ()
    {
        transform.position = character.transform.position + distance;
	}
}
