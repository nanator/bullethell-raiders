using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject winningUI;

    // Start is called before the first frame update
    void Start()
    {
        //int height = Screen.currentResolution.height;
        //int width = Screen.currentResolution.width;
        Screen.SetResolution(1080, 1920, true);
        
        //Screen.SetResolution(height, width, true);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            SceneManager.UnloadScene(1);
            SceneManager.UnloadScene(2);
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOVER");
        gameOverUI.SetActive(true);
        Invoke("Restart", 3);
    }
    public void Won()
    {
        Debug.Log("YouWon!");
        winningUI.SetActive(true);
        Invoke("Restart", 3);

    }

    public void Restart()
    {
        SceneManager.LoadScene(0); //man kann auch verschiedene level laden LoadScene("name")
    }

}
