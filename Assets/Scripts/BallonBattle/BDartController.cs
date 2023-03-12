using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class BDartController : MonoBehaviour
{
    public GameObject dartPrefab;
    public Transform DartThrowPoint;
    private Rigidbody rb;
    private GameObject DartTemp;
    ARSessionOrigin aRSession;
    GameObject ARCam;

    private void Start()
    {
        aRSession = GameObject.Find("AR Session Origin").GetComponent<ARSessionOrigin>();
        ARCam = aRSession.transform.Find("AR Camera").gameObject;
    }
    public void shootDart()
    {
        DartTemp = Instantiate(dartPrefab, DartThrowPoint.position, ARCam.transform.rotation);
        DartTemp.transform.parent = ARCam.transform;
    }

}
