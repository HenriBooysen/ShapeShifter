using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VolumemuteToggle : MonoBehaviour
{
    public Button VolumeMuteOn;
    public Button VolumeMuteOff;

    public GameObject VolumeOn;
    public GameObject VolumeOff;

    //private bool isMuted;

    // Start is called before the first frame update
    void Start()
    {
        VolumeMuteOff.onClick.AddListener(DontMuteVolume);
        VolumeMuteOn.onClick.AddListener(MuteVolume);
    }

    void DontMuteVolume()
    {
        //isMuted = false;
        VolumeOff.SetActive(true);
        VolumeOn.SetActive(false);
        AudioListener.volume = 1;
    }

    void MuteVolume()
    {
        //isMuted = true;
        VolumeOn.SetActive(true);
        VolumeOff.SetActive(false);
        AudioListener.volume = 0;
    }
}
