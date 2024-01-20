using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Bullet : MonoBehaviour
{
    // Initializing the camera to use its features in this script
    private Camera camera;
    private PointManager _pointManager;
    private void Awake()
    {
        camera = Camera.main;
        _pointManager = GameObject.Find("pointManager").GetComponent<PointManager>();
    }

    private void Update()
    {
        DestroyOffScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyBasics>())
        {
            Destroy(collision.gameObject);
            _pointManager.UpdateScore(50);
            Destroy(gameObject);
            Debug.Log(collision.gameObject.name + " destroyed!");
            
        }
    }

    // Code to remove object after it leaves the screen
    private void DestroyOffScreen()
    {
        // checks if the bullets is out of the bounds of the camera's position,
        // and then deletes them is they are 
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > camera.pixelWidth ||
            screenPosition.y < 0 || screenPosition.y > camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
    
    
}

