using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using System;

public class ToggleAR : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public ARPointCloudManager pointCloudManager;

    public bool canMove = true;

    public void OnValueChanged(bool isOn)
    {
        canMove = isOn;

        VisualizePlanes(isOn);
        VisualizePoints(isOn);
    }

    void VisualizePlanes(bool active)
    {
        planeManager.enabled = active;
        foreach (ARPlane plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(active);
        }
    }

    void VisualizePoints(bool active)
    {
        pointCloudManager.enabled = active;
        foreach (ARPointCloud pointCLoud in pointCloudManager.trackables)
        {
            pointCLoud.gameObject.SetActive(active);
        }
    }
   
}
