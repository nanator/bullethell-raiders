using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(768, 1024, true);
    }

    public void GameOver()
    {
        Debug.Log("GameOVER");
        gameOverUI.SetActive(true);
        Invoke("Restart", 3);
    }

    void Restart()
    {
        SceneManager.LoadScene(0); //man kann auch verschiedene level laden LoadScene("name")
    }
}
