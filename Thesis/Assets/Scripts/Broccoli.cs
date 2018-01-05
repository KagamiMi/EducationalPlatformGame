using UnityEngine;

public class Broccoli : MonoBehaviour {
	private void Update ()
    {
        transform.Rotate(new Vector3(0,0,1)*Time.timeScale);
	}
}
