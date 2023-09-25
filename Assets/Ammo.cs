using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int ammoCapacity = 5;
    [SerializeField] private int ammoCount = 5;

    public int Count()
    {
        return ammoCount;
    }

    public int Capacity()
    {
        return ammoCapacity;
    }

    public void ReduceAmmo()
    {
        ReduceAmmo(1);
    }

    public void ReduceAmmo(int ammoCost)
    {
        ammoCount = ammoCount - ammoCost < 0 ? 0 : ammoCount - ammoCost;
    }

    public void RestoreAmmo(int newAmmoCount)
    {
        ammoCount = ammoCount + newAmmoCount >= ammoCapacity 
            ? ammoCapacity 
            : ammoCount + newAmmoCount;
    }

    public void FullyRestoreAmmo()
    {
        ammoCount = ammoCapacity;
    }
}
