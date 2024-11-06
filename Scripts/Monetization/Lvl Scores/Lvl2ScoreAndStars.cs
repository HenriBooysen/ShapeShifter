using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level2Completed = true;

        if (LevelManager.Level2Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level2Score)
            {
                ScoreSystem.Score = LevelManager.Level2Score;
                if (LevelManager.Level2Score > Star3)
                {
                    LevelManager.Level2Stars = 3;
                }
                else if (LevelManager.Level2Score > Star2)
                {
                    LevelManager.Level2Stars = 2;
                }
                else
                {
                    LevelManager.Level2Stars = 1;
                }
            }
        }
    }
}
