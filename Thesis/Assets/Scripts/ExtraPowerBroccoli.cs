using UnityEngine;
using System;

public class ExtraPowerBroccoli : MonoBehaviour {

    public int speedUpCount = 5;
    public int extraLifeCount = 3;
    private int index;
    private GameObject[] broccoli;
    private System.Random random = new System.Random();

    private void Start () {
        broccoli = GameObject.FindGameObjectsWithTag("broccoli");
        SpeedUpBroccoli();
        ExtraLifeBroccoli();
	}

    private void ExtraLifeBroccoli ()
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

    private void SpeedUpBroccoli ()
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

}
