using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private TMP_Text volumeValue = null;
    [SerializeField] private Slider volumeSlider = null;
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeValue.text = volume.ToString("0.00");
    }

    public void ApplyVolume()
    {
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
    }

    public void ResetVolume()
    {
        SetVolume(0.50f);
        volumeSlider.value = 0.50f;
    }

    public void Start()
    {
        if (name == "Settings Menu")
        {
            volumeValue.text = PlayerPrefs.GetFloat("Volume").ToString("0.00");
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");

        }
    }

    public void Awake()
    {
        //PlayerPrefs.SetInt("Level3Unlock", 0);
        //PlayerPrefs.SetInt("Level2Unlock", 0);
        //PlayerPrefs.SetInt("Level1Unlock", 0);
        var children = GetComponentInChildren<Transform>();
        foreach (Transform child in children)
        {
            if(child.gameObject.name == "Level 1")
                if(PlayerPrefs.GetInt("Level1Unlock") == 1)
                    child.gameObject.SetActive(true);
            if (child.gameObject.name == "Level 2")
                if (PlayerPrefs.GetInt("Level2Unlock") == 1)
                    child.gameObject.SetActive(true);
            if (child.gameObject.name == "Level 3")
                if (PlayerPrefs.GetInt("Level3Unlock") == 1)
                    child.gameObject.SetActive(true);
        }

    }

    public void NewGame(bool newGame)
    {

        switch (name)
        {
            case "Tutorial Menu":
                if(newGame)
                    PlayerPrefs.SetInt("TutorialSaved", 0);
                SceneManager.LoadScene("TestMap");
                break;
            case "Level 1 Menu":
                if(newGame)
                    PlayerPrefs.SetInt("Level1Saved", 0);
                SceneManager.LoadScene("Level 1");
                break;
            case "Level 2 Menu":
                if(newGame)
                    PlayerPrefs.SetInt("Level2Saved", 0);
                SceneManager.LoadScene("Level 2");
                break;
            case "Level 3 Menu":
                if(newGame)
                    PlayerPrefs.SetInt("Level3Saved", 0);
                SceneManager.LoadScene("Level3");
                break;
            }
    }

}
