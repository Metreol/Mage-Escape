using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private AmmoType pickupAmmoType;
    [SerializeField] private int pickupSize = 5;

    private void OnTriggerEnter(Collider triggerCollider)
    {
        if (triggerCollider.gameObject.TryGetComponent(out Ammo ammoCarrier))
        {
            ammoCarrier.IncreaseAmmo(pickupSize, pickupAmmoType);
            Destroy(gameObject);
        }
    }
}
