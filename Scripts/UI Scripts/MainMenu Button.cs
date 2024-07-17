using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    //public string MainMenu; 
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(MainMenuMethod);
    }

    // Update is called once per frame
    void MainMenuMethod()
    {
        // Reload the current scene
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}


    

   
