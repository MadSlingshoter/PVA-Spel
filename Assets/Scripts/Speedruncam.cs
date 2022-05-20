using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class Speedruncam : MonoBehaviour
    
{

    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime = .5f;
    

    public Vector3 minvalue, maxvalue;

    private Vector3 velocity;

    private Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    Vector3 GetCenterPoint()
    {
  
            return targets[0].position;
        
        
    }
}
