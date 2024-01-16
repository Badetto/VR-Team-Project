using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderLegMovement : MonoBehaviour
{
    public Transform[] contLegs; // Assign all the cont leg parts
    public float[] currentRotationZ;

    public float legMovementSpeed = 15f; // Speed at which legs move
    public float legRotationAngle = 1f; // Max angle legs can rotate

    private void Start()
    {
        currentRotationZ = new float[8];
        int i = 0;
        foreach (var leg in contLegs)
        {
            currentRotationZ[i] = leg.localRotation.eulerAngles.z;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnimateLegs();
    }

    private void AnimateLegs()
    {
        // Oscillate the 'cont' leg parts around the Z-axis
        int i = 0;
        foreach (var leg in contLegs)
        {
            // Calculate the rotation angle, oscillating between -legRotationAngle and legRotationAngle
            float rotationZ = Mathf.Sin(Time.time * legMovementSpeed) * legRotationAngle;
            Console.WriteLine(leg.localRotation.eulerAngles.z);
            Console.WriteLine(rotationZ);
            // Apply the rotation around the Z-axis in local space
            leg.localRotation = Quaternion.Euler(leg.localRotation.eulerAngles.x, leg.localRotation.eulerAngles.y, currentRotationZ[i] + rotationZ);
            i++;
        }
    }
}

