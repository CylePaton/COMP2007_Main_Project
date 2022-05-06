using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneNumber;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void sceneChanger()
    {
        SceneManager.LoadScene(sceneNumber);

        if(sceneNumber == 111)
        {
            Application.Quit();
            Debug.Log("Quitting...");
        }
    }
}
