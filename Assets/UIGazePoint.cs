using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;
public class UIGazePoint : MonoBehaviour
{
    private Image image;
    void Awake()
    {
        image = this.GetComponent<Image>();
    }
    void Update()
    {
         GazePoint gazePoint=TobiiAPI.GetGazePoint();
        image.transform.position = gazePoint.Screen;
        GameObject go = TobiiAPI.GetFocusedObject();
        if(go != null)
        {
            Debug.Log(go);
        }
            
        
    }
}
