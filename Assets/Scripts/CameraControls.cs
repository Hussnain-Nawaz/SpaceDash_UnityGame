using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform target; // the target object that the camera should follow
    public Vector3 offset; // the offset from the target object that the camera should maintain
    Vector3 currentVelocity = Vector3.zero;
    float smoothTime = 0.1f;
    private Vector3 initialPosition; // the initial position of the camera relative to the target object

    void Start()
    {
        // calculate the initial position of the camera relative to the target object
        initialPosition = transform.position - target.position;
    }

    void FixedUpdate()
    {
        
        // calculate the new position of the camera based on the target object's position and the offset
        Vector3 newPosition = target.position + initialPosition + offset;

        // smoothly move the camera to the new position
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currentVelocity, smoothTime);

        // make the camera look at the target object
        transform.LookAt(target);
    }
}
