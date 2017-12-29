using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public Button startButton;
    public Button highscoresButton;
    public Button exitButton;
    // Use this for initialization
    void Start () {
        startButton.onClick.RemoveAllListeners();
        startButton.onClick.AddListener(ToCharacterChoice);
        highscoresButton.onClick.RemoveAllListeners();
        highscoresButton.onClick.AddListener(ToHighscores);
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(Exit);
	}
	
    private void ToHighscores()
    {
        SceneManager.LoadScene("highscoresScene");
    }

    private void ToCharacterChoice()
    {
        SceneManager.LoadScene("chooseCharacterScene");
    }

    private void Exit()
    {
        Application.Quit();
    }
}
