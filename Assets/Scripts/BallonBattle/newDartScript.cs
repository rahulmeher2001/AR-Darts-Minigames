using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newDartScript : MonoBehaviour
{
    private Rigidbody rg;
    private GameObject dirObj;
    public Collider dartFrontCollider;


    // Start is called before the first frame update
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody>();
        dirObj = GameObject.Find("DartThrowingPoint");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dartFrontCollider.enabled = true;
        StartCoroutine(InitDartDestroyVFX());
        GetComponent<Rigidbody>().isKinematic = false;
        rg.AddForce(dirObj.transform.forward * (12f + 6f) * Time.deltaTime, ForceMode.VelocityChange);
    }
    IEnumerator InitDartDestroyVFX()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
