using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreComparer: IComparer<Score> {

	public int Compare(Score score1, Score score2)
    {
        if (score1 == null)
        {
            if (score2 == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        else
        {
            if (score2 == null)
            {
                return -1;
            }
            else
            {
                if (score1.value == score2.value)
                {
                    return 0;
                }
                else if (score1.value > score2.value)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
