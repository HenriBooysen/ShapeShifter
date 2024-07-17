using UnityEngine;
using UnityEngine.UI;
//Changes the Shapes and Colors of the Main character
public class ShapeSpawner : MonoBehaviour
{
    public WallSegementSpawner wallSegementSpawnerReference;

    public WallSegementSpawner colorDifficultyReference;
    public WallSegementSpawner shapeDifficultyReference;

    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject trianglePrefab;
    public GameObject starPrefab;
    public GameObject monkeyPrefab;

    public Material[] cubeMaterials;
    public Material[] sphereMaterials;
    public Material[] triangleMaterials;
    public Material[] starMaterials;
    public Material[] monkeyMaterials;

    public GameObject ShapeAudioSource;
    public GameObject ColorAudioSource;

    public GameObject spawnPosition;
    private Vector3 spawnPoint;

    public GameObject currentShape;
    public Material currentMaterial;
    public GameObject ParentObject;

    public Button ShapeButton;
    public Button ColorButton;

    public int shapeIndex = 0;
    public int colorIndex = 0;

    private bool isShapeButtonClicked;
    private bool isColorButtonClicked;

    void Awake()
    {

    }

    void Start()
    {
       colorDifficultyReference = GetComponent<WallSegementSpawner>();
       shapeDifficultyReference = GetComponent<WallSegementSpawner>();
       Debug.Log(currentShape.name + "Initialization phase");
       ShapeButton.onClick.AddListener(() => isShapeButtonClicked = true);
       ColorButton.onClick.AddListener(() => isColorButtonClicked = true);
    }

     public void Update()
    {
        //currentShapename = currentShape.name;
        //Debug.Log(currentShape.name + "Inititalization update");

        if (spawnPosition != null)
        {
            spawnPoint = spawnPosition.transform.position;
        }
        else
        {
            Debug.LogError("Spawn point is not assigned!");
        }

        if (Input.GetKeyDown(KeyCode.Q)|| isShapeButtonClicked)
        {
            isShapeButtonClicked = false;
            
            Destroy(currentShape);

            shapeIndex++;
            if (shapeIndex >= shapeDifficultyReference.ShapeDifficulty) shapeIndex = 0;

            ShapeAudioSource.GetComponent<AudioSource>().Play();

            switch (shapeIndex)
            {
                case 0:
                    currentShape = Instantiate(cubePrefab, spawnPoint, Quaternion.identity, ParentObject.transform);
                    currentMaterial = cubeMaterials[colorIndex];
                    break;
                case 1:
                    currentShape = Instantiate(spherePrefab, spawnPoint, Quaternion.identity, ParentObject.transform);
                    currentMaterial = sphereMaterials[colorIndex];
                    break;
                case 2:
                    currentShape = Instantiate(trianglePrefab, spawnPoint, Quaternion.Euler(-125, 180, 0), ParentObject.transform);
                    currentMaterial = triangleMaterials[colorIndex];
                    break;
                case 3:
                    currentShape = Instantiate(starPrefab, spawnPoint, Quaternion.Euler(-90, 0, 0), ParentObject.transform);
                    currentMaterial = starMaterials[colorIndex];
                    break;
                case 4:
                    currentShape = Instantiate(monkeyPrefab, spawnPoint, Quaternion.Euler(-90, 180, 0), ParentObject.transform);
                    currentMaterial = monkeyMaterials[colorIndex];
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) || isColorButtonClicked)
        {
            isColorButtonClicked = false;
            colorIndex++;
            if (colorIndex >= colorDifficultyReference.ColorDifficulty) colorIndex = 0;

            ColorAudioSource.GetComponent<AudioSource>().Play();

            if (currentShape != null)
            {
                string shapeName = currentShape.name.ToLower();

                Material[] materials = null;

                if (shapeName.Contains("cube"))
                    materials = cubeMaterials;
                else if (shapeName.Contains("sphere"))
                    materials = sphereMaterials;
                else if (shapeName.Contains("triangle"))
                    materials = triangleMaterials;
                else if (shapeName.Contains("star"))
                    materials = starMaterials;
                else if (shapeName.Contains("suzanne"))
                    materials = monkeyMaterials;

                if (materials != null)
                {
                    if (colorIndex >= 0 && colorIndex < materials.Length)
                    {
                        currentMaterial = materials[colorIndex];
                    }
                    else
                    {
                        Debug.LogError("Color index out of range for shape: " + shapeName);
                    }
                }
                else
                {
                    Debug.LogError("Matching object not found to add materials to: " + shapeName);
                }
                ChangeMaterial(currentShape, currentMaterial);
            }
            else
            {
                Debug.LogError("Current shape is null!");
            }
        }
    }

    void ChangeMaterial(GameObject shape, Material material)
    {
        Renderer shapeRenderer = shape.GetComponent<Renderer>();
        shapeRenderer.material = material;
    }
}
