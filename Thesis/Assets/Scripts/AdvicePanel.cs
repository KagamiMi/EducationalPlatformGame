using UnityEngine;
using UnityEngine.UI;

public class AdvicePanel : MonoBehaviour {

    public Text advice;
    public Button okButton;
    public GameObject panel;
    private XmlData xmlData = new XmlData();

    private void Start ()
    {
        okButton.onClick.RemoveAllListeners();
        okButton.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel ()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ActivatePanel ()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        this.advice.text = xmlData.NextAdvice();
    }
}
