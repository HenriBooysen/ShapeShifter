using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level12ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level12Completed = true;

        if (LevelManager.Level12Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level12Score)
            {
                ScoreSystem.Score = LevelManager.Level12Score;
                if (LevelManager.Level12Score > Star3)
                {
                    LevelManager.Level12Stars = 3;
                }
                else if (LevelManager.Level12Score > Star2)
                {
                    LevelManager.Level12Stars = 2;
                }
                else
                {
                    LevelManager.Level12Stars = 1;
                }
            }
        }
    }
}
