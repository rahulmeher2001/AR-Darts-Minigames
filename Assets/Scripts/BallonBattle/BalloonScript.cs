using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    public int pointVal;
    public AudioSource pop;
    public GameObject ballon;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="dart")
        {
            BScoreManager.score += pointVal;
            pop.Play();
            Destroy(ballon);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //pop = GameObject.Find("AR Camera").GetComponent<AudioSource>();
        if (collision.gameObject.tag == "dart")
        {
            BScoreManager.score += pointVal;
            pop.Play(0);
            Destroy(ballon,0.5f);
        }
    }
}
