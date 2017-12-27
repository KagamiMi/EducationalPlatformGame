using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndEnter : MonoBehaviour {

    public Text result;
    private void OnEnable()
    {
        result.text = PlayerPrefs.GetInt("points").ToString();
    }
}
