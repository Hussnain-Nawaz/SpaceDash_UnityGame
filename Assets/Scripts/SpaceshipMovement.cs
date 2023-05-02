using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float speed = 10f; // the movement speed of the object
    public float tiltAngle = 20f; // the maximum tilt angle of the object when turning
    public float maxUpDownAngle = 20f; // the maximum angle the object can tilt up or down

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // get the horizontal and vertical input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // calculate the movement direction based on the horizontal and vertical input
        Vector3 movementDirection = new Vector3(horizontalInput, verticalInput, 1f).normalized;

        // apply the movement direction and speed to the object's rigidbody
        rb.velocity = movementDirection * speed;

        // calculate the tilt angle based on the vertical input
        float upDownTiltAngle = -verticalInput * maxUpDownAngle;

        // create a quaternion for the tilt angle
        Quaternion tiltQuaternion = Quaternion.Euler(upDownTiltAngle, 0f, 0f);

        // apply the tilt quaternion to the object's rotation
        rb.MoveRotation(tiltQuaternion);

        // calculate the tilt angle based on the horizontal input
        float tiltAngleToApply = -horizontalInput * tiltAngle;

        // create a quaternion for the tilt angle
        Quaternion tiltQuaternion2 = Quaternion.Euler(0f, 0f, tiltAngleToApply);

        // apply the tilt quaternion to the object's rotation
        rb.MoveRotation(rb.rotation * tiltQuaternion2);
    }
}
