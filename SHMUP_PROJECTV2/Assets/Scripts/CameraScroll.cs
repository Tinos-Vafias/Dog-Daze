using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    // Variables initialized for camera scrolling
    public float scrollSpeed = .4f; 
    public float scrollDistance = 50.0f;
    private float totalMoved = 0.0f; 
   
    // Update is called once per frame
    void Update()
    {
        if (totalMoved < scrollDistance)
        {
            // calculate the distance to move
            float moveThisFrame = scrollSpeed * Time.deltaTime;
            
            transform.Translate(0, moveThisFrame, 0);

            totalMoved += moveThisFrame;
        }
       
    }
}
