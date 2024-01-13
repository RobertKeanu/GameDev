using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1EndScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Level2Unlock", 1);
            SceneManager.LoadScene("Level 2");
        }
    }
}