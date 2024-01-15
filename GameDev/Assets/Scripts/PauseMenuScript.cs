using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool paused;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void MainMenu()
    {
        //Scene scene = SceneManager.GetActiveScene();
        //GameObject player = GameObject.Find("Player");
        //switch (scene.name) {
        //    case "TestMap":
        //        SaveSystem.SavePlayerPosition(new PlayerData(player.transform.position, 0));
        //        PlayerPrefs.SetInt("TutorialSaved", 1);
        //        break;
        //    case "Level 1":
        //        SaveSystem.SavePlayerPosition(new PlayerData(player.transform.position, 1));
        //        PlayerPrefs.SetInt("Level1Saved", 1);
        //        break;
        //    case "Level 2":
        //        SaveSystem.SavePlayerPosition(new PlayerData(player.transform.position, 2));
        //        PlayerPrefs.SetInt("Level2Saved", 1);
        //        break;
        //    case "Level3":
        //        SaveSystem.SavePlayerPosition(new PlayerData(player.transform.position, 3));
        //        PlayerPrefs.SetInt("Level3Saved", 1);
        //        break;
        //}

        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "TestMap":
                PlayerPrefs.SetInt("TutorialSaved", 0);
                break;
            case "Level 1":
                PlayerPrefs.SetInt("Level1Saved", 0);
                break;
            case "Level 2":
                PlayerPrefs.SetInt("Level2Saved", 0);
                break;
            case "Level3":
                PlayerPrefs.SetInt("Level3Saved", 0);
                break;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu?.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
}
