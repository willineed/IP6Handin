using UnityEngine;

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
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
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
        rb.velocity = shootingPoint.forward * bulletSpeed;
    }
}
