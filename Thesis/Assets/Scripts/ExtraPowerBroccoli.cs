using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPowerBroccoli : MonoBehaviour {

    GameObject[] broccoli;
    public int speedUpCount = 5;
    public int extraLifeCount = 3;
    private int index;
    System.Random random = new System.Random();
    // Use this for initialization
    void Start () {
        broccoli = GameObject.FindGameObjectsWithTag("broccoli");
        SpeedUpBroccoli();
        ExtraLifeBroccoli();
	}

    void ExtraLifeBroccoli()
    {
        int max = extraLifeCount < (broccoli.Length - speedUpCount) ? extraLifeCount : broccoli.Length - speedUpCount;
        for (int i = 0; i < max; i++)
        {
            index = random.Next(0, broccoli.Length);
            while (!broccoli[index].CompareTag("broccoli"))
            {
                index = random.Next(0, broccoli.Length);
            }
            broccoli[index].tag = "lifeBroccoli";
        }
    }

    void SpeedUpBroccoli()
    {
        
        int max = speedUpCount < broccoli.Length ? speedUpCount : broccoli.Length;
        
        for (int i = 0; i < max; i++)
        {
            index = random.Next(0, broccoli.Length);
            while (!broccoli[index].CompareTag("broccoli"))
            {
                index = random.Next(0, broccoli.Length);
            }
            broccoli[index].tag = "speedBroccoli";
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
