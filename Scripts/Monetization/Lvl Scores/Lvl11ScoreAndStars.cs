using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level11ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level11Completed = true;

        if (LevelManager.Level11Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level11Score)
            {
                ScoreSystem.Score = LevelManager.Level11Score;
                if (LevelManager.Level11Score > Star3)
                {
                    LevelManager.Level11Stars = 3;
                }
                else if (LevelManager.Level11Score > Star2)
                {
                    LevelManager.Level11Stars = 2;
                }
                else
                {
                    LevelManager.Level11Stars = 1;
                }
            }
        }
    }
}
