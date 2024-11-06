using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1ScoreAndStars : MonoBehaviour
{
    
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level1Completed = true;

        if(LevelManager.Level1Completed )
        {
            if (ScoreSystem.Score > LevelManager.Level1Score)
            {
                ScoreSystem.Score = LevelManager.Level1Score;
                if (LevelManager.Level1Score > Star3)
                {
                    LevelManager.Level1Stars = 3;
                }
                else if(LevelManager.Level1Score > Star2)
                {
                    LevelManager.Level1Stars = 2;
                }
                else
                {
                    LevelManager.Level1Stars = 1;
                }
            }
        }
    }

}
