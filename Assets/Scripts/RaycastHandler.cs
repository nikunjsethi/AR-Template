﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] Camera raycastCamera;
    [SerializeField] GameObject model;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();


    void Update()
    {
        if(Input.GetMouseButton(0) && !IsClickOverUI())
        {
            Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
            if(raycastManager.Raycast(ray, hits, TrackableType.Planes))
            {
                Pose pose = hits[0].pose;

                if(GetComponent<ToggleAR>().canMove)
                {
                    ProcessMovement(pose);
                }
            }
        }
    }

    private void ProcessMovement(Pose pose)
    {
        model.transform.SetPositionAndRotation(pose.position, pose.rotation);
        var finalRation = model.transform.localEulerAngles;
        finalRation.x = 90;
        model.transform.localEulerAngles = finalRation;
    }

    bool IsClickOverUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);
        for (int i = 0; i < raycastResults.Count; i++)
        {
            if (raycastResults[i].gameObject.GetComponent<MouseOverClickThrough>() != null)
            {
                raycastResults.RemoveAt(i);
                i--;
            }
        }

        return raycastResults.Count > 0;
    }
}
