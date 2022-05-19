using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime = .5f;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

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

        if (targets.Count == 0)
        {
            return;
        }

        Move();
        Zoom();
    }
        void Move() { 
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;

        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(newPosition.x, minvalue.x, maxvalue.x),
            Mathf.Clamp(newPosition.y, minvalue.y, maxvalue.y),
            Mathf.Clamp(newPosition.z, minvalue.z, maxvalue.z));

        transform.position = Vector3.SmoothDamp(transform.position, boundPosition, ref velocity, smoothTime);
    }

    void Zoom()
    {
        
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = newZoom;
       
     
    }
    
    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }







}
