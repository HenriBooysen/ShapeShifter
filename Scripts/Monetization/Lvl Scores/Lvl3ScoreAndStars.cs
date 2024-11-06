using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level3Completed = true;

        if (LevelManager.Level3Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level3Score)
            {
                ScoreSystem.Score = LevelManager.Level3Score;
                if (LevelManager.Level3Score > Star3)
                {
                    LevelManager.Level3Stars = 3;
                }
                else if (LevelManager.Level3Score > Star2)
                {
                    LevelManager.Level3Stars = 2;
                }
                else
                {
                    LevelManager.Level3Stars = 1;
                }
            }
        }
    }
}
