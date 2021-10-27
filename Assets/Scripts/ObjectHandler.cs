using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    public GameObject[] models;
    
    public void OnButtonClick(int modelno)
    {
        for(int i=0;i<models.Length;i++)
        {
            if(i==modelno)
            {
                models[i].SetActive(true);
            }
            else
            {
                models[i].SetActive(false);
            }
        }

    }
}
