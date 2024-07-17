using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    void Awake()
    {
        // Add listener to the button
        GetComponent<Button>().onClick.AddListener(Restart);
    }

    void Restart()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
