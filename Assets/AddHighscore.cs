using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AddHighscore : MonoBehaviour
{
    public InputField nameText;
    public Text scoreText;
    public string level;

    public void addHighScore()
    {
        //name und score werden aus den textfeldern gecastet, fuer spaetere uebergabe an addhighscore
        string name = nameText.text + "(L" + level + ")";
        int score = System.Convert.ToInt32(scoreText.text);

        //fuege highscore hinzu
        AddHighscoreEntry(score, name);
        //lade Menu
        SceneManager.LoadScene(0);
    }

    //fuege highscore in die playerprefs hinzu
    private void AddHighscoreEntry(int score, string name)
    {
        //ueberpruefe ob playerpref feld "highscoreTable" schon gesetzt ist, wenn nicht, dann erzeuge mit demo eintrag.
        setPrefIfNeeded();
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name};
        
        //hole den json string aus playerprefs
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        //erzeuge objekt von Form der Highscores Datenstruktur aus dem playerprefs json string
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //fuege neuen highscore in highscores objekt
        highscores.highscoreEntryList.Add(highscoreEntry);

        //forme die datenstruktur mit neuem eintrag in json zurueck, und speicher sie in playerprefs zurueck.
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    //ueberpruefe ob playerpref-feld "highscoreTable" gesetzt ist, falls nicht dann wird es hier gesetzt, mit einen demo eintrag.
    private void setPrefIfNeeded()
    {
        string s = PlayerPrefs.GetString("highscoreTable");
        List<HighscoreEntry> hsDemoList = new List<HighscoreEntry>(){
                new HighscoreEntry{score=1,name="demo"}
        };

        if (s == "")
        {
            Highscores highs = new Highscores { highscoreEntryList = hsDemoList };
            string json = JsonUtility.ToJson(highs);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
        }
    }
}

