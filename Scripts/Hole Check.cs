using JetBrains.Annotations;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Net.NetworkInformation;

// This Script runs when the Player Triggers a trigger by coliding with an object and compares the names and materiaals to determine what points to add or subtract
public class ShapeCollisionChecker : MonoBehaviour
{
    //public Move MoveSpeed;
    public CameraAnimation CrashedAnimation;
    public ShapeSpawner CurrentShape;
    public CatChanger CatChanger;

    public GameObject MainCharacter;
    public GameObject PlayerShape;
    public GameObject FailMenu;
    public GameObject SuccessMenu;
    public GameObject PauseMenu;
    public GameObject Camera;

    public int AnimationIndex;
    public int CurrentColorIndex;

    void Start()
    {
        //Debug.Log(CurrentShape.name + " Hole Check Initialize");       
    }

    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        ScoreSystem scoreSystem = FindObjectOfType<ScoreSystem>();

        AnimationIndex = CatChanger.currentAnimationIndex;
        CurrentColorIndex = CatChanger.CurrentColor;

        Debug.Log("Shape has Collided");

        // Get the name of the colliding object
        string holeName = other.gameObject.name;
        string holeColor = other.gameObject.GetComponent<Renderer>().material.name;

        Debug.Log(holeName + holeColor + " Colidided object name and color");

        // Extract the shape type from the shape name (e.g., "Cube" from "Cube(Clone)")

        bool correctShape = false;
        bool correctColor = false;

        string AnimationName = GetAnimationName(AnimationIndex);
        string CurrentColor = GetColorName(CurrentColorIndex);

        ShapeCompare();

        if(correctShape == true)
        {
            ColorCompare();
        }

        bool ShapeCompare()
        {
            if (AnimationName.ToLower().Contains("sitting") && holeName.ToLower().Contains("sitting"))
                correctShape = true;
            else if (AnimationName.ToLower().Contains("sleeping") && holeName.ToLower().Contains("sleeping"))
                correctShape = true;
            else if (AnimationName.ToLower().Contains("scared") && holeName.ToLower().Contains("scared"))
                correctShape = true;
            else if (AnimationName.ToLower().Contains("jumping") && holeName.ToLower().Contains("jump"))
                correctShape = true;
            else if (AnimationName.ToLower().Contains("supercat") && holeName.ToLower().Contains("supercat"))
                correctShape = true;
            else if (holeName.ToLower().Contains("end"))
                {
                scoreSystem.Win();
                enabled = false;
                }
            else
            {
                if (scoreSystem != null)
                {               
                    scoreSystem.Loose();
                }
                else
                {
                    Debug.LogError("ScoreSystem script not found.");
                }
            }
            return correctShape;

        }

        void ColorCompare()
        {
            if (CurrentColor.ToLower().Contains("orange") && holeColor.ToLower().Contains("orange"))
            {
                correctColor = true;
            }
            if (CurrentColor.ToLower().Contains("green") && holeColor.ToLower().Contains("green"))
            {
                correctColor = true;
            }
            if (CurrentColor.ToLower().Contains("yellow") && holeColor.ToLower().Contains("yellow"))
            {
                correctColor = true;
            }
            if (CurrentColor.ToLower().Contains("blue") && holeColor.ToLower().Contains("blue"))
            {
                correctColor = true;
            }
            if (CurrentColor.ToLower().Contains("black") && holeColor.ToLower().Contains("black"))
            {
                correctColor = true; 
            }

            if (!correctColor)
            {
                scoreSystem.LooseHealth();
                scoreSystem.AddScore();
            }
            if(correctColor)
            {
                scoreSystem.AddScore();
            }

            
        }

        static string GetAnimationName(int AnimationIndex)
        {
            switch (AnimationIndex) 
            {
                case 0: return "Sitting";
                case 1: return "Sleeping";
                case 2: return "Scared";
                case 3: return "Jumping";
                case 4: return "SuperCat";
                default: return "None";
            }
        }

        static string GetColorName(int CurrentColorIndex)
        {
            switch (CurrentColorIndex)
            {
                case 0: return "Orange";
                case 1: return "Blue";
                case 2: return "Yellow";
                case 3: return "Green";
                case 4: return "Black";
                default: return "None";
            }
        }
    }
}


   

  

