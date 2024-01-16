using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Adjust the speed as per your requirement
    public float moveDistance = 5.0f; // Adjust the distance the spider should move back and forth

    private Vector3 initialPosition;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            if (transform.position.x >= initialPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            if (transform.position.x <= initialPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }
    }
}
