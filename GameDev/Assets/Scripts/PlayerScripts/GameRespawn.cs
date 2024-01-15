using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRespawn : MonoBehaviour
{
    [SerializeField]
    private float threshold = 17.0f;
    private Vector3 lastCheckpoint;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        switch (SceneManager.GetActiveScene().name)
        {
            case "TestMap":
                {
                    if (PlayerPrefs.GetInt("TutorialSaved") == 1)
                    {
                        var position = SaveSystem.LoadPlayer().tutorialPosition;
                        transform.position = position;
                        lastCheckpoint = position;
                    }
                    else
                    {
                        lastCheckpoint = playerTransform.position;
                    }
                    break;
                }
            case "Level 1":
                {
                    if (PlayerPrefs.GetInt("Level1Saved") == 1)
                    {
                        var position = SaveSystem.LoadPlayer().level1Position;
                        transform.position = position;
                        lastCheckpoint = position;
                    }
                    else
                    {
                        lastCheckpoint = playerTransform.position;
                    }
                    break;
                }
            case "Level 2":
                {
                    if (PlayerPrefs.GetInt("Level2Saved") == 1)
                    {
                        var position = SaveSystem.LoadPlayer().level2Position;
                        transform.position = position;
                        lastCheckpoint = position;
                    }
                    else
                    {
                        lastCheckpoint = playerTransform.position;
                    }
                    break;
                }
            case "Level3":
                {
                    if (PlayerPrefs.GetInt("Level3Saved") == 1)
                    {
                        var position = SaveSystem.LoadPlayer().level3Position;
                        transform.position = position;
                        lastCheckpoint = position;
                    }
                    else
                    {
                        lastCheckpoint = playerTransform.position;
                    }
                    break;
                }
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = lastCheckpoint;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            KillFunction();
        }
        else if (other.CompareTag("SpawnPoint"))
        {
            lastCheckpoint = transform.position;
            Scene scene = SceneManager.GetActiveScene();
            GameObject player = GameObject.Find("Player");
            switch (scene.name)
            {
                case "TestMap":
                    SaveSystem.SavePlayerPosition(new PlayerData(player.transform.position, 0));
                    PlayerPrefs.SetInt("TutorialSaved", 1);
                    break;
                case "Level 1":
                    SaveSystem.SavePlayerPosition(new PlayerData(player.transform.position, 1));
                    PlayerPrefs.SetInt("Level1Saved", 1);
                    break;
                case "Level 2":
                    SaveSystem.SavePlayerPosition(new PlayerData(player.transform.position, 2));
                    PlayerPrefs.SetInt("Level2Saved", 1);
                    break;
                case "Level3":
                    SaveSystem.SavePlayerPosition(new PlayerData(player.transform.position, 3));
                    PlayerPrefs.SetInt("Level3Saved", 1);
                    break;
            }
            Destroy(other.gameObject);
        }
    }

    public void KillFunction()
    {
        transform.position = lastCheckpoint;
    }
}
