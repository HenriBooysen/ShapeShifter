using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WallSegementSpawner : MonoBehaviour
{
    public GameObject Wall;

    // Holes
    public GameObject ScaredHole;
    public GameObject SittingHole;
    public GameObject SleepingHole;
    public GameObject JumpingHole;
    public GameObject SuperHole;

    public GameObject FinishLine;

    // Wall Materiaals
    public Material YellowWall;
    public Material BlueWall;
    public Material OrangeWall;
    public Material GreenWall;
    public Material BlackWall;

    // Sitting Hole Materials
    public Material YellowSittingHole;
    public Material BlueSittingHole;
    public Material OrangeSittingHole;
    public Material GreenSittingHole;
    public Material BlackSittingHole;

    // Sleeping Hole Materials
    public Material YellowSleepingHole;
    public Material BlueSleepingHole;
    public Material OrangeSleepingHole;
    public Material GreenSleepingHole;
    public Material BlackSleepingHole;

    // Jumping Hole Materials
    public Material YellowJumpingHole;
    public Material BlueJumpingHole;
    public Material OrangeJumpingHole;
    public Material GreenJumpingHole;
    public Material BlackJumpingHole;

    // Super Hole Materials
    public Material YellowSuperHole;
    public Material BlueSuperHole;
    public Material OrangeSuperHole;
    public Material GreenSuperHole;
    public Material BlackSuperHole;

    // Scared Hole Materials
    public Material YellowScaredHole;
    public Material BlueScaredHole;
    public Material OrangeScaredHole;
    public Material GreenScaredHole;
    public Material BlackScaredHole;

    /*// wall positions
    private Vector3 Center;
    private Vector3 CenterL;
    private Vector3 CenterR;

    private Vector3 Top;
    private Vector3 TopL;
    private Vector3 TopR;

    private Vector3 Bottom;
    private Vector3 BottomL;
    private Vector3 BottomR;*/

    // Distance between wall Segmetns in the Z
    int Spacing = 20;

    //Amount of segments
    public int AmountofSegments = 10;

    //Difficulty Color
    public int ColorDifficulty;

    //Difficulty Shapes

    public int ShapeDifficulty;

    Vector3[] positions = new Vector3[9];

    // 2 for 1 line 5 for 2 lines and 8 for 3 lines. 
    public int VerticalDifficulty = 8;


    // Start is called before the first frame update
    void Start()
    {
        //Center Line Position
        positions[0] = new Vector3(-0.140000001f+0.34f, 6.21000004f-1.5f, -3.27600002f);
        positions[1] = new Vector3(-0.140000001f+0.34f - 3f, 6.21000004f-1.5f, -3.27600002f);
        positions[2] = new Vector3(-0.140000001f+0.34f + 3f, 6.21000004f - 1.5f, -3.27600002f);

        //Top line positions
        positions[3] = new Vector3(-0.140000001f+0.34f, 6.21000004f-1.5f + 3f, -3.27600002f);
        positions[4] = new Vector3(-0.140000001f+0.34f - 3f, 6.21000004f-1.5f + 3f, -3.27600002f);
        positions[5] = new Vector3(-0.140000001f+0.34f + 3f, 6.21000004f-1.5f + 3f, -3.27600002f);

        //Bottom line positions
        positions[6] = new Vector3(-0.140000001f+0.34f, 6.21000004f-1.5f - 3f, -3.27600002f);
        positions[7] = new Vector3(-0.140000001f+0.34f - 3f, 6.21000004f-1.5f - 3f, -3.27600002f);
        positions[8] = new Vector3(-0.140000001f+0.34f + 3f, 6.21000004f-1.5f - 3f, -3.27600002f);

        for (int i = 1; i <= AmountofSegments; i++)
        {
            // 0 = Orange    1 = Blue    2 = Yellow     3 = Green   4 = Black
            int randomColor = UnityEngine.Random.Range(0, ColorDifficulty);

            int randomHolePosition = UnityEngine.Random.Range(0, VerticalDifficulty + 1);

            Vector3 HolePosition = positions[randomHolePosition];

            List<Vector3> WallPositions = new List<Vector3>(positions);
            WallPositions.RemoveAt(randomHolePosition);

            // 0 = Sitting  1 = Sleeping    2 = Scared    3 = Jumping    4 = Super
            int randomHoleType = UnityEngine.Random.Range(0, ShapeDifficulty);

            for (int j = 0; j < 8; j++)
            {
                GameObject SpanWall =Instantiate(Wall, WallPositions[j] + new Vector3(0, 0, Spacing * i), Quaternion.Euler(-90,-90,0));
                Renderer SpawnedWallRenderer = SpanWall.GetComponent<Renderer>();
                
                switch (randomColor)
                {
                    case 0:
                        SpawnedWallRenderer.material = OrangeWall;
                        break;

                    case 1:
                        SpawnedWallRenderer.material = BlueWall;
                        break;

                    case 2:
                        SpawnedWallRenderer.material = YellowWall;
                        break;

                    case 3:
                        SpawnedWallRenderer.material = GreenWall;
                        break;

                    case 4:
                        SpawnedWallRenderer.material = BlackWall;
                        break;
                }
            }



            switch (randomHoleType)

            {
                case 0: // Sitting

                    GameObject SpawnedHole = Instantiate(SittingHole, HolePosition + new Vector3(0, 0, Spacing * i), Quaternion.Euler(-90, -270, 0));
                    Renderer SpawnedHoleRender = SpawnedHole.GetComponent<Renderer>();

                    switch (randomColor)
                    {
                        case 0:

                            SpawnedHoleRender.material = OrangeSittingHole;
                            break;

                        case 1:

                            SpawnedHoleRender.material = BlueSittingHole;

                            break;
                        case 2:

                            SpawnedHoleRender.material = YellowSittingHole;
                            break;

                        case 3:

                            SpawnedHoleRender.material = GreenSittingHole;
                            break;

                        case 4:

                            SpawnedHoleRender.material = BlackSittingHole;
                            break;
                    }
                    break;

                // Sleeping
                case 1:
                    GameObject SpawnedHole1 = Instantiate(SleepingHole, HolePosition + new Vector3(0, 0, Spacing * i), Quaternion.Euler(-90, -90,0));
                    Renderer SpawnedHoleRender1 = SpawnedHole1.GetComponent<Renderer>();

                    switch (randomColor)
                    {
                        case 0:

                            SpawnedHoleRender1.material = OrangeSleepingHole;
                            break;

                        case 1:

                            SpawnedHoleRender1.material = BlueSleepingHole;

                            break;
                        case 2:

                            SpawnedHoleRender1.material = YellowSleepingHole;
                            break;

                        case 3:

                            SpawnedHoleRender1.material = GreenSleepingHole;
                            break;

                        case 4:

                            SpawnedHoleRender1.material = BlackSleepingHole;
                            break;
                    }
                    break;

                // Scared
                case 2:
                    GameObject SpawnedHole2 = Instantiate(ScaredHole, HolePosition + new Vector3(0, 0, Spacing * i), Quaternion.Euler(-90, -90, 0));
                    Renderer SpawnedHoleRender2 = SpawnedHole2.GetComponent<Renderer>();

                    switch (randomColor)
                    {
                        case 0:

                            SpawnedHoleRender2.material = OrangeScaredHole;
                            break;

                        case 1:

                            SpawnedHoleRender2.material = BlueScaredHole;

                            break;
                        case 2:

                            SpawnedHoleRender2.material = YellowScaredHole;
                            break;

                        case 3:

                            SpawnedHoleRender2.material = GreenScaredHole;
                            break;

                        case 4:

                            SpawnedHoleRender2.material = BlackScaredHole;
                            break;

                    }
                    break;

                // Jumping
                case 3:
                    GameObject SpawnedHole3 = Instantiate(JumpingHole, HolePosition + new Vector3(0, 0, Spacing * i), Quaternion.Euler(-90, -90, 0));
                    Renderer SpawnedHoleRender3 = SpawnedHole3.GetComponent<Renderer>();

                    switch (randomColor)
                    {
                        case 0:

                            SpawnedHoleRender3.material = OrangeJumpingHole;
                            break;

                        case 1:

                            SpawnedHoleRender3.material = BlueJumpingHole;

                            break;
                        case 2:

                            SpawnedHoleRender3.material = YellowJumpingHole;
                            break;

                        case 3:

                            SpawnedHoleRender3.material = GreenJumpingHole;
                            break;

                        case 4:

                            SpawnedHoleRender3.material = BlackJumpingHole;
                            break;

                    }
                    break;

                // Super
                case 4:
                    GameObject SpawnedHole4 = Instantiate(SuperHole, HolePosition + new Vector3(0, 0, Spacing * i), Quaternion.Euler(-90, -270, 0));
                    Renderer SpawnedHoleRender4 = SpawnedHole4.GetComponent<Renderer>();

                    switch (randomColor)
                    {
                        case 0:

                            SpawnedHoleRender4.material = OrangeSuperHole;
                            break;

                        case 1:

                            SpawnedHoleRender4.material = BlueSuperHole;

                            break;
                        case 2:

                            SpawnedHoleRender4.material = YellowSuperHole;
                            break;

                        case 3:

                            SpawnedHoleRender4.material = GreenSuperHole;
                            break;

                        case 4:

                            SpawnedHoleRender4.material = BlackSuperHole;
                            break;

                    }
                    break;
            }
        }
        GameObject SpawnFinishLine = Instantiate(FinishLine, positions[6] + new Vector3 (0, 2.5f, AmountofSegments * Spacing + 10), Quaternion.Euler(0,180,0));
    }
}

            

