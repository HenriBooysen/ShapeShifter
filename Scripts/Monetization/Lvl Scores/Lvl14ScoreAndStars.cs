using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level14ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level14Completed = true;

        if (LevelManager.Level14Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level14Score)
            {
                ScoreSystem.Score = LevelManager.Level14Score;
                if (LevelManager.Level14Score > Star3)
                {
                    LevelManager.Level14Stars = 3;
                }
                else if (LevelManager.Level14Score > Star2)
                {
                    LevelManager.Level14Stars = 2;
                }
                else
                {
                    LevelManager.Level14Stars = 1;
                }
            }
        }
    }
}
