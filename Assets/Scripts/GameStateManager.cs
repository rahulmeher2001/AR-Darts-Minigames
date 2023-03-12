using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static int playerCount = 3;
    public static int p1Score = 0;
    public static int p2Score = 0;
    public static int p3Score = 0;
    public static int playerTurn = 0;

    public void setPlayerCount1()
    {
        playerCount = 1;
        SceneManager.LoadScene("Darts2Scene");
    }
    public void setPlayerCount2()
    {
        playerCount = 2;
        SceneManager.LoadScene("Darts2Scene");
    }
    public void setPlayerCount3()
    {
        playerCount = 3;
        SceneManager.LoadScene("Darts2Scene");
    }

    public void viewResults()
    {
        SceneManager.LoadScene("DartsResults");
    }

    public void launchDarts()
    {
        SceneManager.LoadScene("DartsTitlePage");
    }
    public void launchBalloons()
    {
        SceneManager.LoadScene("RebootBalloon");
    }
}
