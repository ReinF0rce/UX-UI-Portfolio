using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerButton : MonoBehaviour
{

    public Image button;
    private float opacity = 1.0f, currentOpacity, duration;
   
    public void OnMouseDown()
    {
        // img.color = new Color(img.color.r, img.color.g, img.color.b, Mathf.Lerp(opacity, 0.5f, 1));
        // img.color = new Color(img.color.r, img.color.g, img.color.b, Mathf.SmoothStep(opacity, 0.5f, 1));
        opacity = 0.5f;
        StartCoroutine(DownAnim());
         
    }

    public void OnMouseUp() 
    {
        opacity = 1.0f;
        StartCoroutine(UpAnim());
    }

    

   /* private void Update()
    {
        img.color.a = Mathf.SmoothDamp(currentOpacity, opacity, ref velocity, duration);

        GetComponent<Image>().color = new Color(79 / 255.0f, 165 / 255.0f, 63 / 255.0f, 1);
    }*/

    IEnumerator DownAnim()
    {
        button.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);

        yield return null;
    }
    IEnumerator UpAnim()
    {
        button.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        yield return null;
    }

}
