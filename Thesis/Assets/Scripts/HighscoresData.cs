using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class HighscoresData : MonoBehaviour {

    public Text[] names = new Text[10];
    public Text[] values = new Text[10];
    private List<Score> scores = new List<Score>();

	private void Start () {
        Deserialize();
        if (PlayerPrefs.HasKey("score") && PlayerPrefs.HasKey("name"))
        {
            NewScore();
            Serialize();
        }
        ShowScores();
    }
	
    private void ShowScores ()
    {
        for (int i = 0; i < scores.Count; i++)
        {
            names[i].text = scores[i].name;
            values[i].text = scores[i].value.ToString();
        }
    }

    private void NewScore ()
    {
        Boolean inserted = false;
        Score newScore = new Score(PlayerPrefs.GetString("name"), PlayerPrefs.GetInt("score"));
        PlayerPrefs.DeleteKey("name");
        PlayerPrefs.DeleteKey("score");
        if (scores.Count == 0)
        {
            scores.Add(newScore);
        }
        else
        {
            for (int i = 0; !inserted && (i < scores.Count); i++)
            {
                if (newScore.value > scores[i].value)
                {
                    scores.Insert(i, newScore);
                    inserted = true;
                }
            }
            if (!inserted && scores.Count < 10)
            {
                scores.Add(newScore);
            }
            if (inserted && scores.Count > 10)
            {
                scores.RemoveAt(10);
            }
        }
    }

    private void Deserialize ()
    {
        if (File.Exists("Data.dat")) {
            FileStream fileStream = new FileStream("Data.dat", FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                scores = (List<Score>)binaryFormatter.Deserialize(fileStream);
            }
            catch (SerializationException)
            {
                Debug.Log("Error while deserializing highscores data.");
            }
            finally
            {
                fileStream.Close();
            }
        }
    }

    private void Serialize()
    {
        FileStream fileStream = new FileStream("Data.dat", FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        try
        {
            binaryFormatter.Serialize(fileStream,scores);
        }
        catch(SerializationException)
        {
            Debug.Log("Error while serializing highscores data.");
        }
        finally
        {
            fileStream.Close();
        }
    }
}
