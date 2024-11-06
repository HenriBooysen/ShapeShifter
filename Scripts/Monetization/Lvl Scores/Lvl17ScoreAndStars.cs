using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level17ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level17Completed = true;

        if (LevelManager.Level17Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level17Score)
            {
                ScoreSystem.Score = LevelManager.Level7Score;
                if (LevelManager.Level17Score > Star3)
                {
                    LevelManager.Level17Stars = 3;
                }
                else if (LevelManager.Level17Score > Star2)
                {
                    LevelManager.Level17Stars = 2;
                }
                else
                {
                    LevelManager.Level17Stars = 1;
                }
            }
        }
    }
}
