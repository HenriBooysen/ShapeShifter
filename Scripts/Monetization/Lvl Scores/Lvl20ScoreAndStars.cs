using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level20ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level20Completed = true;

        if (LevelManager.Level20Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level20Score)
            {
                ScoreSystem.Score = LevelManager.Level20Score;
                if (LevelManager.Level20Score > Star3)
                {
                    LevelManager.Level20Stars = 3;
                }
                else if (LevelManager.Level20Score > Star2)
                {
                    LevelManager.Level20Stars = 2;
                }
                else
                {
                    LevelManager.Level20Stars = 1;
                }
            }
        }
    }
}
