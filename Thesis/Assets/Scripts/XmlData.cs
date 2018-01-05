using System.Collections.Generic;
using System.Xml;

public class XmlData {

    private XmlDocument xmlDocument;
    private List<string> advices = new List<string>();
    private List<int> indexes = new List<int>();
    private int adviceIndex = 0;
    private string advicesPath = "Assets\\advices.xml";

    public XmlData ()
    {
        xmlDocument = new XmlDocument();
        xmlDocument.Load(advicesPath);
        XmlNode list = xmlDocument.FirstChild;
        if (list.HasChildNodes)
        {
            for (int i=0; i<list.ChildNodes.Count; i++)
            {
                advices.Add(list.ChildNodes[i].InnerText);
                indexes.Add(i);
            }
        }
    }

    private void DurstenfeldShuffle ()
    {
        System.Random random = new System.Random();
        for (int i = 0; i < (indexes.Count - 1); i++)
        {
            int j = random.Next(i, indexes.Count);
            int temp = indexes[i];
            indexes[i] = indexes[j];
            indexes[j] = temp;
        }
    }

    public string NextAdvice ()
    {
        string advice = advices[indexes[adviceIndex]];
        if ((adviceIndex + 1) < indexes.Count)
        {
            adviceIndex++;
        }
        else
        {
            DurstenfeldShuffle();
            adviceIndex = 0;
        }
        return advice;
    }
}
