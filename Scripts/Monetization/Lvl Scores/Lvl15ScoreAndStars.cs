using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level15ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level15Completed = true;

        if (LevelManager.Level15Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level15Score)
            {
                ScoreSystem.Score = LevelManager.Level15Score;
                if (LevelManager.Level15Score > Star3)
                {
                    LevelManager.Level15Stars = 3;
                }
                else if (LevelManager.Level15Score > Star2)
                {
                    LevelManager.Level15Stars = 2;
                }
                else
                {
                    LevelManager.Level15Stars = 1;
                }
            }
        }
    }
}
