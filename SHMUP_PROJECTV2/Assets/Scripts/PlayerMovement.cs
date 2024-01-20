using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public Weapon weapon;

    // Variables for movement
    private float moveSpeed = 7f; // always change later for testing
    private Vector2 moveInput;
    
    // Variables for shooting
    private float fireRate = 6.5f; // always change later for testing
    private float nextFireTime = 0f;
     
    // Variables for making camera bounds
    private Camera camera;
    [SerializeField] private float screenBorder; 
    //^^^This variable can change when the actual sprites are implemented^^^  
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //This handles player's movement (all 8 directions)
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        rb.velocity = moveInput * moveSpeed;
        
        KeepPlayerOnScreen();
        // calls the fireBullet function
        FireBullet();
    }

    // This section of code handles firing and places a cooldown
    // To how fast we can fire
    private void FireBullet()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            weapon.Fire();
        }
    }
    
    // this method will keep the player on screen, using the camera's
    // boundaries 
    private void KeepPlayerOnScreen()
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
        
        if ((screenPosition.x < screenBorder && rb.velocity.x < 0) ||
        (screenPosition.x > camera.pixelWidth - screenBorder && rb.velocity.x > 0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        // This doesn't keep the character in for when the camera moves
        if ((screenPosition.y < screenBorder && rb.velocity.y < 0) ||
            (screenPosition.y > camera.pixelHeight - screenBorder && rb.velocity.y > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        
        // This ensures that when the camera is scrolling that the player is pushed along
        // with the scrolling camera
        var viewportPosition = camera.WorldToViewportPoint(transform.position);
        viewportPosition.x = Mathf.Clamp(viewportPosition.x, 0.15f, 0.85f); // Keeping within horizontal bounds
        viewportPosition.y = Mathf.Clamp(viewportPosition.y, 0.05f, 0.95f); // Keeping within vertical bounds

        transform.position = camera.ViewportToWorldPoint(viewportPosition);
    }
}
