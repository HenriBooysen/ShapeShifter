using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level16ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level16Completed = true;

        if (LevelManager.Level16Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level16Score)
            {
                ScoreSystem.Score = LevelManager.Level16Score;
                if (LevelManager.Level16Score > Star3)
                {
                    LevelManager.Level16Stars = 3;
                }
                else if (LevelManager.Level16Score > Star2)
                {
                    LevelManager.Level16Stars = 2;
                }
                else
                {
                    LevelManager.Level16Stars = 1;
                }
            }
        }
    }
}
