using UnityEngine;
using UnityEngine.UI;

public class EndEnter : MonoBehaviour {

    public Text result;

    private void Start ()
    {
        result.text = PlayerPrefs.GetInt("score").ToString();
    }
}
