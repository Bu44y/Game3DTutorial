using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    public Text scoretxt;

    
    void Update()
    {
        scoretxt.text = "Score = " + score.ToString();
    }

    public void killEnemy()
    {
        score += 10;
    }
}
