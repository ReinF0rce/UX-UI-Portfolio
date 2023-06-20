using UnityEngine;

public class MiniMapDemo : MonoBehaviour
{
    public RectTransform miniMap;
    public RectTransform markerPivot;
    public float speed = 100f;
    public float rotationSpeed = 50f;

    private Vector2 startPosition, startRotation;
    public Vector2 destination;
    

    private bool isDemoRunning = false;

    private void Start()
    {

        startPosition = miniMap.position;
        startRotation = miniMap.eulerAngles;

    }

    private void Update()
    {
        if (isDemoRunning)
        {

            miniMap.transform.position = Vector2.Lerp(startPosition , destination, Time.deltaTime * speed);
            
            //miniMap.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            


        }
    }

    public void StartDemo()
    { 
        isDemoRunning = true;
    }

    public void StopDemo()
    {

        isDemoRunning = false;
        miniMap.position = startPosition;
        miniMap.eulerAngles = startRotation;
        
    }
}

