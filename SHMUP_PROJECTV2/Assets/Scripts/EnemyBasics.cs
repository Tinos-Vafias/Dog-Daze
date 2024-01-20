using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasics : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Weapon[] weapons;
    public Weapon weapon;
    public Transform player;
    //decide which type of shooting
    public int enemyNo;
    private int counter = 1;
    // variables for firirng
    public float fireRate = .7f;
    private float nextFireTime = 0f;
    //decides if a enemy should look at the player or not
    public bool shouldMove = true; 
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        weapons = transform.GetComponentsInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (shouldMove) {
            LookAtPlayer();
        }
        FireEnemyBullet();
    }


    private void FireEnemyBullet()
    {
        if (enemyNo == 1) { //squirrel
            if (Time.time >= nextFireTime) {
                nextFireTime = Time.time + 1f / fireRate;
                foreach (Weapon weap in weapons)
                {
                    weap.Fire();
                }
            }
        }
        else if (enemyNo == 2) { // Bee
            if (Time.time >= nextFireTime) {
                if (counter == 3)
                {
                    //tweak the three accordingly
                    nextFireTime = Time.time + 6f / fireRate;
                    // Debug.Log("Waiting");
                    counter = 0;
                } else {
                    nextFireTime = Time.time + 1f / fireRate;
                }
                counter++;
            foreach (Weapon weap in weapons)
            {
                weap.Fire();
            }
            } 
        }
        else { //set as 0, don't fire
            
        }
    }

    // Make a method that follows the ship
    private void LookAtPlayer()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90;
    }
}
