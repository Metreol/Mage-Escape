using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera cameraFP;
    [SerializeField] private float range = 100f;
    [SerializeField] private GameObject hitMarker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        Debug.Log("Attempted shot");
        if (Physics.Raycast(cameraFP.transform.position, cameraFP.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log($"Hit {hit.transform.name} at {hit.transform.position}.");
            Instantiate(hitMarker, hit.point, Quaternion.identity);
        }
    }
}
