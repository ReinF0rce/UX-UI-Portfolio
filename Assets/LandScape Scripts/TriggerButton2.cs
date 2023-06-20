using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TriggerButton2 : MonoBehaviour
{
    public float pressScale = 0.8f; 
    public float releaseTime = 10f; 
    private Vector3 originalScale; 
    private bool isPressed = false; 

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (isPressed)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * pressScale, Time.deltaTime * 10f);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * releaseTime); 
        }
    }
    
   
    public void MouseDown()
    {
        isPressed = true;
    }

   
    public void MouseUp()
    {
        isPressed = false;
    }
}
