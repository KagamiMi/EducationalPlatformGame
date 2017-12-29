using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Score {
    public int value;
    public string name;

    public Score(string name, int value)
    {
        this.name = name;
        this.value = value;
    }
}
