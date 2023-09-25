using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera cameraFP;
    [SerializeField] private float range = 100f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private ParticleSystem weaponFlareVFX;
    [SerializeField] private Transform magicCollisionVFX;
    [SerializeField] private Transform particleSystemParent;

    private Ammo ammoSlot;

    private void Start()
    {
        ammoSlot = GetComponent<Ammo>();

        if (ammoSlot.Count() > ammoSlot.Capacity())
        {
            ammoSlot.FullyRestoreAmmo();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammoSlot.Count() > 0)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        WeaponFlareVFX();
        if (Physics.Raycast(cameraFP.transform.position, cameraFP.transform.forward, out RaycastHit hit, range))
        {
            CollisionVFX(hit.point);
            if (hit.transform.TryGetComponent<EnemyHealth>(out var enemy))
            {
                enemy.DecreaseHealth(damage);
            }

        }
        ammoSlot.ReduceAmmo();
    }

    private void WeaponFlareVFX()
    {
        Instantiate(weaponFlareVFX, particleSystemParent.position, particleSystemParent.rotation, particleSystemParent).Play();
    }

    private void CollisionVFX(Vector3 collisionPoint)
    {
        Instantiate(magicCollisionVFX, collisionPoint, Quaternion.identity);
    }
}
