using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BResultsDisplay : MonoBehaviour
{
    public TMP_Text scoreboardTxt;

    // Start is called before the first frame update
    void Start()
    {
        scoreboardTxt.text = BScoreManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
