using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level7Completed = true;

        if (LevelManager.Level7Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level7Score)
            {
                ScoreSystem.Score = LevelManager.Level7Score;
                if (LevelManager.Level7Score > Star3)
                {
                    LevelManager.Level7Stars = 3;
                }
                else if (LevelManager.Level7Score > Star2)
                {
                    LevelManager.Level7Stars = 2;
                }
                else
                {
                    LevelManager.Level7Stars = 1;
                }
            }
        }
    }
}
