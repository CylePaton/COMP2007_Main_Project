using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    [Header("Variables")]
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [Header("GameObjects")]
    [SerializeField] Transform cam;
    [SerializeField] Transform orientation;

    [Header("References")]
    public GameComplete gameComplete;

    float mouseX;
    float mouseY;

    float multiplier = 0.05f;

    float xRotation;
    float yRotation;

    private void Start()
    {
        
    }

    private void Update()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
        
        
        
        if(PauseMenu.gameIsPaused == false && gameComplete.gameIsComplete == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            yRotation += mouseX * sensX * multiplier;
            xRotation -= mouseY * sensY * multiplier;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        if(PauseMenu.gameIsPaused == true || gameComplete.gameIsComplete == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }
}
