using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class BDart : MonoBehaviour
{
    private Rigidbody rg;
    private GameObject dirObj;
    public bool isForceOk = false;
    bool isDartRotating = false;
    bool isDartReadyToShoot = true;

    ARSessionOrigin aRSession;
    GameObject ARCam;

    public Collider dartFrontCollider;

    // Start is called before the first frame update
    void Start()
    {
        aRSession = GameObject.Find("AR Session Origin").GetComponent<ARSessionOrigin>();
        ARCam = aRSession.transform.Find("AR Camera").gameObject;

        rg = gameObject.GetComponent<Rigidbody>();
        dirObj = GameObject.Find("DartThrowingPoint");
    }

    private void FixedUpdate()
    {
        if (isForceOk)
        {
            dartFrontCollider.enabled = true;
            StartCoroutine(InitDartDestroyVFX());
            GetComponent<Rigidbody>().isKinematic = false;
            isForceOk = false;
            isDartRotating = true;
        }

        //Apply Force
        rg.AddForce(dirObj.transform.forward * (12f + 6f) * Time.deltaTime, ForceMode.VelocityChange);

        //Dart Ready to shoot
        if (isDartReadyToShoot)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 20f);
        }

        if (isDartRotating)
        {
            isDartReadyToShoot = false;
            transform.Rotate(Vector3.forward * Time.deltaTime * 400f);
        }
    }

    IEnumerator InitDartDestroyVFX()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
