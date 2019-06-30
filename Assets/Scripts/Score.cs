using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public int score = 0;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        Debug.Log(Time.timeSinceLevelLoad);
        if (Time.timeSinceLevelLoad > 120.0f)
        {
            FindObjectOfType<GameManager>().Won();
            
        }
    }
}
