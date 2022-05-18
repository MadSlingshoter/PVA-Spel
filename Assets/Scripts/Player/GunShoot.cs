using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    [SerializeField] private float gunFireRate;
    private float gunCooldownTimer = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && gunCooldownTimer > gunFireRate)
        {
            FireGun();
        }

        gunCooldownTimer += Time.deltaTime;
    }

    private void FireGun()
    {
        gunCooldownTimer = 0;
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
