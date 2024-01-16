using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float moveSpeed = 0.01f; // Adjust the speed as per your requirement
    public float directionChangeInterval = 10.0f; // Time in seconds after which the spider changes direction

    private Vector3 randomDirection;
    private float directionChangeTimer;

    // Start is called before the first frame update
    void Start()
    {
        ChooseNewDirection();
        directionChangeTimer = directionChangeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the spider to its right
        transform.Translate(transform.right * moveSpeed * Time.deltaTime/10, Space.World);

        // Rotate the spider to face the random direction
        if (randomDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(randomDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, moveSpeed * 100 * Time.deltaTime);
        }

        // Update the timer
        directionChangeTimer -= Time.deltaTime;

        // Check if it's time to change direction
        if (directionChangeTimer <= -1)
        {
            ChooseNewDirection();
            directionChangeTimer = directionChangeInterval;
        }
    }

    // Function to choose a new random direction
    private void ChooseNewDirection()
    {
        // Choose a random direction for rotation
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        randomDirection = new Vector3(randomX, 0, randomZ).normalized;
    }
}
