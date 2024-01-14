using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
    }

}
