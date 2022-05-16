using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComplete : MonoBehaviour
{
    //Set in this script and used in other scripts
    public bool gameIsComplete = false;

    //The menu which displays when the game is complete
    public GameObject completeUI;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShowFinalUI());
    }

    IEnumerator ShowFinalUI()
    {
        //If the tree shrine has been activate, wait for the tree scene to finish then load UI menu 
        if (gameIsComplete)
        {
            yield return new WaitForSeconds(7);
            completeUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
