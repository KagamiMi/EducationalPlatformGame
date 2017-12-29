using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour {

    public float leftZ = 0;
    public float rightZ = 0;
    private bool leftDirection = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (transform.position.z > (leftZ+1) && leftDirection)
        {
            transform.position += new Vector3(0, 0, -0.25f) * Time.timeScale;
            transform.Rotate(new Vector3(0, -5, 0) * Time.timeScale);
        }
        else
        {
            leftDirection = false;
        }

        if (transform.position.z<(rightZ-1) && !leftDirection)
        {
            transform.position += new Vector3(0, 0, 0.25f) * Time.timeScale;
            transform.Rotate(new Vector3(0, 5, 0) * Time.timeScale);
        }
        else
        {
            leftDirection = true;
        }
        
    }
}
