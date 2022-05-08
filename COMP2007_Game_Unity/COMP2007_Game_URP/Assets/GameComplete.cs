using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComplete : MonoBehaviour
{
    public bool gameIsComplete = false;

    public GameObject completeUI;

    // Update is called once per frame
    void Update()
    {
        CompleteMenu();
    }

    void CompleteMenu()
    {
        if (gameIsComplete)
        {
            completeUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
