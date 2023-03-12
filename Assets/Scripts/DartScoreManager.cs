using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DartScoreManager : MonoBehaviour
{
    private bool player1 = true;
    private bool player2 = false;
    public int p1Score = 0;
    public int p2Score = 0;

    public TMP_Text scoreText;

    public void displayScore(int num)
    {
        scoreText.text = num.ToString();
    }

    public void displayMsg(string msg)
    {
        scoreText.text = msg;
    }
}
