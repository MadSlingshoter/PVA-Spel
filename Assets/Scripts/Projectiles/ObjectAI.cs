using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAI : MonoBehaviour, IGameObjectPooled
{

    private Transform player;
    private Rigidbody2D rb;
    //public GameObject explosion;
    [SerializeField] private float travelSpeed = 2f;
    [SerializeField] private float rotateSpeed = 100f;

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

    public void OnObjectSpawn()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        Vector2 direction = (Vector2)player.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * travelSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Instantiate(explosion, transform.position, transform.rotation);
            // Player object thing with damage
            pool.ReturnToPool(this.gameObject);
        }
    }

}