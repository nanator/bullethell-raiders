using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsScreen;

    // Update is called once per frame
    
    public void showCredits()
    {
        MainMenu.SetActive(false);
        CreditsScreen.SetActive(true);
        Invoke("showMain", 5);
    }

    public void showMain()
    {
        MainMenu.SetActive(true);
        CreditsScreen.SetActive(false);
    }
}
