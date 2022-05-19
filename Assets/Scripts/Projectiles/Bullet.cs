using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IGameObjectPooled
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private int damage = 20;
    private bool hit;
    private Rigidbody2D rb;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);
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
