using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ResetEverything : MonoBehaviour
{
    [SerializeField] ARSession ARs;

    public void resetARSession()
    {
        ARs.Reset();
    }
    
}
