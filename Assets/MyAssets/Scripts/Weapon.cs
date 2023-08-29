using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera cameraFP;
    [SerializeField] private float range = 100f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private ParticleSystem magicEffect;
    [SerializeField] private Transform particleSystemParent;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //Debug.Log("Attempted shot");
        MagicVFX();
        if (Physics.Raycast(cameraFP.transform.position, cameraFP.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log($"Hit {hit.transform.name} at {hit.transform.position}.");
            if (hit.transform.TryGetComponent<EnemyHealth>(out var enemy))
            {
                enemy.DecreaseHealth(damage);
            }

        }
    }

    private void MagicVFX()
    {
        Instantiate(magicEffect, particleSystemParent.position + particleSystemParent.forward, particleSystemParent.rotation, particleSystemParent).Play();
    }
}
