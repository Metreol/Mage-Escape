using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoCapacity;
        public int ammoCount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType type)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (type == slot.ammoType)
            {
                return slot;
            }
        }

        Debug.LogError($"ERROR: AmmoType {type} was not found in the AmmoSlots for the Player");
        return null;
    }

    public int Count(AmmoType type)
    {
        return GetAmmoSlot(type).ammoCount;
    }

    public int Capacity(AmmoType type)
    {
        return GetAmmoSlot(type).ammoCapacity;
    }

    public void ReduceAmmo(AmmoType type)
    {
        ReduceAmmo(1, type);
    }

    public void ReduceAmmo(int ammoCost, AmmoType type)
    {
        AmmoSlot slot = GetAmmoSlot(type);
        slot.ammoCount = slot.ammoCount - ammoCost < 0 ? 0 : slot.ammoCount - ammoCost;
    }

    public void RestoreAmmo(int newAmmoCount, AmmoType type)
    {
        AmmoSlot slot = GetAmmoSlot(type);
        slot.ammoCount = slot.ammoCount + newAmmoCount >= slot.ammoCapacity
            ? slot.ammoCapacity
            : slot.ammoCount + newAmmoCount;
    }

    public void FullyRestoreAmmo(AmmoType type)
    {
        AmmoSlot slot = GetAmmoSlot(type);
        slot.ammoCount = slot.ammoCapacity;
    }
}
