using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private Text ScoreText;

    private int Score = 0;  //Stores the Game Score

    public int GetScore()
    {
        return Score;
    }

    public void IncreaseScore(int _value)
    {
        Score += _value;

        ScoreText.text = "Score: " + Score;
    }
}
