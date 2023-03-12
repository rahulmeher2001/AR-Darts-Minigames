using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BScoreManager : MonoBehaviour
{
    public static int score;
    public float timer = 30f;
    public float incAmount=2f;

    public TMP_Text ScoreBoard;
    public TMP_Text TimerText;

    public void increaseTimer()
    {
        timer += incAmount;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBoard.text = score.ToString();
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            SceneManager.LoadScene("BRes");
        }

        float secs = Mathf.FloorToInt(timer % 60);

        TimerText.text = secs.ToString();
    }
}
