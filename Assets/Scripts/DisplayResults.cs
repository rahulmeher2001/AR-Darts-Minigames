using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayResults : MonoBehaviour
{
    public TMP_Text p1s;
    public TMP_Text p2s;
    public TMP_Text p3s;

    // Start is called before the first frame update
    void Start()
    {
        p1s.text = GameStateManager.p1Score.ToString();
        p2s.text = GameStateManager.p2Score.ToString();
        p3s.text = GameStateManager.p3Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
