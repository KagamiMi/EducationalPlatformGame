using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ToScoreBoard : MonoBehaviour {

    public Button saveButton;
    public InputField name;

	void Start () {
        saveButton.onClick.RemoveAllListeners();
        saveButton.onClick.AddListener(ChangeScene);
	}
	
    void ChangeScene ()
    {
        PlayerPrefs.SetString("name",name.text);
        SceneManager.LoadScene("highscoresScene");
    }
}
