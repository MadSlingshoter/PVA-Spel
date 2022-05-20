using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePack : MonoBehaviour
{
    private float respawn;
    private bool active;
    [SerializeField] private float respawnTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            respawn += Time.deltaTime;
            if (respawn >= respawnTime)
            {
                activatePickup();
            }
        }
    }

    private void activatePickup()
    {
        active = true;
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        GetComponent<Collider2D>().enabled = !GetComponent<Collider2D>().enabled;
    }

    private void deactivePickup()
    {
        respawn = 0;
        active = false;
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        GetComponent<Collider2D>().enabled = !GetComponent<Collider2D>().enabled;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (active)
        {
            PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.GainMissile();
                SoundManagerScript.PlaySound("health");
                deactivePickup();
            }
        }

    }
}
