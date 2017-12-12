using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Xml;

public class TestPanel : MonoBehaviour {
    private ModalPanel modalPanel;
    public Text testText;

    private UnityAction okAction;
    private XmlDocument xmlDocument;
    private List<string> advices = new List<string>();

    private static TestPanel testPanel;

    public TestPanel()
    {
        xmlDocument = new XmlDocument();
        xmlDocument.Load("Assets\\advices.xml");
        XmlNode list = xmlDocument.FirstChild;
        if (list.HasChildNodes)
        {
            for (int i = 0; i < list.ChildNodes.Count; i++)
            {
                advices.Add(list.ChildNodes[i].InnerText);
            }
        }
    }

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
        modalPanel.OkChoice(advices[0],okAction);
    }

    void TestOkFunction()
    {
        testText.text = "Naciśnięto OK";
        
    }
}
