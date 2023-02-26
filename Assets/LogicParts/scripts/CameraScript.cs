using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public bool killed;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public GameObject settingsMenu;
    public GameObject foodBar;
    public GameObject pCounter;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -25f, 25f);

        if(!killed)
        {
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        if(killed)
        {

        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsMenu.active)
            {
                settingsMenu.SetActive(false);
                pCounter.SetActive(true);
                foodBar.SetActive(true);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (!settingsMenu.active)
            {
                settingsMenu.SetActive(true);
                pCounter.SetActive(false);
                foodBar.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
