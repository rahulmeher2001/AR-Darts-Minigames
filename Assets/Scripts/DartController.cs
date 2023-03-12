using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DartController : MonoBehaviour
{
    public GameObject DartPrefab;
    public Transform DartThrowPoint;
    ARSessionOrigin aRSession;
    GameObject ARCam;
    private GameObject DartTemp;
    private Rigidbody rb;
    private int flagCS = 0;

    public GameObject resultButton;
    public int noDarts = 3;
    int dartsLeft = 2;
    bool roundPlay2 = false;
    bool roundPlay3 = false;
    public GameObject redDart;
    public GameObject blueDart;
    public GameObject greenDart;

    // Start is called before the first frame update
    void Start()
    {
        aRSession = GameObject.Find("AR Session Origin").GetComponent<ARSessionOrigin>();
        ARCam = aRSession.transform.Find("AR Camera").gameObject;
        dartsLeft = noDarts;
        int playCount = GameStateManager.playerCount;
        if (playCount == 3)
        {
            roundPlay2 = true;
            roundPlay3 = true;
        }
        if (playCount == 2)
        {
            roundPlay2 |= true;
        }
    }

    // Update is called once per frame
    void OnEnable()
    {
        PlaceObjectOnPlane.onPlacedObject += DartInit;
    }
    void OnDisable()
    {
        PlaceObjectOnPlane.onPlacedObject -= DartInit;
    }

    void Update()
    {
        if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Began)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if(Physics.Raycast(raycast,out raycastHit))
            {
                if(raycastHit.collider.CompareTag("dart"))
                {
                    //Disabling back touch collider from the dart
                    raycastHit.collider.enabled = false;
                    DartTemp.transform.parent = aRSession.transform;

                    Dart currentDartScript = DartTemp.GetComponent<Dart>();
                    currentDartScript.isForceOk = true;

                    DartScoreManager DSM = GameObject.Find("DartScoreManager").GetComponent<DartScoreManager>();

                    //Load Next Dart;
                    if (dartsLeft > 1)
                    {
                        dartsLeft--;
                        DartInit();
                    }
                    else if(roundPlay2)
                    {
                        roundPlay2 = false;
                        dartsLeft = noDarts;
                        DartPrefab = blueDart;
                        DartInit();
                        //GameStateManager.playerTurn = 1;
                        flagCS = 1;
                    }
                    else if (roundPlay3)
                    {
                        roundPlay3 = false;
                        dartsLeft = noDarts;
                        DartPrefab = greenDart;
                        DartInit();
                        //GameStateManager.playerTurn = 2;
                        flagCS = 2;
                    }
                    else
                    {
                        resultButton.SetActive(true);
                    }
                }
            }
        }
    }

    void DartInit()
    {
        StartCoroutine(WaitAndSpawnDart());
        if(flagCS==1)
        {
            GameStateManager.playerTurn = 1;
        }
        if (flagCS == 2)
        {
            GameStateManager.playerTurn = 2;
        }
    }

    public IEnumerator WaitAndSpawnDart()
    {
        yield return new WaitForSeconds(0.75f);
        DartTemp = Instantiate(DartPrefab, DartThrowPoint.position, ARCam.transform.rotation);
        DartTemp.transform.parent = ARCam.transform;
        rb = DartTemp.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

}
