using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    public Transform t1, t2;

    public Vector3 offset;
    public float smoothTime = .5f;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    public float zoomFactor = 1.5f;
    public float followTimeDelta = 0.8f;

    public Vector3 minvalue,maxvalue;

    private Vector3  velocity;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographic = false;
    }

    private void LateUpdate()
    {
        Move();
        Zoom();
    }
        void Move() { 
        Vector3 midpoint = (t1.position + t2.position) / 2f;
        Vector3 newPosition = midpoint + offset;

        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(newPosition.x, minvalue.x, maxvalue.x),
            Mathf.Clamp(newPosition.y, minvalue.y, maxvalue.y),
            Mathf.Clamp(newPosition.z, minvalue.z, maxvalue.z));

        cam.transform.position = Vector3.Slerp(cam.transform.position, newPosition, followTimeDelta);
    }

    void Zoom()
    {

        float distance = (t1.position - t2.position).magnitude;

        float newZoom = Mathf.Lerp(maxZoom, minZoom, distance / zoomLimiter);
        cam.fieldOfView = newZoom;
       
     
    }
}
