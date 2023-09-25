using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnhancedVision : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCam;
    [SerializeField] private float zoomFOV = 20f;
    [SerializeField] private float defaultFOV = 40f;
    [SerializeField] private float zoomRate = 60f;
    [SerializeField] private float zoomRotationSpeed = 1f;
    [SerializeField] private float defaultRotationSpeed = 4f;

    private FirstPersonController fpController;


    // Start is called before the first frame update
    void Start()
    {
        if (virtualCam == null)
        {
            Debug.LogError($"No Camera assigned to {name}");
        }
        fpController = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        float zoomChange;
        if (Input.GetButton("Fire2"))
        {
            zoomChange = -zoomRate * Time.deltaTime;
            fpController.RotationSpeed = zoomRotationSpeed;
        }
        else
        {
            zoomChange = zoomRate * Time.deltaTime;
            fpController.RotationSpeed = defaultRotationSpeed;
        }
        virtualCam.m_Lens.FieldOfView = Mathf.Clamp(virtualCam.m_Lens.FieldOfView + zoomChange, zoomFOV, defaultFOV);
    }
}
