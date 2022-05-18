using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    [SerializeField] private float gunFireRate;
    private float gunCooldownTimer = 0;
    [SerializeField] private ObjectPool gameObjectPool;

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
        var bullet = gameObjectPool.Get();
        bullet.transform.position = firepoint.position;
        bullet.transform.rotation = firepoint.rotation;
        bullet.gameObject.SetActive(true);
    }
}
