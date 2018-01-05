using UnityEngine;

public class Cookie : MonoBehaviour {

    public float leftZ = 0;
    public float rightZ = 0;
    private bool leftDirection = true;
    private float rotation = 5;
    private float position = 0.25f;
	
	void Update () {
        
        if (transform.position.z > (leftZ+1) && leftDirection)
        {
            transform.position += new Vector3(0, 0, -position) * Time.timeScale;
            transform.Rotate(new Vector3(0, -rotation, 0) * Time.timeScale);
        }
        else
        {
            leftDirection = false;
        }

        if (transform.position.z<(rightZ-1) && !leftDirection)
        {
            transform.position += new Vector3(0, 0, position) * Time.timeScale;
            transform.Rotate(new Vector3(0, rotation, 0) * Time.timeScale);
        }
        else
        {
            leftDirection = true;
        }
        
    }
}
