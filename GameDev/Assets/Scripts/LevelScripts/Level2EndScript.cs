using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2EndScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerPrefs.SetInt("Level3Unlock", 1);
            SceneManager.LoadScene("Level3");
        }
    }
}
