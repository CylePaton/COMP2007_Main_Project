using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneNumber;

    public void sceneChanger()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}