using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerMouse : MonoBehaviour
{
    public float durationUp, durationDown;
    float duration, a;
    public Image b;

    public void OnMouseDown()
    {
        a = 1;
        duration = durationDown;
    }
    public void OnMouseUp()
    {
        a = 0;
        duration = durationUp;
    }
    float temp;
    void Update()
    {
        b.fillAmount = Mathf.SmoothDamp(b.fillAmount, a, ref temp, duration);
    }
}
