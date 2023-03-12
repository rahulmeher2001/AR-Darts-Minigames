using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomObj : MonoBehaviour
{
    public float distance = 3f;
    public float height = 2f;

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    public float genTime1 = 2.0f;
    public float genTime2 = 3.5f;
    public float genTime3 = 5.0f;

    public GameObject parentBalloon;

    void Update()
    {
        generateObjs();
    }

    Vector3 genPos()
    {
        float x, y, z;
        x = Random.Range(distance * -1, distance);
        y = Random.Range(0, height);
        z = Random.Range(distance * -1, distance);

        return new Vector3(x, y, z);
    }

    public void generateObjs()
    {
        genTime1-=Time.deltaTime;
        genTime2-=Time.deltaTime;
        genTime3-=Time.deltaTime;

        if(genTime1 < 0)
        {
            genTime1 = 2;
            var temp = Instantiate(obj1, genPos(), Quaternion.identity);
            temp.transform.parent = parentBalloon.transform;
        }
        if (genTime2 < 0)
        {
            genTime2 = 2;
            var temp = Instantiate(obj2, genPos(), Quaternion.identity);
            temp.transform.parent = parentBalloon.transform;
        }
        if (genTime3 < 0)
        {
            genTime3 = 2;
            var temp = Instantiate(obj3, genPos(), Quaternion.identity);
            temp.transform.parent = parentBalloon.transform;
        }
    }
}
