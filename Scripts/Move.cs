using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Move : MonoBehaviour
{
    public GameObject PlayerObject;
    //public float MoveSpeed = 10f;
    
    public bool VerticalEnable = true;
    public int LateralMovement = 0;
    public int VerticalMovement = 0;
    public bool upmovement;
    public bool downmovement;

    public GameObject LateralAudioSource;
    public GameObject VerticalAudioSource;

    private Vector2 initialTouchPosition;
    private Vector2 touchDelta;

    
    public static bool PlayEnabled = true; // set by Pause Toggle script
    void Start()
    {
       //VerticalAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Handle touch input
        if (PlayEnabled == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        initialTouchPosition = touch.position;
                        break;

                    case TouchPhase.Moved:
                        touchDelta = touch.position - initialTouchPosition;
                        // Implement logic for moving the object based on touchDelta
                        // use touchDelta.x and touchDelta.y to determine the direction.

                        if (touchDelta.x < 0 && LateralMovement < 1)
                        {
                            LateralAudioSource.GetComponent<AudioSource>().pitch = (UnityEngine.Random.Range(0.8f,1.2f));
                            LateralAudioSource.GetComponent<AudioSource>().Play();
                            LateralMovement++;
                            PlayerObject.transform.position += new Vector3(-3, 0, 0);                           
                        }

                        if (touchDelta.x > 0 && LateralMovement > -1)
                        {
                            LateralAudioSource.GetComponent<AudioSource>().pitch = (UnityEngine.Random.Range(0.8f, 1.2f));
                            LateralAudioSource.GetComponent<AudioSource>().Play();
                            LateralMovement--;
                            PlayerObject.transform.position += new Vector3(3, 0, 0);                           
                        }

                        if (touchDelta.y > 0 && VerticalMovement < 1)
                        {
                            if (upmovement == true)
                            {
                                VerticalAudioSource.GetComponent<AudioSource>().pitch = (UnityEngine.Random.Range(0.8f, 1.2f));
                                VerticalAudioSource.GetComponent<AudioSource>().Play();
                                VerticalMovement++;
                                PlayerObject.transform.position += new Vector3(0, 3, 0);
                            }
                        }

                        if (touchDelta.y < 0 && VerticalMovement > -1 && downmovement == true)
                        {
                            if (downmovement == true)
                            {
                                VerticalAudioSource.GetComponent<AudioSource>().pitch = (UnityEngine.Random.Range(0.8f, 1.2f));
                                VerticalAudioSource.GetComponent<AudioSource>().Play();
                                VerticalMovement--;
                                PlayerObject.transform.position += new Vector3(0, -3, 0);
                            }
                        }

                        break;

                    case TouchPhase.Ended:

                        break;
                }
            }

            // Handle keyboard input
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (LateralMovement < 1)
                {
                    LateralAudioSource.GetComponent<AudioSource>().pitch = (UnityEngine.Random.Range(0.8f, 1.2f));
                    LateralMovement++;
                    PlayerObject.transform.position += new Vector3(-3, 0, 0);
                    LateralAudioSource.GetComponent<AudioSource>().Play();
                }
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (LateralMovement > -1)
                {
                    LateralAudioSource.GetComponent<AudioSource>().pitch = (UnityEngine.Random.Range(0.8f, 1.2f));
                    LateralMovement--;
                    PlayerObject.transform.position += new Vector3(3, 0, 0);
                    LateralAudioSource.GetComponent<AudioSource>().Play();
                }
            }

            // Handle vertical movement
            if (VerticalEnable)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && upmovement == true)
                {
                    if (VerticalMovement < 1)
                    {
                        if (upmovement == true)
                        {
                            VerticalAudioSource.GetComponent<AudioSource>().pitch = (UnityEngine.Random.Range(0.8f, 1.2f));
                            VerticalMovement++;
                            PlayerObject.transform.position += new Vector3(0, 3, 0);
                            VerticalAudioSource.GetComponent<AudioSource>().Play();
                        }
                    }
                }
                else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow ) && downmovement == true)
                {
                    if (VerticalMovement > -1)
                    {
                        if (downmovement == true)
                        {
                            VerticalAudioSource.GetComponent<AudioSource>().pitch = (UnityEngine.Random.Range(0.8f, 1.2f));
                            VerticalMovement--;
                            PlayerObject.transform.position += new Vector3(0, -3, 0);
                            VerticalAudioSource.GetComponent<AudioSource>().Play();
                        }
                    }
                }
            }
        }
    }
}
