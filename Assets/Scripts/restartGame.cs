using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class restartGame : MonoBehaviour
{
    public  void restartDaGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void helpScreen()
    {
        SceneManager.LoadScene("HelpScreen");
    }
}
