using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     
    // }

    // On contact with a bullet, kill the ship
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Die();
        }
    }

    private void Die()
    {
        // set the body to static and reset the scene
        LevelManager.instance.GameOver();
        Debug.Log("PLAYER IS DEAD");
        gameObject.SetActive(false);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
