using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level6Completed = true;

        if (LevelManager.Level6Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level6Score)
            {
                ScoreSystem.Score = LevelManager.Level6Score;
                if (LevelManager.Level6Score > Star3)
                {
                    LevelManager.Level6Stars = 3;
                }
                else if (LevelManager.Level6Score > Star2)
                {
                    LevelManager.Level6Stars = 2;
                }
                else
                {
                    LevelManager.Level6Stars = 1;
                }
            }
        }
    }
}
