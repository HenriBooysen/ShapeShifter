using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuaseToggle : MonoBehaviour
{
    public Button PauseButton;
    public int Pausevalue = 1;
    public GameObject PauseMenu;
    public GameObject Music;
    public Button ResumeButton;
    // Start is called before the first frame update
    void Start()
    {
        PauseButton.onClick.AddListener(PauseCheck);
        ResumeButton.onClick.AddListener(PauseCheck);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PauseCheck()
    {
        if (Pausevalue < 0)
        {
            Pausevalue = Pausevalue * -1;
            Unpause();            
        }

        else
        {
            Pausevalue = Pausevalue * -1;
            Pause();           
        }
    }

    void Pause()
    {
        Move.PlayEnabled = false;
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        AudioSource MusicPause = Music.GetComponentInChildren<AudioSource>();
        MusicPause.Pause();
    }

    void Unpause()
    {
        PauseMenu.SetActive(false);
        StartCoroutine(UnpauseCoroutine());
        AudioSource MusicPause = Music.GetComponentInChildren<AudioSource>();
        MusicPause.UnPause();
    }

    IEnumerator UnpauseCoroutine()
    {
        float duration = 1f; // Duration of the lerping process
        float elapsedTime = 0f; // Elapsed time since lerping started

        // Smoothly lerp the time scale from 0 to 1 over the specified duration
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration; // Normalized time value (0 to 1)
            Time.timeScale = Mathf.Lerp(0f, 1f, t); // Lerp between 0 and 1
            elapsedTime += Time.unscaledDeltaTime; // Increment elapsed time
            yield return null; // Wait for the next frame
        }

        Time.timeScale = 1; // Ensure the time scale is exactly 1 at the end
        Move.PlayEnabled = true;
    }
}
