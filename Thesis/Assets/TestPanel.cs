using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestPanel : MonoBehaviour {
    private ModalPanel modalPanel;
    public Text testText;

    private UnityAction okAction;

    private static TestPanel testPanel;
    public static TestPanel Instance()
    {
        if (!testPanel)
        {
            testPanel = FindObjectOfType(typeof(TestPanel)) as TestPanel;
            if (!testPanel)
            {
                Debug.LogError("No active TestPanel!");
            }
        }
        return testPanel;
    }

    void Awake()
    {
        modalPanel = ModalPanel.Instance();

        okAction = new UnityAction(TestOkFunction);
    }

    public void Test()
    {
        modalPanel.OkChoice("Click OK",okAction);
    }

    void TestOkFunction()
    {
        testText.text = "Naciśnięto OK";
        
    }
}
