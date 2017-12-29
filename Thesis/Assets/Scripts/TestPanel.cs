using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Xml;
using System.IO;

public class TestPanel : MonoBehaviour {
    private ModalPanel modalPanel;
    public Text testText;

    private UnityAction okAction;
    private XmlDocument xmlDocument;
    private List<string> advices = new List<string>();
    private List<int> indexes = new List<int>();
    private int adviceIndex = 0;
    private string advicesPath = "advices.xml";

    private static TestPanel testPanel;

    public TestPanel()
    {
        xmlDocument = new XmlDocument();
        //na razie assety nie sa budowane - wymyslic jak zrobic by byly
        //string filePath = Path.Combine(Application.streamingAssetsPath,advicesPath);
        //xmlDocument.Load(filePath);
        xmlDocument.Load("Assets\\advices.xml");
        XmlNode list = xmlDocument.FirstChild;
        if (list.HasChildNodes)
        {
            for (int i = 0; i < list.ChildNodes.Count; i++)
            {
                advices.Add(list.ChildNodes[i].InnerText);
                indexes.Add(i);
            }
        }

        //DurstenfeldShuffle
        System.Random random = new System.Random();
        for (int i = 0;i<(indexes.Count-1);i++)
        {
            int j = random.Next() % ((indexes.Count-1)-i) + i;
            int temp = indexes[i];
            indexes[i] = indexes[j];
            indexes[j] = temp;
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
        modalPanel.OkChoice(advices[indexes[adviceIndex]],okAction);
        if ((adviceIndex+1) < indexes.Count)
        {
            adviceIndex++;
        } 
        else
        {
            adviceIndex = 0;
        }
        
    }

    void TestOkFunction()
    {
        Time.timeScale = 1;
        // testText.text = "Naciśnięto OK";

    }
}
