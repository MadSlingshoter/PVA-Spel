using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private float gunFireRate;
    private GunAim gunAim;
    private float gunCooldownTimer = Mathf.Infinity;

    // 
    void Awake()
    {
        gunAim = GetComponent<GunAim>();
    }

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
    }
}
