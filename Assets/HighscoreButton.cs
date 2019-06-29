using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreButton : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject HighscoreScreen;

    // Update is called once per frame
    
    public void showHighscore()
    {
        MainMenu.SetActive(false);
        HighscoreScreen.SetActive(true);
        Invoke("showMain", 10);
    }

    public void showMain()
    {
        MainMenu.SetActive(true);
        HighscoreScreen.SetActive(false);
    }
}
