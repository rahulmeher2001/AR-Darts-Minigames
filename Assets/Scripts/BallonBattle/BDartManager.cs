using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class BDartManager : MonoBehaviour
{
    public GameObject DartPrefab;
    public Transform DartThrowPoint;
    ARSessionOrigin aRSession;
    GameObject ARCam;
    private GameObject DartTemp;
    private Rigidbody rb;

    public static event Action onPlacedObject;

    // Start is called before the first frame update
    void Start()
    {
        aRSession = GameObject.Find("AR Session Origin").GetComponent<ARSessionOrigin>();
        ARCam = aRSession.transform.Find("AR Camera").gameObject;
    }

    public void OnEnable()
    {
        StartBDarts.startBDart += DartInit;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.CompareTag("dart"))
                {
                    //Disabling back touch collider from the dart
                    raycastHit.collider.enabled = false;
                    DartTemp.transform.parent=aRSession.transform;
                    Dart currentDartScript = DartTemp.GetComponent<Dart>();
                    currentDartScript.isForceOk = true;
                }
            }
        }
    }

    void DartInit()
    {
        StartCoroutine(WaitAndSpawnDart());
    }

    public IEnumerator WaitAndSpawnDart()
    {
        yield return new WaitForSeconds(0.5f);
        DartTemp = Instantiate(DartPrefab, DartThrowPoint.position, ARCam.transform.rotation);
        DartTemp.transform.parent = ARCam.transform;
        rb = DartTemp.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
}
