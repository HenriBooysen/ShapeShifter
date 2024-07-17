using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatChanger : MonoBehaviour
{
    public WallSegementSpawner wallSegementSpawnerReference;
    public WallSegementSpawner shapeDifficultyReference;
    public WallSegementSpawner ColorDifficultyReference;

    public Animator animator;  // Reference to the Animator component

    public int currentAnimationIndex = 0;  // Index to keep track of the current animation
    private int totalAnimations;  // Total number of animations
    private bool isShapeButtonClicked;
   

    private Vector3 SleepingPosition = new Vector3(0.22f, -1.71f, 3.276f);
    private Vector3 ScaredPosition = new Vector3(0.51f, -2.597f, 3.276f);
    private Vector3 NormalPosition = new Vector3(0.22f, -2.28f, 3.276f);

    private bool isColorButtonClicked;

    public GameObject Cat;
    private int TotalColors;
    public int CurrentColor = 0;

    public Material OrangeCatMaterial;
    public Material BlueCatMaterial;
    public Material YellowCatMaterial;
    public Material GreenCatMaterial;
    public Material BlackCatMaterial;

    void Start()
    {
        // Log initial state
        Debug.Log("Start method called");

        // Log inspector-assigned references
        Debug.Log($"wallSegementSpawnerReference: {wallSegementSpawnerReference}");
        Debug.Log($"shapeDifficultyReference: {shapeDifficultyReference}");

        // If not assigned in the Inspector, try to find them in the scene
        if (wallSegementSpawnerReference == null)
        {
            wallSegementSpawnerReference = FindObjectOfType<WallSegementSpawner>();
            Debug.Log($"wallSegementSpawnerReference found: {wallSegementSpawnerReference}");
        }

        if (shapeDifficultyReference == null)
        {
            shapeDifficultyReference = GetComponent<WallSegementSpawner>();
            Debug.Log($"shapeDifficultyReference found on the same GameObject: {shapeDifficultyReference}");

            if (shapeDifficultyReference == null)
            {
                // Optionally, you can log a warning if the component is not found
                Debug.LogWarning("ShapeDifficultyReference not found on the same GameObject.");
            }
        }

        if (ColorDifficultyReference == null)
        {
            ColorDifficultyReference = GetComponent<WallSegementSpawner>();
            Debug.Log($"colorDifficultyReference found on the same GameObject: {ColorDifficultyReference}");

            if (ColorDifficultyReference == null)
            {
                // Optionally, you can log a warning if the component is not found
                Debug.LogWarning("ColorDifficultyReference not found on the same GameObject.");
            }
        }

        if (shapeDifficultyReference != null)
        {
            totalAnimations = shapeDifficultyReference.ShapeDifficulty;
            Debug.Log($"totalAnimations set to: {totalAnimations}");
            animator.SetInteger("AnimationIndex", currentAnimationIndex);
        }

        if (ColorDifficultyReference != null)
        {
            TotalColors = ColorDifficultyReference.ColorDifficulty;
            Debug.Log($"totalColors set to: {TotalColors}");
        }

        else
        {
            // Handle the case where shapeDifficultyReference is not assigned
            Debug.LogError("ShapeDifficultyReference is not assigned and could not be found.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || isShapeButtonClicked)
        {
            CycleAnimations();
        }

        if (Input.GetKeyDown (KeyCode.E) || isColorButtonClicked)
        {
            CycleColor();
        }
    }

    void CycleAnimations()
    {
        // Increase the animation index
        currentAnimationIndex++;

        // If the index exceeds the total number of animations, reset it
        if (currentAnimationIndex >= totalAnimations)
        {
            currentAnimationIndex = 0;
        }

        // Play the current animation based on the index
        animator.SetInteger("Animator", currentAnimationIndex);

        animator.Update(0);
    }

    public void Rotate()
    {
        Debug.Log("Rotate event triggred");
        // Apply rotation based on the current animation
        transform.rotation = Quaternion.Euler(0, -90, 0);

        Debug.Log($"Cat rotation after Rotate: {transform.rotation.eulerAngles}");
    }

    public void DontRotate()
    {
        Debug.Log("Dont Rotate event triggred");
        transform.rotation = Quaternion.Euler(0, 0, 0);

        Debug.Log($"Cat rotation after Dont Rotate: {transform.rotation.eulerAngles}");
    }
    public void ScaredAdjust()
    {
        transform.localPosition = ScaredPosition;
    }

    public void SleepingAdjust()
    {
        transform.localPosition = SleepingPosition;
    }
    public void NormalAdjust()
    {
        transform.localPosition = NormalPosition;
    }

    void CycleColor()
    {
        CurrentColor++;
        if (CurrentColor >= TotalColors)
        {
            CurrentColor = 0;
        }

        switch (CurrentColor) 
        {
            case 0: Cat.GetComponent<SkinnedMeshRenderer>().material = OrangeCatMaterial;
             break;

            case 1: Cat.GetComponent<SkinnedMeshRenderer>().material = BlueCatMaterial;
                break;

            case 2: Cat.GetComponent<SkinnedMeshRenderer>().material = YellowCatMaterial;
                break;

            case 3: Cat.GetComponent<SkinnedMeshRenderer>().material = GreenCatMaterial;
                break;

            case 4: Cat.GetComponent<SkinnedMeshRenderer>().material = BlackCatMaterial;
                break;
        }

        Debug.Log($"Color Changed to :{Cat.GetComponent<SkinnedMeshRenderer>().material} with color index at {CurrentColor} ");
    }

    void ForwardAdjust()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
  
