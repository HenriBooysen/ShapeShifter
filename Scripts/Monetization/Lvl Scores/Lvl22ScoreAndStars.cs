using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level22ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level22Completed = true;

        if (LevelManager.Level22Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level22Score)
            {
                ScoreSystem.Score = LevelManager.Level22Score;
                if (LevelManager.Level22Score > Star3)
                {
                    LevelManager.Level22Stars = 3;
                }
                else if (LevelManager.Level22Score > Star2)
                {
                    LevelManager.Level22Stars = 2;
                }
                else
                {
                    LevelManager.Level22Stars = 1;
                }
            }
        }
    }
}
