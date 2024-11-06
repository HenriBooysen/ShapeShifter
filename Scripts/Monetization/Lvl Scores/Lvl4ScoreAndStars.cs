using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level4Completed = true;

        if (LevelManager.Level4Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level4Score)
            {
                ScoreSystem.Score = LevelManager.Level4Score;
                if (LevelManager.Level4Score > Star3)
                {
                    LevelManager.Level4Stars = 3;
                }
                else if (LevelManager.Level4Score > Star2)
                {
                    LevelManager.Level4Stars = 2;
                }
                else
                {
                    LevelManager.Level4Stars = 1;
                }
            }
        }
    }
}
