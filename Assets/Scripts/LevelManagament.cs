using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagament : MonoBehaviour
{
    public Text highscoretxt;

    private void Start()
    {
        int highscore = PlayerPrefs.GetInt("Highscore");
        highscoretxt.text = "High Score = " + highscore.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Quit Game");
        }
    }
}
