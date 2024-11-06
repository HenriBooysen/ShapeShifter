using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level5Completed = true;

        if (LevelManager.Level5Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level5Score)
            {
                ScoreSystem.Score = LevelManager.Level5Score;
                if (LevelManager.Level5Score > Star3)
                {
                    LevelManager.Level5Stars = 3;
                }
                else if (LevelManager.Level5Score > Star2)
                {
                    LevelManager.Level5Stars = 2;
                }
                else
                {
                    LevelManager.Level5Stars = 1;
                }
            }
        }
    }
}
