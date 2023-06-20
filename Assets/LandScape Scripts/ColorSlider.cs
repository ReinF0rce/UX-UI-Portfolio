using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSlider : MonoBehaviour
{

    public Image[] images;
    public Color active, passive;

    public void Fill(int count)
    {
        for (int i=0; i < images.Length; i++)
        {           
            images[i].color = i < count ? active : passive;
        } 
    }

    void Start()
    {
        images = GetComponentsInChildren<Image>();

        Fill(2);
    }

   
}
