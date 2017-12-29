using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class HighscoresData : MonoBehaviour {

    public Text[] names = new Text[10];
    public Text[] values = new Text[10];
    //private Score[] scores = new Score[10];
    private List<Score> scores = new List<Score>();

	// Use this for initialization
	void Start () {
        //scores.Add(new Score("Kasia", 8));
        //scores.Add(new Score("Ania", 15));
        //scores.Add(new Score("Wojtek",12));
        
     
        //this.Serialize();
        //załadowanie tablicy, potem posortowanie
        this.Deserialize();
        //scores.Sort(new ScoreComparer());
        if (PlayerPrefs.HasKey("score") && PlayerPrefs.HasKey("name"))
        {
            NewScore();
            Serialize();
        }
        ShowScores();
    }
	
    void ShowScores()
    {
        for (int i = 0; i < scores.Count; i++)
        {
            names[i].text = scores[i].name;
            values[i].text = scores[i].value.ToString();
        }
    }

    void NewScore()
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

	// Update is called once per frame
	void Update () {
		
	}

    void Deserialize()
    {
        //scores.Clear();
        if (File.Exists("Data.dat")) {
            FileStream fileStream = new FileStream("Data.dat", FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //sprawdzic czy jest co czytac w ogole
            try
            {
                scores = (List<Score>)binaryFormatter.Deserialize(fileStream);
                //for (int i = 0; i < 2; i++)
                //{
                //    scores[i] = ((Score)binaryFormatter.Deserialize(fileStream));
                //}
            }
            catch (SerializationException e)
            {
                //log
            }
            finally
            {
                fileStream.Close();
            }
        }
    }

    void Serialize()
    {
        FileStream fileStream = new FileStream("Data.dat", FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        try
        {
            binaryFormatter.Serialize(fileStream,scores);
            //for (int i = 0; i < 2; i++)
            //{
            //    binaryFormatter.Serialize(fileStream,scores[i]);
            //}
        }
        catch(SerializationException e)
        {
            //log
        }
        finally
        {
            fileStream.Close();
        }
    }

    void NewScore(Score newScore)
    {

    }
}
