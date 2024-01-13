using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{
    //Varianta incercata cu delay din cauza inconsistentei loadului
    void Awake()
    {
        Rigidbody player = GameObject.Find("Player").GetComponent<Rigidbody>() ;
        StartCoroutine(Delay(player));
    }

    public IEnumerator Delay(Rigidbody player)
    {
        GameObject screen = GameObject.Find("Loading Screen");
        screen.SetActive(true); 
        yield return new WaitForSeconds(1f);
        switch (SceneManager.GetActiveScene().name)
        {
            case "TestMap":
                {
                    if (PlayerPrefs.GetInt("TutorialSaved") == 1)
                    {
                        var position = SaveSystem.LoadPlayer().tutorialPosition;
                        player.transform.position = position;
                        Debug.Log(player.transform.position);
                    }
                    break;
                }
            case "Level 1":
                {
                    Debug.Log(SceneManager.GetActiveScene().name);
                    if (PlayerPrefs.GetInt("Level1Saved") == 1)
                    {
                        var position = SaveSystem.LoadPlayer().level1Position;
                        player.transform.position = position;
                        Debug.Log(player.transform.position);
                    }
                    break;
                }
            case "Level 2":
                {
                    if (PlayerPrefs.GetInt("Level2Saved") == 1)
                    {
                        var position = SaveSystem.LoadPlayer().level2Position;
                        player.transform.position = position;
                        Debug.Log(player.transform.position);
                    }
                    break;
                }
            case "Level3":
                {
                    if (PlayerPrefs.GetInt("Level3Saved") == 1)
                    {
                        var position = SaveSystem.LoadPlayer().level3Position;
                        player.transform.position = position;
                        Debug.Log(player.transform.position);
                    }
                    break;
                }
        }

        GameObject.Find("Loading Screen").SetActive(false);

    }

}
