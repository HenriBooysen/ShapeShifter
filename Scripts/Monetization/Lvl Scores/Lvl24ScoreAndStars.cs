using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level24ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level24Completed = true;

        if (LevelManager.Level24Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level24Score)
            {
                ScoreSystem.Score = LevelManager.Level24Score;
                if (LevelManager.Level24Score > Star3)
                {
                    LevelManager.Level24Stars = 3;
                }
                else if (LevelManager.Level24Score > Star2)
                {
                    LevelManager.Level24Stars = 2;
                }
                else
                {
                    LevelManager.Level24Stars = 1;
                }
            }
        }
    }
}
