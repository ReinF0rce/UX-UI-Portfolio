using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton3 : MonoBehaviour
{

    private Vector3 initialPos;
    private bool isMovedLeft;
    public float position, speed = 0.4f, offset = 30;

    private void Start()
    {
        position = transform.position.x;
        initialPos = transform.position;
        isMovedLeft = false;
    }

    private void Update()
    {
      
       transform.position = new Vector3(Mathf.SmoothStep(transform.position.x, isMovedLeft?  position : position + offset, Time.deltaTime * speed), transform.position.y, transform.position.z);
                       
    }


    public void OnMouseDown()
    {
        isMovedLeft = !isMovedLeft;
    }
}



