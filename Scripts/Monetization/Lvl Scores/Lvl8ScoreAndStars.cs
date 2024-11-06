using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level8ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level8Completed = true;

        if (LevelManager.Level8Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level8Score)
            {
                ScoreSystem.Score = LevelManager.Level8Score;
                if (LevelManager.Level8Score > Star3)
                {
                    LevelManager.Level8Stars = 3;
                }
                else if (LevelManager.Level8Score > Star2)
                {
                    LevelManager.Level8Stars = 2;
                }
                else
                {
                    LevelManager.Level8Stars = 1;
                }
            }
        }
    }
}
