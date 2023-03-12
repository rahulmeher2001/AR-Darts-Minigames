using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Dart : MonoBehaviour
{
    private Rigidbody rg;
    private GameObject dirObj;
    public bool isForceOk = false;
    bool isDartRotating = false;
    bool isDartReadyToShoot = true;
    bool isDartHitOnBoard = false;
    bool updateOpportunity = true;

    ARSessionOrigin aRSession;
    GameObject ARCam;

    public Collider dartFrontCollider;
    public AudioSource dartHitSfx;

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
        if(isForceOk)
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
        if(isDartReadyToShoot)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 20f);
        }

        if(isDartRotating)
        {
            isDartReadyToShoot = false;
            transform.Rotate(Vector3.forward * Time.deltaTime * 400f);
        }
    }

    IEnumerator InitDartDestroyVFX()
    {
        yield return new WaitForSeconds(5f);
        if(!isDartHitOnBoard)
        {
            Destroy(gameObject);
        }
    }

    private void updateScore(int n)
    {

        DartScoreManager DSM = GameObject.Find("DartScoreManager").GetComponent<DartScoreManager>();

        if (GameStateManager.playerTurn == 0)
        {
            GameStateManager.p1Score += n;
            DSM.displayMsg(GameStateManager.p1Score.ToString());
        }
        if (GameStateManager.playerTurn == 1)
        {
            GameStateManager.p2Score += n;
            DSM.displayMsg(GameStateManager.p2Score.ToString());
        }
        if (GameStateManager.playerTurn == 2)
        {
            GameStateManager.p3Score += n;
            DSM.displayMsg(GameStateManager.p3Score.ToString());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dart_board"))
        {
            Handheld.Vibrate();

            GetComponent<Rigidbody>().isKinematic = true;
            isDartRotating = false;
            isDartHitOnBoard = true;
            dartHitSfx.Play();
        }
        string sectionName = other.name;
        checkForScore(sectionName);
    }

    private void checkForScore(string sectionName)
    {

        switch (sectionName)
        {
            case "HitArea.000":
                updateScore(20);
                break;
            case "HitArea.001":
                updateScore(1);
                break;
            case "HitArea.002":
                updateScore(18);
                break;
            case "HitArea.003":
                updateScore(4);
                break;
            case "HitArea.004":
                updateScore(13);
                break;
            case "HitArea.005":
                updateScore(6);
                break;
            case "HitArea.006":
                updateScore(10);
                break;
            case "HitArea.007":
                updateScore(15);
                break;
            case "HitArea.008":
                updateScore(2);
                break;
            case "HitArea.009":
                updateScore(3);
                break;
            case "HitArea.010":
                updateScore(19);
                break;
            case "HitArea.011":
                updateScore(7);
                break;
            case "HitArea.012":
                updateScore(16);
                break;
            case "HitArea.013":
                updateScore(8);
                break;
            case "HitArea.014":
                updateScore(11);
                break;
            case "HitArea.015":
                updateScore(14);
                break;
            case "HitArea.016":
                updateScore(9);
                break;
            case "HitArea.017":
                updateScore(12);
                break;
            case "HitArea.018":
                updateScore(5);
                break;
            case "HitArea.019":
                updateScore(20);
                break;
            case "HitArea.020":
                updateScore(1);
                break;
            case "HitArea.021":
                updateScore(18);
                break;
            case "HitArea.022":
                updateScore(4);
                break;
            case "HitArea.023":
                updateScore(13);
                break;
            case "HitArea.024":
                updateScore(6);
                break;
            case "HitArea.025":
                updateScore(10);
                break;
            case "HitArea.026":
                updateScore(15);
                break;
            case "HitArea.027":
                updateScore(2);
                break;
            case "HitArea.028":
                updateScore(17);
                break;
            case "HitArea.029":
                updateScore(3);
                break;
            case "HitArea.030":
                updateScore(19);
                break;
            case "HitArea.031":
                updateScore(7);
                break;
            case "HitArea.032":
                updateScore(16);
                break;
            case "HitArea.033":
                updateScore(8);
                break;
            case "HitArea.034":
                updateScore(11);
                break;
            case "HitArea.035":
                updateScore(14);
                break;
            case "HitArea.036":
                updateScore(9);
                break;
            case "HitArea.037":
                updateScore(12);
                break;
            case "HitArea.038":
                updateScore(5);
                break;
            case "HitArea.039":
                updateScore(60);
                break;
            case "HitArea.040":
                updateScore(3);
                break;
            case "HitArea.041":
                updateScore(54);
                break;
            case "HitArea.042":
                updateScore(12);
                break;
            case "HitArea.043":
                updateScore(39);
                break;
            case "HitArea.044":
                updateScore(18);
                break;
            case "HitArea.045":
                updateScore(30);
                break;
            case "HitArea.046":
                updateScore(45);
                break;
            case "HitArea.047":
                updateScore(6);
                break;
            case "HitArea.048":
                updateScore(51);
                break;
            case "HitArea.049":
                updateScore(9);
                break;
            case "HitArea.050":
                updateScore(57);
                break;
            case "HitArea.051":
                updateScore(21);
                break;
            case "HitArea.052":
                updateScore(48);
                break;
            case "HitArea.053":
                updateScore(24);
                break;
            case "HitArea.054":
                updateScore(33);
                break;
            case "HitArea.055":
                updateScore(42);
                break;
            case "HitArea.056":
                updateScore(27);
                break;
            case "HitArea.057":
                updateScore(36);
                break;
            case "HitArea.058":
                updateScore(15);
                break;
            case "HitArea.059":
                updateScore(40);
                break;
            case "HitArea.060":
                updateScore(2);
                break;
            case "HitArea.061":
                updateScore(36);
                break;
            case "HitArea.062":
                updateScore(8);
                break;
            case "HitArea.063":
                updateScore(26);
                break;
            case "HitArea.064":
                updateScore(12);
                break;
            case "HitArea.065":
                updateScore(20);
                break;
            case "HitArea.066":
                updateScore(30);
                break;
            case "HitArea.067":
                updateScore(4);
                break;
            case "HitArea.068":
                updateScore(34);
                break;
            case "HitArea.069":
                updateScore(6);
                break;
            case "HitArea.070":
                updateScore(38);
                break;
            case "HitArea.071":
                updateScore(14);
                break;
            case "HitArea.072":
                updateScore(32);
                break;
            case "HitArea.073":
                updateScore(16);
                break;
            case "HitArea.074":
                updateScore(22);
                break;
            case "HitArea.075":
                updateScore(28);
                break;
            case "HitArea.076":
                updateScore(18);
                break;
            case "HitArea.077":
                updateScore(24);
                break;
            case "HitArea.078":
                updateScore(10);
                break;
            case "HitArea.079":
                updateScore(17);
                break;
            case "Ring.008":
                updateScore(50);
                break;
            case "Ring.007":
                updateScore(25);
                break;
            default:
                updateScore(0);
                break;
        }
    }

}
