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

    //Store mouse position
    float mouseX;
    float mouseY;

    float multiplier = 0.05f;

    float xRotation;
    float yRotation;

    private void Update()
    {
        //Getting mouse position
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
        
        //If the game is paused the player shouldnt be able to look around
        if(PauseMenu.gameIsPaused == false && gameComplete.gameIsComplete == false)
        {
            //Hides the curser
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            //Add rotation based off mouse input times custom variables
            yRotation += mouseX * sensX * multiplier;
            xRotation -= mouseY * sensY * multiplier;

            //Stop the player from looking around 360 degrees
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            //Setting the cameras rotation
            cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        //If the game is paused or complete allow the user to see the mouse
        if(PauseMenu.gameIsPaused == true || gameComplete.gameIsComplete == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }
}
