using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuReturn : MonoBehaviour {

    public Button returnButton;

	private void Start () {
        returnButton.onClick.RemoveAllListeners();
        returnButton.onClick.AddListener(Return);
    }
	
    private void Return ()
    {
        SceneManager.LoadScene("startingScene");
    }
}
