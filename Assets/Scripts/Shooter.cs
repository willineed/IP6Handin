using UnityEngine;

// made with the help of github copilot

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform shootingPoint; // Reference to the shooting point
    public float bulletSpeed = 20f; // Speed of the bullet

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // check if space key is pressed or left mouse button is pressed
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        // Instantiate the bullet at the shooting point
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);

        // Get the Rigidbody component of the bullet and set its velocity
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = shootingPoint.forward * bulletSpeed;
    }

    // if gameobject with tag Ghost hits the collider of the player lose the game
  
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            Debug.Log("You lose");
        }
    }

   

}