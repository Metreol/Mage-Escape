using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{

    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private List<GameObject> disableOnDeath = new List<GameObject>();

    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;

        foreach (GameObject obj in disableOnDeath)
        {
            obj.SetActive(false);
        }

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
