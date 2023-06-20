using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowerPanelController : MonoBehaviour
{
    public SwipeController controller;
    public RectTransform[] Cells;
    public LayoutElement[] elements;
    public RectTransform lowerBar, centerBar;
    public float speed;
    public int index;
    private float width;
    void Start()
    {
        width = GetComponent<RectTransform>().rect.width;
    }

    void Update()
    {
        centerBar.anchoredPosition = Vector3.Lerp(centerBar.anchoredPosition, new Vector3(-controller.currentPage * width, 0, 0), Time.deltaTime * speed);
        lowerBar.anchoredPosition = Vector3.Lerp(lowerBar.anchoredPosition, new Vector3(Cells[controller.currentPage].anchoredPosition.x, 0, 0), Time.deltaTime * speed);
        lowerBar.sizeDelta = Vector3.Lerp(lowerBar.sizeDelta, new Vector3(Cells[controller.currentPage].sizeDelta.x, lowerBar.sizeDelta.y, 0), Time.deltaTime * speed);
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].flexibleWidth = Mathf.Lerp(elements[i].flexibleWidth, i == controller.currentPage ? 2 : 1, Time.deltaTime * speed);
        }
    }

    public void OnButtonClick(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < Cells.Length)
        {
            //int left =buttonIndex > controller.currentPage? buttonIndex - controller.currentPage : ;
            int left = buttonIndex - controller.currentPage;
            controller.currentPage = buttonIndex;
           // if (left!=0) controller.UpdateSwipeController(left);
        }
    }
}
