using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public Move moveComponent;
    
    public ShapeCollisionChecker CameraCrash;
    public CameraAnimation CrashedAnimation;
    public ShapeSpawner ShapeSpawner;

    public int Health = 3;
    public int Score = 0;
    public TMP_Text countdownText;
    public GameObject PlayerShape;
    public GameObject FailMenu;
    public GameObject SuccessMenu;
    public GameObject PauseMenu;
    public GameObject Camera;

    public GameObject ScorePoints;
    public GameObject ScoreLogo;
    public GameObject HealthPoints;
    public GameObject HealthLogo;

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

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Crashspeed = -MoveSpeed - 3;
        AudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();


        StartCoroutine(CountdownAndScale());
    }
    private IEnumerator CountdownAndScale()
    {
        countdownText.gameObject.SetActive(true);

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
            Music.SetActive (false);
            Health = 0;
            HealthPoints.GetComponent<Text>().text = Health.ToString();

            int randomIndex = UnityEngine.Random.Range(0, FailSounds.Length);
            AudioSource.clip = FailSounds[randomIndex];
            AudioSource.Play();          

                if (rb != null)
                {
                    rb.AddForce(0,0,Crashspeed, ForceMode.VelocityChange);
                    
                    //CrashedAnimation.crahsed = true;
                     Debug.Log("Rigidbody detected");
                }
                 else { Debug.Log("No Rigidbody detected"); }

            HealthPoints.GetComponent<Animator>().SetTrigger("TrHealth Loss");
            HealthLogo.GetComponent<Animator>().SetTrigger("TrLose Health");
            Camera.GetComponent<Animator>().SetTrigger("TrCameraCrash");

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

        StartCoroutine(WaitAndSetActive(2));
        FailMenu.SetActive(true);
    }

        public void AddScore()
        {
            {
                Score += 1;
                ScorePoints.GetComponent<Text>().text = Score.ToString();

                ScorePoints.GetComponent<Animator>().SetTrigger("TrScored");
                ScoreLogo.GetComponent<Animator>().SetTrigger("TrGain Points");

                int randomIndex = UnityEngine.Random.Range(0, ScoreSounds.Length);
                AudioSource.clip = ScoreSounds[randomIndex];
                AudioSource.Play();
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
        Music.SetActive(false);
        SuccessMenu.SetActive(true);
        // Store the initial velocity before starting the slowdown
        initialVelocity = rb.velocity;
        int randomIndex = UnityEngine.Random.Range(0, WinSounds.Length);

        // Start the slowdown coroutine
        StartCoroutine(SlowDown(3));
        AudioSource.clip = WinSounds[randomIndex];
        AudioSource.Play();

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
    }
}