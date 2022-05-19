using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour, IGameObjectPooled
{

    private Transform player;
    private Rigidbody2D rb;
    [SerializeField] private float travelSpeed = 2f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private float untrackTime = 2f;
    private float lifetime = 0;
    [SerializeField] private int damage = 30;

    private ObjectPool pool;
    public ObjectPool Pool
    {
        get
        {
            return pool;
        }
        set
        {
            if (pool == null)
            {
                pool = value;
            }
        }
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        lifetime = 0;
    }

    void FixedUpdate()
    {
        if (lifetime < untrackTime)
        {
            lifetime += Time.deltaTime;
            float movementSpeed = travelSpeed * Time.deltaTime;
            transform.Translate(movementSpeed, 0, 0);
        } 
        else
        {
            player = FindClosest().transform;
            Vector2 direction = (Vector2)player.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.right * travelSpeed;
        }
        
    }

    GameObject FindClosest()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        pool.ReturnToPool(this.gameObject);
    }

}