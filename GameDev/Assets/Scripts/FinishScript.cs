using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerObj")) {
            PlayerPrefs.SetInt("Level1Unlock", 1);
            SceneManager.LoadScene("Level 1");
        }
    }
}
