using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class XmlData : MonoBehaviour {

    private XmlDocument xmlDocument;
    private static List<string> advices = new List<string>();

    private static XmlData xmlData;

    public void read()
    {
        xmlDocument = new XmlDocument();
        xmlDocument.Load("Assets\\advices.xml");
        XmlNode list = xmlDocument.FirstChild;
        if (list.HasChildNodes)
        {
            for (int i=0; i<list.ChildNodes.Count; i++)
            {
                advices.Add(list.ChildNodes[i].InnerText);
            }
        }
    }
    public static string getAdvice()
    {
        xmlData.read();
        return advices[0];
    }
}
