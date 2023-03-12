using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    public float Amplitude = 0.1f;
    public float frequency = 1.0f;
    Vector3 initPos;
    private void Start()
    {
       initPos = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * frequency) * Amplitude + initPos.y, transform.position.z);
    }
}
