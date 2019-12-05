using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowHighscore : MonoBehaviour
{
    [SerializeField] private TextMeshPro scores;
    [SerializeField] private TextMeshPro names;

    private List<int> score;

    private List<string> name;

    void Start()
    {
        name = new List<string>();
        score = new List<int>();

        if (PlayerPrefs.GetString("player1Score", "no entry") == "no entry")
        {
            PlayerPrefs.SetInt("player1Score",0);
            PlayerPrefs.SetString("player1Name","AAA");
            PlayerPrefs.SetInt("player2Score",0);
            PlayerPrefs.SetString("player2Name", "AAA");
            PlayerPrefs.SetInt("player3Score",0);
            PlayerPrefs.SetString("player3Name", "AAA");
            PlayerPrefs.SetInt("player4Score",0);
            PlayerPrefs.SetString("player4Name", "AAA");
            PlayerPrefs.SetInt("player5Score",0);
            PlayerPrefs.SetString("player5Name", "AAA");
        }

        score.Add(PlayerPrefs.GetInt("player5Score"));
        score.Add(PlayerPrefs.GetInt("player4Score"));
        score.Add(PlayerPrefs.GetInt("player3Score"));
        score.Add(PlayerPrefs.GetInt("player2Score"));
        score.Add(PlayerPrefs.GetInt("player1Score"));
        
        name.Add(PlayerPrefs.GetString("player5Name"));
        name.Add(PlayerPrefs.GetString("player4Name"));
        name.Add(PlayerPrefs.GetString("player3Name"));
        name.Add(PlayerPrefs.GetString("player2Name"));
        name.Add(PlayerPrefs.GetString("player1Name"));

        string listScores = "";
        string listNames = "";

        score.ForEach(i => listScores += $"{i}\n");
        name.ForEach(i => listNames += $"{i}\n");

        scores.text = listScores;
        names.text = listNames;
    }

    void Update()
    {
        if(Input.GetAxis("A")>0)
            SceneManager.LoadScene("MainScene");
    }
}
