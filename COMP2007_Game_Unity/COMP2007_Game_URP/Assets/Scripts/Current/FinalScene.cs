using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    //The player pov cam and the cam used for the cutscene
    [Header("Cameras")]
    public Camera mainCam;
    public Camera sceneCam;

    //Referencing the tree shrine and game complete script, both play are part in completing the game
    [Header("References")]
    public TreeShrine treeShrine;
    public GameComplete game;

    //So the in game UI can diabled in the cutscene
    [Header("UI")]
    public GameObject gameUI;

    // Update is called once per frame
    void Update()
    {
        //If the game is complete aka the treeshrine has been activated, then swicth the cam and disable in game UI
        if (game.gameIsComplete)
        {
            mainCam.gameObject.SetActive(false);
            sceneCam.gameObject.SetActive(true);
            gameUI.SetActive(false);
        }
    }
}
