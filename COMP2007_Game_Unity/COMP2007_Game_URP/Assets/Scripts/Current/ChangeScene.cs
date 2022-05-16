using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //Scene to change to
    public int sceneNumber;

    private void Start()
    {
        //Ensures the player can use the mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void sceneChanger()
    {
        //Loads the chosen scene
        SceneManager.LoadScene(sceneNumber);

        //If chosen scene is set to 111 then quit then application (for quit button)
        if(sceneNumber == 111)
        {
            Application.Quit();
            Debug.Log("Quitting...");
        }
    }
}
