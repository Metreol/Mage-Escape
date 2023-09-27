using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float shotDelayInSecs = 0.5f;
    [SerializeField] private Ammo ammoStorage;
    [SerializeField] private ParticleSystem weaponFlareVFX;
    [SerializeField] private Transform magicCollisionVFX;
    [SerializeField] private Transform particleSystemParent;
    [SerializeField] private Camera firstPersonCam;

    private bool readyToShoot;
    private float lastShotTimestamp = 0;
    private float timeSinceLastShot = 0;

    private void Start()
    {
        readyToShoot = true;

        if (ammoStorage.Count(ammoType) > ammoStorage.Capacity(ammoType))
        {
            ammoStorage.FullyRestoreAmmo(ammoType);
        }
    }

    private void OnEnable()
    {
        // Weapon Cooldown must be restarted when weapon is re-enabled.
        StartCoroutine(WeaponCooldown());
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammoStorage.Count(ammoType) > 0 && readyToShoot)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        readyToShoot = false;
        timeSinceLastShot = 0;
        lastShotTimestamp = Time.time;

        WeaponFlareVFX();
        if (Physics.Raycast(firstPersonCam.transform.position, firstPersonCam.transform.forward, out RaycastHit hit, range))
        {
            CollisionVFX(hit.point);
            if (hit.transform.TryGetComponent<EnemyHealth>(out var enemy))
            {
                enemy.DecreaseHealth(damage);
            }

        }
        ammoStorage.ReduceAmmo(ammoType);

        StartCoroutine(WeaponCooldown());
    }

    /*
     * This allows for the cooldown to continue while switched to another weapon 
     * AND avoids reseting the cooldown to 0 when switching weapons.
     */
    private IEnumerator WeaponCooldown()
    {
        while (timeSinceLastShot < shotDelayInSecs)
        {
            yield return null;
            timeSinceLastShot = Time.time - lastShotTimestamp;
        }
        readyToShoot = true;
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
