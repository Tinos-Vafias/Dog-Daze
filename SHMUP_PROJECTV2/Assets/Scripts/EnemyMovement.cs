using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;
    private int waypointIndex = 0;
    private bool shouldMove = false;

    void Update()
    {
        if (shouldMove)
        {
            MoveToWaypoints();
        }
    }

    void MoveToWaypoints()
    {
        // Stop if no more waypoints
        if (waypointIndex >= waypoints.Length) return; 

        Transform targetWaypoint = waypoints[waypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                // Stop moving when all waypoints are reached
                shouldMove = false; 
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rectangle")) 
        {
            Debug.Log("start moving");
            shouldMove = true;
        }
    }
}
