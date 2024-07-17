using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    private string CurrentScene;
    // Start is called before the first frame update
    void Awake()
    {
       CurrentScene = SceneManager.GetActiveScene().name;
       GetComponent<Button>().onClick.AddListener(LoadNextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadNextLevel()
    {
        // Extract the numeric part from the scene name
        string numericPart = CurrentScene.Substring(1);
        int currentLevel = int.Parse(numericPart);

        // Construct the name of the next scene
        string nextSceneName = "L" + (currentLevel + 1);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
