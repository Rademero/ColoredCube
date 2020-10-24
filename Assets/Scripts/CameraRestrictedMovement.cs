using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRestrictedMovement : MonoBehaviour
{
    // Set outside of the script by the user.
    public Transform lookAt;

    private Transform camTransform;

    private float distance = 10.0f;
    private float cameraSpeed = 100.0f;

    private float cameraX;
    private float cameraY;

    // Variables used for zoomin
    private float zoomSpeed = 0.15f;
    private float minDistance = 5.0f;
    private float maxDinstance = 20.0f;

    private void Start()
    {
        // Since the script is attached to the camera transform is actually the camera's transform.
        camTransform = transform;
    }

    private void Update()
    {
        float angleDelta = cameraSpeed * Time.deltaTime;

        // Rotate up
        if (Input.GetKey("w"))
        {
            cameraX = cameraX + angleDelta;
        }
        // Rotate down
        if (Input.GetKey("s"))
        {
            cameraX = cameraX - angleDelta;
        }
        // Rotate Left
        if (Input.GetKey("a"))
        {
            cameraY = cameraY + angleDelta;
        }
        // Rotate right
        if (Input.GetKey("d"))
        {
            cameraY = cameraY - angleDelta;
        }

        // Zoom in
        if (Input.GetKey("q"))
        {
            zoom(true);
        }
        // Zoom out
        if (Input.GetKey("e"))
        {
            zoom(false);
        }

        // Stops the camera from rotating over the top or bottom of the object.
        cameraX = Mathf.Clamp(cameraX, -90f, 90f);

        // Allows the camera to fully rotate left and right around the object without any breaks
        cameraY = Mathf.Repeat(cameraY, 360f);

        Quaternion cameraRotation = Quaternion.AngleAxis(cameraY, Vector3.up) * Quaternion.AngleAxis(cameraX, Vector3.right);

        Vector3 cameraPosition = lookAt.position + cameraRotation * Vector3.back * distance;

        camTransform.position = cameraPosition;
        camTransform.rotation = cameraRotation;

    }

    // USed to zoom in and out from the lookAt object.
    private void zoom(bool forward)
    {
        if (forward && distance > minDistance)
        {
            distance = distance - zoomSpeed;
        }
        else if (!forward && distance < maxDinstance)
        {
            distance = distance + zoomSpeed;
        }
    }
}
