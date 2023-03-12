using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartBDarts : MonoBehaviour
{
    public static event Action startBDart;
    public GameObject buttonStart;

    public void startBDartsGame()
    {
        startBDart?.Invoke();
        Destroy(buttonStart);
    }
}
