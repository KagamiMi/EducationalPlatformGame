using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalPanel : MonoBehaviour {

    public Text advice;
    //public Image icon;
    public Button okButton;
    public GameObject panel;

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
            {
                Debug.LogError("No active ModalPanel!");
            }
        }
        return modalPanel;
    }

    public void OkChoice(string advice, UnityAction okEvent)
    {
        panel.SetActive(true);

        okButton.onClick.RemoveAllListeners();
        okButton.onClick.AddListener(okEvent);
        okButton.onClick.AddListener(ClosePanel);

        this.advice.text = advice;
        //this.icon.gameObject.SetActive(false);
        this.okButton.gameObject.SetActive(true);
    }

    void ClosePanel()
    {
        panel.SetActive(false);
        
    }

}
