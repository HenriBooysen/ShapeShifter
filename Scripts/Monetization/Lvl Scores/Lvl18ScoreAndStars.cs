using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level18ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level18Completed = true;

        if (LevelManager.Level18Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level18Score)
            {
                ScoreSystem.Score = LevelManager.Level18Score;
                if (LevelManager.Level18Score > Star3)
                {
                    LevelManager.Level18Stars = 3;
                }
                else if (LevelManager.Level18Score > Star2)
                {
                    LevelManager.Level18Stars = 2;
                }
                else
                {
                    LevelManager.Level18Stars = 1;
                }
            }
        }
    }
}
