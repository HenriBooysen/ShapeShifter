using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level19ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level19Completed = true;

        if (LevelManager.Level19Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level19Score)
            {
                ScoreSystem.Score = LevelManager.Level19Score;
                if (LevelManager.Level19Score > Star3)
                {
                    LevelManager.Level19Stars = 3;
                }
                else if (LevelManager.Level19Score > Star2)
                {
                    LevelManager.Level19Stars = 2;
                }
                else
                {
                    LevelManager.Level19Stars = 1;
                }
            }
        }
    }
}
