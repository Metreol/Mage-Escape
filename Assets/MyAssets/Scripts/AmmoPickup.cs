using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private AmmoType pickupAmmoType;
    [SerializeField] private int pickupSize = 5;

    private void OnTriggerEnter(Collider triggerObject)
    {
        if (triggerObject.gameObject.TryGetComponent(out Ammo ammoCarrier))
        {
            ammoCarrier.RestoreAmmo(pickupSize, pickupAmmoType);
            Destroy(gameObject);
        }
    }
}
