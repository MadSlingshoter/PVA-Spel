using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private Transform firepoint;

    [SerializeField] private float gunFireRate;
    private float gunCooldownTimer = Mathf.Infinity;
    [SerializeField] private ObjectPool bulletPool;

    [SerializeField] private float missileFireRate;
    private float missileCooldownTimer = Mathf.Infinity;
    [SerializeField] private ObjectPool missilePool;
    private bool hasMissile;

    //Controls
    [SerializeField] private KeyCode Fire1;
    [SerializeField] private KeyCode Fire2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Fire1) && gunCooldownTimer > gunFireRate)
        {
            FireGun();
        }

        gunCooldownTimer += Time.deltaTime;

        if (Input.GetKey(Fire2) && missileCooldownTimer > missileFireRate && hasMissile)
        {
            FireMissile();
        }

        missileCooldownTimer += Time.deltaTime;
    }

    private void FireGun()
    {
        gunCooldownTimer = 0;
        var bullet = bulletPool.Get();
        bullet.transform.SetPositionAndRotation(firepoint.position, firepoint.rotation);
        SoundManagerScript.PlaySound("pistol");
        bullet.SetActive(true);
    }

    private void FireMissile()
    {
        missileCooldownTimer = 0;
        var missile = missilePool.Get();
        missile.transform.SetPositionAndRotation(firepoint.position, firepoint.rotation);
        SoundManagerScript.PlaySound("rocket");
        missile.SetActive(true);
    }

    public void setHasMissile(bool value)
    {
        hasMissile = value;
    }
}
