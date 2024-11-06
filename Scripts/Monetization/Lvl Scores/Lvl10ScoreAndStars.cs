using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level10coreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level10Completed = true;

        if (LevelManager.Level10Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level10Score)
            {
                ScoreSystem.Score = LevelManager.Level10Score;
                if (LevelManager.Level10Score > Star3)
                {
                    LevelManager.Level10Stars = 3;
                }
                else if (LevelManager.Level10Score > Star2)
                {
                    LevelManager.Level10Stars = 2;
                }
                else
                {
                    LevelManager.Level10Stars = 1;
                }
            }
        }
    }
}
