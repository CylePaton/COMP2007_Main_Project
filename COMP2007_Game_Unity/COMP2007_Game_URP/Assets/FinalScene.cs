using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    [Header("Cameras")]
    public Camera mainCam;
    public Camera sceneCam;

    [Header("References")]
    public TreeShrine treeShrine;
    public GameComplete game;

    [Header("UI")]
    public GameObject gameUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (game.gameIsComplete)
        {
            mainCam.gameObject.SetActive(false);
            sceneCam.gameObject.SetActive(true);
            gameUI.SetActive(false);
        }
    }
}
