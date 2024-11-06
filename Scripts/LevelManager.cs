using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static string UserID;
    public static int ChallengeHighScore;
    public static GameObject HighscoreUI;
    public static GameObject RankingUI;

    public static bool Level1Completed = false;
    public static int Level1Score;
    public static int Level1Stars;

    public static bool Level2Completed = false;
    public static int Level2Score;
    public static int Level2Stars;

    public static bool Level3Completed = false;
    public static int Level3Score;
    public static int Level3Stars;

    public static bool Level4Completed = false;
    public static int Level4Score;
    public static int Level4Stars;

    public static bool Level5Completed = false;
    public static int Level5Score;
    public static int Level5Stars;

    public static bool Level6Completed = false;
    public static int Level6Score;
    public static int Level6Stars;

    public static bool Level7Completed = false;
    public static int Level7Score;
    public static int Level7Stars;

    public static bool Level8Completed = false;
    public static int Level8Score;
    public static int Level8Stars;

    public static bool Level9Completed = false;
    public static int Level9Score;
    public static int Level9Stars;

    public static bool Level10Completed = false;
    public static int Level10Score;
    public static int Level10Stars;

    public static bool Level11Completed = false;
    public static int Level11Score;
    public static int Level11Stars;

    public static bool Level12Completed = false;
    public static int Level12Score;
    public static int Level12Stars;

    public static bool Level13Completed = false;
    public static int Level13Score;
    public static int Level13Stars;

    public static bool Level14Completed = false;
    public static int Level14Score;
    public static int Level14Stars;

    public static bool Level15Completed = false;
    public static int Level15Score;
    public static int Level15Stars;

    public static bool Level16Completed = false;
    public static int Level16Score;
    public static int Level16Stars;

    public static bool Level17Completed = false;
    public static int Level17Score;
    public static int Level17Stars;

    public static bool Level18Completed = false;
    public static int Level18Score;
    public static int Level18Stars;

    public static bool Level19Completed = false;
    public static int Level19Score;
    public static int Level19Stars;

    public static bool Level20Completed = false;
    public static int Level20Score;
    public static int Level20Stars;

    public static bool Level21Completed = false;
    public static int Level21Score;
    public static int Level21Stars;

    public static bool Level22Completed = false;
    public static int Level22Score;
    public static int Level22Stars;

    public static bool Level23Completed = false;
    public static int Level23Score;
    public static int Level23Stars;

    public static bool Level24Completed = false;
    public static int Level24Score;
    public static int Level24Stars;

    public static bool Level25Completed = false;
    public static int Level25Score;
    public static int Level25Stars;

    public Button Level6to10;
    public Button Level11to15;
    public Button Level16to20;
    public Button Level21to25;

    public Button[] LvlButtons;

    public Image Lvl1Star1;
    public Image Lvl1Star2;
    public Image Lvl1Star3;

    public Image Lvl2Star1;
    public Image Lvl2Star2;
    public Image Lvl2Star3;

    public Image Lvl3Star1;
    public Image Lvl3Star2;
    public Image Lvl3Star3;

    public Image Lvl4Star1;
    public Image Lvl4Star2;
    public Image Lvl4Star3;

    public Image Lvl5Star1;
    public Image Lvl5Star2;
    public Image Lvl5Star3;

    public Image Lvl6Star1;
    public Image Lvl6Star2;
    public Image Lvl6Star3;

    public Image Lvl7Star1;
    public Image Lvl7Star2;
    public Image Lvl7Star3;

    public Image Lvl8Star1;
    public Image Lvl8Star2;
    public Image Lvl8Star3;

    public Image Lvl9Star1;
    public Image Lvl9Star2;
    public Image Lvl9Star3;

    public Image Lvl10Star1;
    public Image Lvl10Star2;
    public Image Lvl10Star3;

    public Image Lvl11Star1;
    public Image Lvl11Star2;
    public Image Lvl11Star3;

    public Image Lvl12Star1;
    public Image Lvl12Star2;
    public Image Lvl12Star3;
    
    public Image Lvl13Star1;
    public Image Lvl13Star2;
    public Image Lvl13Star3;

    public Image Lvl14Star1;
    public Image Lvl14Star2;
    public Image Lvl14Star3;

    public Image Lvl15Star1;
    public Image Lvl15Star2;
    public Image Lvl15Star3;

    public Image Lvl16Star1;
    public Image Lvl16Star2;
    public Image Lvl16Star3;

    public Image Lvl17Star1;
    public Image Lvl17Star2;
    public Image Lvl17Star3;

    public Image Lvl18Star1;
    public Image Lvl18Star2;
    public Image Lvl18Star3;

    public Image Lvl19Star1;
    public Image Lvl19Star2;
    public Image Lvl19Star3;

    public Image Lvl20Star1;
    public Image Lvl20Star2;
    public Image Lvl20Star3;

    public Image Lvl21Star1;
    public Image Lvl21Star2;
    public Image Lvl21Star3;

    public Image Lvl22Star1;
    public Image Lvl22Star2;
    public Image Lvl22Star3;

    public Image Lvl23Star1;
    public Image Lvl23Star2;
    public Image Lvl23Star3;

    public Image Lvl24Star1;
    public Image Lvl24Star2;
    public Image Lvl24Star3;

    public Image Lvl25Star1;
    public Image Lvl25Star2;
    public Image Lvl25Star3;

    public Color Black;
    public Color Yellow;

    /*public Button Lvl2Interactible;
    public Button Lvl3Interactible;
    public Button Lvl4Interactible;
    public Button Lvl5Interactible;
    public Button Lvl6Interactible;
    public Button Lvl7Interactible;
    public Button Lvl8Interactible;
    public Button Lvl9Interactible;
    public Button Lvl10Interactible;
    public Button Lvl11Interactible;
    public Button Lvl12Interactible;
    public Button Lvl13Interactible;
    public Button Lvl14Interactible;
    public Button Lvl15Interactible;
    public Button Lvl16Interactible;
    public Button Lvl17Interactible;
    public Button Lvl18Interactible;
    public Button Lvl19Interactible;
    public Button Lvl20Interactible;*/

    // Start is called before the first frame update
    void Start()
    {
        LoadData ();

        foreach (Button button in LvlButtons)
        {
            if (button != null)
            {
                string buttonName = button.name;
                int buttonNumber = ExtractNumberFromName(buttonName);

                if (buttonNumber != -1)
                {
                    if (button.interactable)
                    {
                        Debug.Log("Button " + buttonNumber + " is interactable.");
                    }
                    else
                    {
                        Debug.Log("Button " + buttonNumber + " is not interactable.");
                    }

                    // Enable or disable the button based on its number
                    if (ShouldEnableButton(buttonNumber))
                    {
                        button.interactable = true;
                    }
                    else
                    {
                        button.interactable = false;
                    }
                }
                else
                {
                    Debug.Log("No number found in button name: " + buttonName);
                }
            }
        }

        if ( Level1Completed)
        {
            if (ScoreSystem.levelStars[0] == 1)
            {
                Lvl1Star1.color =Yellow;
            }

            else if (ScoreSystem.levelStars[0] == 2)
            {
                Lvl1Star2.color =Yellow;
                Lvl1Star1.color = Yellow;
            }

            else if(ScoreSystem.levelStars[0] == 3)
            {
                Lvl1Star3.color =Yellow;
                Lvl1Star2.color = Yellow;
                Lvl1Star1.color = Yellow;
            }
        }

        if (Level2Completed)
        {
            if (ScoreSystem.levelStars[1] == 1)
            {
                Lvl2Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[1] == 2)
            {
                Lvl2Star2.color = Yellow;
                Lvl2Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[1] == 3)
            {
                Lvl2Star3.color = Yellow;
                Lvl2Star2.color = Yellow;
                Lvl2Star1.color = Yellow;
            }
        }

        if (Level3Completed)
        {
            if (ScoreSystem.levelStars[2] == 1)
            {
                Lvl3Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[2] == 2)
            {
                Lvl3Star2.color = Yellow;
                Lvl3Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[2] == 3)
            {
                Lvl3Star3.color = Yellow;
                Lvl3Star2.color = Yellow;
                Lvl3Star1.color = Yellow;
            }
        }

        if (Level4Completed)
        {
            if (ScoreSystem.levelStars[3] == 1)
            {
                Lvl4Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[3] == 2)
            {
                Lvl4Star2.color = Yellow;
                Lvl4Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[3] == 3)
            {
                Lvl4Star3.color = Yellow;
                Lvl4Star2.color = Yellow;
                Lvl4Star1.color = Yellow;
            }
        }

        if (Level5Completed)
        {
            Level6to10.interactable = true;

            if (ScoreSystem.levelStars[4] == 1)
            {
                Lvl5Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[4] == 2)
            {
                Lvl5Star2.color = Yellow;
                Lvl5Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[4] == 3)
            {
                Lvl5Star3.color = Yellow;
                Lvl5Star2.color = Yellow;
                Lvl5Star1.color = Yellow;
            }
        }

        if (Level6Completed)
        {
            if (ScoreSystem.levelStars[5] == 1)
            {
                Lvl6Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[5] == 2)
            {
                Lvl6Star2.color = Yellow;
                Lvl6Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[5] == 3)
            {
                Lvl6Star3.color = Yellow;
                Lvl6Star2.color = Yellow;
                Lvl6Star1.color = Yellow;
            }
        }

        if (Level7Completed)
        {
            if (ScoreSystem.levelStars[6] == 1)
            {
                Lvl7Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[6] == 2)
            {
                Lvl7Star2.color = Yellow;
                Lvl7Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[6] == 3)
            {
                Lvl7Star3.color = Yellow;
                Lvl7Star2.color = Yellow;
                Lvl7Star1.color = Yellow;
            }
        }

        if (Level8Completed)
        {
            if (ScoreSystem.levelStars[7] == 1)
            {
                Lvl8Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[7] == 2)
            {
                Lvl8Star2.color = Yellow;
                Lvl8Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[7] == 3)
            {
                Lvl8Star3.color = Yellow;
                Lvl8Star2.color = Yellow;
                Lvl8Star1.color = Yellow;
            }
        }

        if (Level9Completed)
        {
            if (ScoreSystem.levelStars[8] == 1)
            {
                Lvl9Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[8] == 2)
            {
                Lvl9Star2.color = Yellow;
                Lvl9Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[8] == 3)
            {
                Lvl9Star3.color = Yellow;
                Lvl9Star2.color = Yellow;
                Lvl9Star1.color = Yellow;
            }
        }

        if (Level10Completed)
        {
            Level11to15.interactable = true;

            if (ScoreSystem.levelStars[9] == 1)
            {
                Lvl10Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[9] == 2)
            {
                Lvl10Star2.color = Yellow;
                Lvl10Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[9] == 3)
            {
                Lvl10Star3.color = Yellow;
                Lvl10Star2.color = Yellow;
                Lvl10Star1.color = Yellow;
            }
        }

        if (Level11Completed)
        {
            if (ScoreSystem.levelStars[10] == 1)
            {
                Lvl11Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[10] == 2)
            {
                Lvl11Star2.color = Yellow;
                Lvl11Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[10] == 3)
            {
                Lvl11Star3.color = Yellow;
                Lvl11Star2.color = Yellow;
                Lvl11Star1.color = Yellow;
            }
        }

        if (Level12Completed)
        {
            if (ScoreSystem.levelStars[11] == 1)
            {
                Lvl12Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[11] == 2)
            {
                Lvl12Star2.color = Yellow;
                Lvl12Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[11] == 3)
            {
                Lvl12Star3.color = Yellow;
                Lvl12Star2.color = Yellow;
                Lvl12Star1.color = Yellow;
            }
        }

        if (Level13Completed)
        {
            if (ScoreSystem.levelStars[12] == 1)
            {
                Lvl13Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[12] == 2)
            {
                Lvl13Star2.color = Yellow;
                Lvl13Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[12] == 3)
            {
                Lvl13Star3.color = Yellow;
                Lvl13Star2.color = Yellow;
                Lvl13Star1.color = Yellow;
            }
        }

        if (Level14Completed)
        {
            if (ScoreSystem.levelStars[13] == 1)
            {
                Lvl14Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[13] == 2)
            {
                Lvl14Star2.color = Yellow;
                Lvl14Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[13] == 3)
            {
                Lvl14Star3.color = Yellow;
                Lvl14Star2.color = Yellow;
                Lvl14Star1.color = Yellow;
            }
        }

        if (Level15Completed)
        {
            Level16to20.interactable = true;

            if (ScoreSystem.levelStars[14] == 1)
            {
                Lvl15Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[14] == 2)
            {
                Lvl15Star2.color = Yellow;
                Lvl15Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[14] == 3)
            {
                Lvl15Star3.color = Yellow;
                Lvl15Star2.color = Yellow;
                Lvl15Star1.color = Yellow;
            }
        }

        if (Level16Completed)
        {
            if (ScoreSystem.levelStars[15] == 1)
            {
                Lvl16Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[15] == 2)
            {
                Lvl16Star2.color = Yellow;
                Lvl16Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[15] == 3)
            {
                Lvl16Star3.color = Yellow;
                Lvl16Star2.color = Yellow;
                Lvl16Star1.color = Yellow;
            }
        }

        if (Level17Completed)
        {
            if (ScoreSystem.levelStars[16] == 1)
            {
                Lvl17Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[16] == 2)
            {
                Lvl17Star2.color = Yellow;
                Lvl17Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[16] == 3)
            {
                Lvl17Star3.color = Yellow;
                Lvl17Star2.color = Yellow;
                Lvl17Star1.color = Yellow;
            }
        }

        if (Level18Completed)
        {
            if (ScoreSystem.levelStars[17] == 1)
            {
                Lvl18Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[17] == 2)
            {
                Lvl18Star2.color = Yellow;
                Lvl18Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[17] == 3)
            {
                Lvl18Star3.color = Yellow;
                Lvl18Star2.color = Yellow;
                Lvl18Star1.color = Yellow;
            }
        }

        if (Level19Completed)
        {
            if (ScoreSystem.levelStars[18] == 1)
            {
                Lvl19Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[18] == 2)
            {
                Lvl19Star2.color = Yellow;
                Lvl19Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[18] == 3)
            {
                Lvl19Star3.color = Yellow;
                Lvl19Star2.color = Yellow;
                Lvl19Star1.color = Yellow;
            }
        }
        if (Level20Completed)
        {
            if (ScoreSystem.levelStars[19] == 1)
            {
                Lvl20Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[19] == 2)
            {
                Lvl20Star2.color = Yellow;
                Lvl20Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[19] == 3)
            {
                Lvl20Star3.color = Yellow;
                Lvl20Star2.color = Yellow;
                Lvl20Star1.color = Yellow;
            }
        }
        if (Level21Completed)
        {
            if (ScoreSystem.levelStars[20] == 1)
            {
                Lvl21Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[20] == 2)
            {
                Lvl21Star2.color = Yellow;
                Lvl21Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[20] == 3)
            {
                Lvl21Star3.color = Yellow;
                Lvl21Star2.color = Yellow;
                Lvl21Star1.color = Yellow;
            }
        }
        if (Level22Completed)
        {
            if (ScoreSystem.levelStars[21] == 1)
            {
                Lvl22Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[21] == 2)
            {
                Lvl22Star2.color = Yellow;
                Lvl22Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[21] == 3)
            {
                Lvl22Star3.color = Yellow;
                Lvl22Star2.color = Yellow;
                Lvl22Star1.color = Yellow;
            }
        }
        if (Level23Completed)
        {
            if (ScoreSystem.levelStars[22] == 1)
            {
                Lvl23Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[22] == 2)
            {
                Lvl23Star2.color = Yellow;
                Lvl23Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[22] == 3)
            {
                Lvl23Star3.color = Yellow;
                Lvl23Star2.color = Yellow;
                Lvl23Star1.color = Yellow;
            }
        }
        if (Level24Completed)
        {
            if (ScoreSystem.levelStars[23] == 1)
            {
                Lvl24Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[23] == 2)
            {
                Lvl24Star2.color = Yellow;
                Lvl24Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[23] == 3)
            {
                Lvl24Star3.color = Yellow;
                Lvl24Star2.color = Yellow;
                Lvl24Star1.color = Yellow;
            }
        }
        if (Level25Completed)
        {
            if (ScoreSystem.levelStars[24] == 1)
            {
                Lvl25Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[24] == 2)
            {
                Lvl25Star2.color = Yellow;
                Lvl25Star1.color = Yellow;
            }

            else if (ScoreSystem.levelStars[24] == 3)
            {
                Lvl25Star3.color = Yellow;
                Lvl25Star2.color = Yellow;
                Lvl25Star1.color = Yellow;
            }
        }
    }

    int ExtractNumberFromName(string name)
    {
        // Use regular expression to find the number in the name
        Match match = Regex.Match(name, @"\d+");
        if (match.Success)
        {
            return int.Parse(match.Value);
        }
        return -1; // Return -1 if no number is found
    }

    bool ShouldEnableButton(int buttonNumber)
    {
        // Add your logic here to determine if the button should be enabled
        // For example, you can check if the corresponding level is completed
        switch (buttonNumber)
        {
            case 1: return true;
            case 2: return Level1Completed;
            case 3: return Level2Completed;
            case 4: return Level3Completed;
            case 5: return Level4Completed;
            case 6: return Level5Completed;
            case 7: return Level6Completed;
            case 8: return Level7Completed;
            case 9: return Level8Completed;
            case 10: return Level9Completed;
            case 11: return Level10Completed;
            case 12: return Level11Completed;
            case 13: return Level12Completed;
            case 14: return Level13Completed;
            case 15: return Level14Completed;
            case 16: return Level15Completed;
            case 17: return Level16Completed;
            case 18: return Level17Completed;
            case 19: return Level18Completed;
            case 20: return Level19Completed;
            case 21: return Level20Completed;
            case 22: return Level21Completed;
            case 23: return Level22Completed;
            case 24: return Level23Completed;
            case 25: return Level24Completed;
            case 26: return Level25Completed;
            default: return false;
        }
    }

    static void LoadData()
    {
        UserID = PlayerPrefs.GetString("UserID", null);
        ChallengeHighScore = PlayerPrefs.GetInt("ChallengeHighScore", 0);

        Level1Completed = PlayerPrefs.GetInt("Level1Completed", 0) == 1;
        Level1Score = PlayerPrefs.GetInt("Level1Score", 0);
        Level1Stars = PlayerPrefs.GetInt("Level1Stars", 0);

        Level2Completed = PlayerPrefs.GetInt("Level2Completed", 0) == 1;
        Level2Score = PlayerPrefs.GetInt("Level2Score", 0);
        Level2Stars = PlayerPrefs.GetInt("Level2Stars", 0);

        Level3Completed = PlayerPrefs.GetInt("Level3Completed", 0) == 1;
        Level3Score = PlayerPrefs.GetInt("Level3Score", 0);
        Level3Stars = PlayerPrefs.GetInt("Level3Stars", 0);

        Level4Completed = PlayerPrefs.GetInt("Level4Completed", 0) == 1;
        Level4Score = PlayerPrefs.GetInt("Level4Score", 0);
        Level4Stars = PlayerPrefs.GetInt("Level4Stars", 0);

        Level5Completed = PlayerPrefs.GetInt("Level5Completed", 0) == 1;
        Level5Score = PlayerPrefs.GetInt("Level5Score", 0);
        Level5Stars = PlayerPrefs.GetInt("Level5Stars", 0);

        Level6Completed = PlayerPrefs.GetInt("Level6Completed", 0) == 1;
        Level6Score = PlayerPrefs.GetInt("Level6Score", 0);
        Level6Stars = PlayerPrefs.GetInt("Level6Stars", 0);

        Level7Completed = PlayerPrefs.GetInt("Level7Completed", 0) == 1;
        Level7Score = PlayerPrefs.GetInt("Level7Score", 0);
        Level7Stars = PlayerPrefs.GetInt("Level7Stars", 0);

        Level8Completed = PlayerPrefs.GetInt("Level8Completed", 0) == 1;
        Level8Score = PlayerPrefs.GetInt("Level8Score", 0);
        Level8Stars = PlayerPrefs.GetInt("Level8Stars", 0);

        Level9Completed = PlayerPrefs.GetInt("Level9Completed", 0) == 1;
        Level9Score = PlayerPrefs.GetInt("Level9Score", 0);
        Level9Stars = PlayerPrefs.GetInt("Level9Stars", 0);

        Level10Completed = PlayerPrefs.GetInt("Level10Completed", 0) == 1;
        Level10Score = PlayerPrefs.GetInt("Level10Score", 0);
        Level10Stars = PlayerPrefs.GetInt("Level10Stars", 0);

        Level11Completed = PlayerPrefs.GetInt("Level11Completed", 0) == 1;
        Level11Score = PlayerPrefs.GetInt("Level11Score", 0);
        Level11Stars = PlayerPrefs.GetInt("Level11Stars", 0);

        Level12Completed = PlayerPrefs.GetInt("Level12Completed", 0) == 1;
        Level12Score = PlayerPrefs.GetInt("Level12Score", 0);
        Level12Stars = PlayerPrefs.GetInt("Level12Stars", 0);

        Level13Completed = PlayerPrefs.GetInt("Level13Completed", 0) == 1;
        Level13Score = PlayerPrefs.GetInt("Level13Score", 0);
        Level13Stars = PlayerPrefs.GetInt("Level13Stars", 0);

        Level14Completed = PlayerPrefs.GetInt("Level14Completed", 0) == 1;
        Level14Score = PlayerPrefs.GetInt("Level14Score", 0);
        Level14Stars = PlayerPrefs.GetInt("Level14Stars", 0);

        Level15Completed = PlayerPrefs.GetInt("Level15Completed", 0) == 1;
        Level15Score = PlayerPrefs.GetInt("Level15Score", 0);
        Level15Stars = PlayerPrefs.GetInt("Level15Stars", 0);

        Level16Completed = PlayerPrefs.GetInt("Level16Completed", 0) == 1;
        Level16Score = PlayerPrefs.GetInt("Level16Score", 0);
        Level16Stars = PlayerPrefs.GetInt("Level16Stars", 0);

        Level17Completed = PlayerPrefs.GetInt("Level17Completed", 0) == 1;
        Level17Score = PlayerPrefs.GetInt("Level17Score", 0);
        Level17Stars = PlayerPrefs.GetInt("Level17Stars", 0);

        Level18Completed = PlayerPrefs.GetInt("Level18Completed", 0) == 1;
        Level18Score = PlayerPrefs.GetInt("Level18Score", 0);
        Level18Stars = PlayerPrefs.GetInt("Level18Stars", 0);

        Level19Completed = PlayerPrefs.GetInt("Level19Completed", 0) == 1;
        Level19Score = PlayerPrefs.GetInt("Level19Score", 0);
        Level19Stars = PlayerPrefs.GetInt("Level19Stars", 0);

        Level20Completed = PlayerPrefs.GetInt("Level20Completed", 0) == 1;
        Level20Score = PlayerPrefs.GetInt("Level20Score", 0);
        Level20Stars = PlayerPrefs.GetInt("Level20Stars", 0);

        Level21Completed = PlayerPrefs.GetInt("Level21Completed", 0) == 1;
        Level21Score = PlayerPrefs.GetInt("Level21Score", 0);
        Level21Stars = PlayerPrefs.GetInt("Level21Stars", 0);

        Level22Completed = PlayerPrefs.GetInt("Level22Completed", 0) == 1;
        Level22Score = PlayerPrefs.GetInt("Level22Score", 0);
        Level22Stars = PlayerPrefs.GetInt("Level22Stars", 0);

        Level23Completed = PlayerPrefs.GetInt("Level23Completed", 0) == 1;
        Level23Score = PlayerPrefs.GetInt("Level23Score", 0);
        Level23Stars = PlayerPrefs.GetInt("Level23Stars", 0);

        Level24Completed = PlayerPrefs.GetInt("Level24Completed", 0) == 1;
        Level24Score = PlayerPrefs.GetInt("Level24Score", 0);
        Level24Stars = PlayerPrefs.GetInt("Level24Stars", 0);

        Level25Completed = PlayerPrefs.GetInt("Level25Completed", 0) == 1;
        Level25Score = PlayerPrefs.GetInt("Level25Score", 0);
        Level25Stars = PlayerPrefs.GetInt("Level25Stars", 0);


        Debug.Log("SavedData loaded");

    }
}
