using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int Level1Score;
    public bool Level1Completed = false;



    void Awake()
    {
        // Ensure only one instance of the GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}