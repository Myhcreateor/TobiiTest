using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameProgress 
{
    public static int differentLevel = 3;
    public static int unfinished = 0;
    public static int finished = 0;
    public static int continuousUnfinished = 0;
    public static int continuousFinished = 0;
    public static void AdjustDifficult()
    {
        if (continuousUnfinished >= 3&&differentLevel>1)
        {
            differentLevel--;
            AudioPlay.Instance.PlayAudio(12);
            continuousUnfinished = 0;
        }
        if ((finished + unfinished) % 5 == 0&&(float)finished/ (finished + unfinished) >= 0.8)
        {
            differentLevel++;
            AudioPlay.Instance.PlayAudio(11);
        }

    }
}
