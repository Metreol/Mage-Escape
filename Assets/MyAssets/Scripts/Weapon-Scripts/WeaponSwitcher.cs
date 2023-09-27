using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    [SerializeField] private int currentWeapon = 0;
    
    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        int nextWeapon = currentWeapon;

        int weaponCount = transform.childCount;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            nextWeapon = 0;
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            nextWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            nextWeapon = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            nextWeapon = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            nextWeapon = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            nextWeapon = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            nextWeapon = 6;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            nextWeapon = 7;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            nextWeapon = 8;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            nextWeapon = 9;
        }

        float scrollWheelAxis = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelAxis < 0)
        {
            nextWeapon++;
            nextWeapon = nextWeapon >= weaponCount ? 0 : nextWeapon; 
        } 
        else if (scrollWheelAxis > 0)
        {
            nextWeapon--;
            nextWeapon = nextWeapon < 0 ? weaponCount - 1 : nextWeapon;
        }

        if (nextWeapon != currentWeapon && nextWeapon < weaponCount)
        {
            currentWeapon = nextWeapon;
            SetWeaponActive();
        }
    }

    private void SetWeaponActive()
    {

        int weaponIndex = 0;
        foreach (Transform weapon in transform) // This looks for given object type in children of this object.
        {
            Debug.Log(weapon.name);
            if (currentWeapon == weaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

}
