using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation, targetPosition;
    LowerPanelController lowerPanel;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public int totalPages = 4;
    public int currentPage = 2;
    public RectTransform cellSize;
    public GridLayoutGroup layout;
    public AnimationCurve curve;
    

    void Start()
    {
        targetPosition = transform.position;
        panelLocation = transform.position;
        SetScreen();
    }

    [ContextMenu("SetScreen")]
    void SetScreen()
    {
        var canvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        var width = canvas.sizeDelta.x; //Screen.width;
        layout.cellSize = new Vector3(width, canvas.sizeDelta.y, 0);
        cellSize.offsetMax = new Vector2(0, 0);
        cellSize.offsetMin = new Vector2(-width, 0);
    }

    public void OnDrag(PointerEventData data)
    {
        // Debug.Log(data.pressPosition - data.position);
        float difference = data.pressPosition.x - data.position.x;
        targetPosition = panelLocation - new Vector3(difference, 0, 0);
        //transform.position = panelLocation - new Vector3(difference, 0, 0);
    }

   /* public void OnEndDrag(PointerEventData data)
    {
        float dragDistance = data.pressPosition.x - data.position.x;
        float percentage = dragDistance / Screen.width;

        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            if (percentage > 0 && currentPage < totalPages - 1)
            {
                currentPage++;
                panelLocation -= new Vector3(Screen.width, 0, 0);
            }
            else if (percentage < 0 && currentPage > 0)
            {
                currentPage--;
                panelLocation += new Vector3(Screen.width, 0, 0);
            }
        }

        targetPosition = panelLocation;
    }*/


    public void OnEndDrag(PointerEventData data)
     {
         float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
         if (Mathf.Abs(percentage) >= percentThreshold)
         {
             Vector3 newLocation = panelLocation;
             if (percentage > 0 && currentPage < totalPages - 1)
             {
                 currentPage++;
                 newLocation += new Vector3(-Screen.width, 0, 0);
             }
             else if (percentage < 0 && currentPage > 0)
             {
                 currentPage--;
                 newLocation += new Vector3(Screen.width, 0, 0);
             }

             //StartCoroutine(SmoothMove(transform.position, newLocation, easing));
             panelLocation = newLocation;
             targetPosition = newLocation;
         }
         else
         {
             targetPosition = panelLocation;
             //StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
         }
     }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, t);
            yield return null;
        }
    }
  
    public void UpdateSwipeController(int left)
    {
        
        //float width = layout.cellSize.x;
        targetPosition = new Vector3(Screen.width * (currentPage + left), panelLocation.y, 0);
        //newLocation = new Vector3(currentPage * Screen.width * (left ? 1 : -1), panelLocation.y, 0);
        // StartCoroutine(SmoothMove(transform.position, newLocation, easing));
        panelLocation = targetPosition;
    }
   /* private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, easing * Time.deltaTime);
    }*/
}
