using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    public Move moveComponent;
    public static event Action OnLoose;
    public static event Action OnWin;

    public ShapeCollisionChecker CameraCrash;
    public CameraAnimation CrashedAnimation;
    public ShapeSpawner ShapeSpawner;

    public static int Health;
    public static int Score;
    public TMP_Text countdownText;
    public GameObject PlayerShape;
    public GameObject FailMenu;
    public GameObject SuccessMenu;
    public GameObject PauseMenu;
    public GameObject Camera;

    //public GameObject LevelManager;
    public bool ChallengeMode;

    public GameObject ScorePoints;
    public GameObject ScoreLogo;
    public GameObject HealthPoints;
    public GameObject HealthLogo;

    public bool HasTip;
    public GameObject MobileUserTip;
    public GameObject PCTip;
    public GameObject Countdown;

    public AudioClip[] ScoreSounds;
    public AudioClip[] FailSounds;
    public AudioClip[] WinSounds;

    public AudioSource AudioSource;
    public GameObject Music;
    private Rigidbody rb;

    private bool countdownFinished = false;
    private float elapsedTime = 0f;
    private Vector3 initialVelocity;
    public float MoveSpeed = 10f;
    public float Crashspeed;

    public GameObject EndSuprise;
    public Sprite[] Winimages;
    public Sprite[] Looseimages;

    private Scene CurrentScene;
    public string GameLevel;
    public string NextLevel;

    public static bool[] levelCompleted = new bool[25];
    public static int[] levelScore = new int[25];
    public static int[] levelStars = new int[25];

    public static int[] Star3Thresholds = new int[25];
    public static int[] Star2Thresholds = new int[25];

    private int AddCounter;
    // Start is called before the first frame update
    void Start()
    {
        Move.PlayEnabled = false;
        Health = 3;
        Score = 0;
        Application.targetFrameRate = 60;
        Crashspeed = -MoveSpeed - 3;
        AudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        AddCounter = 0;
        IronSource.Agent.validateIntegration();

        CurrentScene = SceneManager.GetActiveScene();
        GameLevel = CurrentScene.name;
        
        StartCoroutine(CountdownAndScale());

        // Initialize thresholds for each level
        Star3Thresholds[0] = 5;
        Star2Thresholds[0] = 1;

        Star3Thresholds[1] = 10;
        Star2Thresholds[1] = 1;

        Star3Thresholds[2] = 15;
        Star2Thresholds[2] = 1;

        Star3Thresholds[3] = 10;
        Star2Thresholds[3] = 1;

        Star3Thresholds[4] = 15;
        Star2Thresholds[4] = 1;

        Star3Thresholds[5] = 10;
        Star2Thresholds[5] = 1;

        Star3Thresholds[6] = 15;
        Star2Thresholds[6] = 1;

        Star3Thresholds[7] = 20;
        Star2Thresholds[7] = 1;

        Star3Thresholds[8] = 10;
        Star2Thresholds[8] = 8;

        Star3Thresholds[9] = 15;
        Star2Thresholds[9] = 13;

        Star3Thresholds[10] = 10;
        Star2Thresholds[10] = 8;

        Star3Thresholds[11] = 15;
        Star2Thresholds[11] = 13;

        Star3Thresholds[12] = 20;
        Star2Thresholds[12] = 18;

        Star3Thresholds[13] = 15;
        Star2Thresholds[13] = 13;

        Star3Thresholds[14] = 20;
        Star2Thresholds[14] = 18;

        Star3Thresholds[15] = 20;
        Star2Thresholds[15] = 18;

        Star3Thresholds[16] = 25;
        Star2Thresholds[16] = 23;

        Star3Thresholds[17] = 30;
        Star2Thresholds[17] = 28;

        Star3Thresholds[18] = 30;
        Star2Thresholds[18] = 28;

        Star3Thresholds[19] = 35;
        Star2Thresholds[19] = 33;

        Star3Thresholds[20] = 35;
        Star2Thresholds[20] = 33;

        Star3Thresholds[21] = 40;
        Star2Thresholds[21] = 38;

        Star3Thresholds[22] = 45;
        Star2Thresholds[22] = 43;

        Star3Thresholds[23] = 50;
        Star2Thresholds[23] = 48;

        Star3Thresholds[24] = 60;
        Star2Thresholds[24] = 58;
    }

    private IEnumerator CountdownAndScale()
    {
        if (HasTip == true)
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                MobileUserTip.SetActive(true);
                Debug.Log("Running on a mobile device");
                yield return new WaitForSeconds(2f);
                MobileUserTip.SetActive(false);
                Countdown.SetActive(true);
                countdownText.gameObject.SetActive(true);
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.LinuxPlayer)
            {
                PCTip.SetActive(true);
                yield return new WaitForSeconds(2f);
                PCTip.SetActive(false);
                Countdown.SetActive(true);
                countdownText.gameObject.SetActive(true);
                Debug.Log("Running on a PC");
            }
            else
            {
                Countdown.SetActive(true);
                countdownText.gameObject.SetActive(true);
                Debug.Log("Running on an unknown platform");
            }
        }

        else
        {
            Countdown.SetActive(true);
            countdownText.gameObject.SetActive(true);
        }
        // Countdown loop
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return ScaleTextSmoothly(countdownText.transform, Vector3.one * 2, Vector3.zero, 0.7f);
            yield return new WaitForSeconds(0.1f);
        }

        // Display "GO!"
        countdownText.text = "GO!";
        yield return ScaleTextSmoothly(countdownText.transform, Vector3.one * 2, Vector3.zero, 0.7f);
        yield return new WaitForSeconds(0.1f);
        countdownText.gameObject.SetActive(false); // Disable the countdown text

        // Allow movement and apply force after countdown
        countdownFinished = true;
        Move.PlayEnabled = true;
        rb.AddForce(0, 0, MoveSpeed, ForceMode.VelocityChange);
    }
    private IEnumerator ScaleTextSmoothly(Transform textTransform, Vector3 startScale, Vector3 endScale, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            textTransform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        textTransform.localScale = endScale;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        // Handle movement and force application only after countdown finishes
        if (countdownFinished)
        {
            // Your movement and force application logic...
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Example: Apply force in the z-direction
                rb.AddForce(Vector3.forward * MoveSpeed, ForceMode.VelocityChange);
            }
        }
    }

    public void Loose()
    {
        //Debug.Log(rb+" Rigidboyattatched");
        AddCounter = AddCounter + 1;
        Music.SetActive(false);
        Health = 0;
        HealthPoints.GetComponent<Text>().text = Health.ToString();

        int randomIndex = UnityEngine.Random.Range(0, FailSounds.Length);
        AudioSource.clip = FailSounds[randomIndex];
        AudioSource.Play();
        Move.PlayEnabled = false;

        if (rb != null)
        {
            rb.AddForce(0, 0, Crashspeed, ForceMode.VelocityChange);
            new WaitForSeconds(2);
            rb.isKinematic = true;

            //CrashedAnimation.crahsed = true;
            Debug.Log("Rigidbody detected");
        }
        else { Debug.Log("No Rigidbody detected"); }

        HealthPoints.GetComponent<Animator>().SetTrigger("TrHealth Loss");
        HealthLogo.GetComponent<Animator>().SetTrigger("TrLose Health");
        Camera.GetComponent<Animator>().SetTrigger("TrCameraCrash");

        if (AddCounter == 3)
        {
            AddCounter = 0;
        }

        if (Looseimages.Length > 0)
        {
            // Select a random image
            int randomImageIndex = UnityEngine.Random.Range(0, Looseimages.Length);
            Sprite selectedImage = Looseimages[randomImageIndex];

            EndSuprise.GetComponent<Image>().sprite = selectedImage;
            EndSuprise.SetActive(true);
        }

        else
        {
            Debug.LogWarning("No images assigned to the images array.");
        }

        if (ChallengeMode == true)
        {
            if (Score > LevelManager.ChallengeHighScore)
            {
                LevelManager.ChallengeHighScore = Score;
                PlayerPrefs.SetInt("LevelManager.ChallengeHighScore", Score);
                LevelManager.HighscoreUI.GetComponent<TextMeshPro>().text = Score.ToString();

                if (Score >= 100)
                {
                    LevelManager.RankingUI.GetComponent<TextMeshPro>().text = "S+";
                    PlayerPrefs.SetString("LevelManager.RankingUI", "S+");
                }

                else if  (Score > 90)
                {
                    LevelManager.RankingUI.GetComponent<TextMeshPro>().text = "S";
                    PlayerPrefs.SetString("LevelManager.RankingUI", "S");
                }

                else if (Score > 80)
                {
                    LevelManager.RankingUI.GetComponent<TextMeshPro>().text = "A+";
                    PlayerPrefs.SetString("LevelManager.RankingUI", "A+");
                }

                else if (Score > 70)
                {
                    LevelManager.RankingUI.GetComponent<TextMeshPro>().text = "A";
                    PlayerPrefs.SetString("LevelManager.RankingUI", "A");
                }

                else if (Score > 60)
                {
                    LevelManager.RankingUI.GetComponent<TextMeshPro>().text = "A-";
                    PlayerPrefs.SetString("LevelManager.RankingUI", "A-");
                }

                else if (Score > 50)
                {
                    LevelManager.RankingUI.GetComponent<TextMeshPro>().text = "B";
                    PlayerPrefs.SetString("LevelManager.RankingUI", "B");
                }

                else if (Score > 40)
                {
                    LevelManager.RankingUI.GetComponent<TextMeshPro>().text = "C";
                    PlayerPrefs.SetString("LevelManager.RankingUI", "C");
                }

                else if (Score > 30)
                {
                    LevelManager.RankingUI.GetComponent<TextMeshPro>().text = "D";
                    PlayerPrefs.SetString("LevelManager.RankingUI", "D");
                }

                else if (Score > 20)
                {
                    LevelManager.RankingUI.GetComponent<TextMeshPro>().text = "E";
                    PlayerPrefs.SetString("LevelManager.RankingUI", "E");
                }

                else
                {
                    LevelManager.RankingUI.GetComponent<TextMeshPro>().text = "F";
                    PlayerPrefs.SetString("LevelManager.RankingUI", "F");
                }
                PlayerPrefs.Save();

            }
        }

        StartCoroutine(WaitAndSetActive(2));
        FailMenu.SetActive(true);
        OnLoose?.Invoke();
        Move.PlayEnabled = false;
    }

    public void AddScore()
    {
        {
            Score += 1;
            ScorePoints.GetComponent<Text>().text = Score.ToString();

            ScorePoints.GetComponent<Animator>().SetTrigger("TrScored");
            ScoreLogo.GetComponent<Animator>().SetTrigger("TrGain Points");

            int randomIndex = UnityEngine.Random.Range(0, ScoreSounds.Length);
            AudioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
            AudioSource.clip = ScoreSounds[randomIndex];
            AudioSource.pitch = (1);
            AudioSource.Play();

            if (ChallengeMode == true)
            {
                rb.AddForce(0, 0.2f, 0);
            }
        }
    }

    public void LooseHealth()
    {
        Health -= 1;

        HealthPoints.GetComponent<Text>().text = Health.ToString();

        HealthPoints.GetComponent<Animator>().SetTrigger("TrHealth Loss");
        HealthLogo.GetComponent<Animator>().SetTrigger("TrLose Health");

        if (Health == 0)
        {
            Loose();
        }
    }

    public void Win()
    {
        Move.PlayEnabled = false;
        AddCounter = AddCounter + 1;
        Music.SetActive(false);
        SuccessMenu.SetActive(true);
        // Store the initial velocity before starting the slowdown
        initialVelocity = rb.velocity;
        int randomIndex = UnityEngine.Random.Range(0, WinSounds.Length);

        // Start the slowdown coroutine
        StartCoroutine(SlowDown(2));
        AudioSource.clip = WinSounds[randomIndex];
        AudioSource.Play();

        if (AddCounter == 3)
        {
            AddCounter = 0;
        }

        if (Winimages.Length > 0)
        {
            // Select a random image
            int randomImageIndex = UnityEngine.Random.Range(0, Winimages.Length);
            Sprite selectedImage = Winimages[randomImageIndex];

            EndSuprise.GetComponent<Image>().sprite = selectedImage;
            EndSuprise.SetActive(true);
        }

        else
        {
            Debug.LogWarning("No images assigned to the images array.");
        }

        SetLevelCompleted(GameLevel,Score);
        OnWin?.Invoke();
        Move.PlayEnabled = false;
    }

    /*IEnumerator WaitAndAddForce(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        rb.AddForce(0, 0, MoveSpeed, ForceMode.VelocityChange);
    }*/
    IEnumerator WaitAndSetActive(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);

        rb.AddForce(0, 0, 3, ForceMode.VelocityChange);
    }

    IEnumerator SlowDown(float duration)
    {
        // Store the initial velocity before starting the slowdown
        initialVelocity = rb.velocity;

        // Calculate the required deceleration to reach zero velocity over the duration
        float deceleration = initialVelocity.z / duration;

        // Track the elapsed time for the slowdown
        float elapsedTime = 0f;

        // Gradually reduce the velocity over time
        while (elapsedTime < duration)
        {
            // Calculate the current deceleration force
            float slowdownForce = Mathf.Min(deceleration, rb.velocity.magnitude / Time.deltaTime);

            // Apply the slowdown force in the opposite direction of the initial velocity
            rb.AddForce(0, 0, -slowdownForce, ForceMode.Force);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        // Ensure the final velocity is exactly 0 to avoid overshooting
        rb.velocity = Vector3.zero;

        // Optionally, you can stop updating once the slowdown is complete
        enabled = false;
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }


    public void SetLevelCompleted(string gameLevel, int score)
    {
        int levelIndex = int.Parse(gameLevel.Substring(1)) - 1;

        levelCompleted[levelIndex] = true;
        PlayerPrefs.SetInt("Level" + (levelIndex + 1) + "Completed", 1);

        if (score > levelScore[levelIndex])
        {
            levelScore[levelIndex] = score;
            PlayerPrefs.SetInt("Level" + (levelIndex + 1) + "Score", score);

            if (levelScore[levelIndex] >= Star3Thresholds[levelIndex])
            {
                levelStars[levelIndex] = 3;
                Debug.Log("3 Stars awarded with a score of: "+levelScore[levelIndex]+" Star3 Thresholds: "+Star3Thresholds[levelIndex]);
            }
            else if (levelScore[levelIndex] >= Star2Thresholds[levelIndex])
            {
                levelStars[levelIndex] = 2;
                Debug.Log("2 Stars awarded with a score of:" + levelScore[levelIndex] + " Star2 Thresholds: " + Star2Thresholds[levelIndex]);
            }
            else
            {
                levelStars[levelIndex] = 1;
                Debug.Log("1 Stars awarded with a score of:" + levelScore[levelIndex]);
            }
            PlayerPrefs.SetInt("Level" + (levelIndex + 1) + "Stars", levelStars[levelIndex]);
        }
        PlayerPrefs.Save();
        
    }  
}
