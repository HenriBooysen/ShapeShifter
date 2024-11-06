using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level9ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level9Completed = true;

        if (LevelManager.Level9Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level9Score)
            {
                ScoreSystem.Score = LevelManager.Level9Score;
                if (LevelManager.Level9Score > Star3)
                {
                    LevelManager.Level9Stars = 3;
                }
                else if (LevelManager.Level9Score > Star2)
                {
                    LevelManager.Level9Stars = 2;
                }
                else
                {
                    LevelManager.Level9Stars = 1;
                }
            }
        }
    }
}
