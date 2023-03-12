using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjectOnPlaneB : MonoBehaviour
{
    private Pose placementPose;
    private Transform placementTransform;
    private bool placementPoseIsValid=false;
    bool isObjectPlaced = false;
    private TrackableId placedPlaneId;

    ARRaycastManager m_RaycastManager;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    //Creating an Event
    public static event Action onPlacedObject;

    private void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Start()
    {
        PlaceObject();
    }

    private void PlaceObject()
    {
        isObjectPlaced = true;
        onPlacedObject?.Invoke();
    }

}
