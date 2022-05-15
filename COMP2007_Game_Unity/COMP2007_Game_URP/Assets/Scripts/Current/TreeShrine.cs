using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShrine : MonoBehaviour
{
    // Getting info on the other shrines
    [Header("Shrines")]
    [SerializeField]ActivateShrine yellowShrine;
    [SerializeField]ActivateShrine greenShrine;
    [SerializeField]ActivateShrine blueShrine;

    [Header("Inactive Gems")]
    [SerializeField] GameObject greenGem;
    [SerializeField] GameObject blueGem;
    [SerializeField] GameObject yellowGem;
    [SerializeField] GameObject MainGem;

    [Header("Active Gems")]
    [SerializeField] GameObject greenGemActive;
    [SerializeField] GameObject blueGemActive;
    [SerializeField] GameObject yellowGemActive;
    [SerializeField] GameObject MainGemActive;

    [Header("Audio")]
    [SerializeField] AudioSource activatedSound;

    [Header("GameComplete")]
    public GameComplete gameComplete;

    // Bool
    public bool treeShrineActive = false;

    // Player inventory variable
    PlayerInventory playerInventory;

    // If this is true, the player can attempt to actiavte the shrine
    bool canInteract = false;

    // When the player enters the shrine collider, make them be able to activate the shrine
    private void OnTriggerEnter(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            canInteract = true;
        }
    }

    // When the player exits the shrine collider, make them not be able to activate the shrine
    private void OnTriggerExit(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            canInteract = false;
        }
    }

    // If the player is in the collider and has activated the other three shrines, they can activate this one
    private void Update()
    {
        if (greenShrine.shrineActive)
        {
            greenGem.SetActive(false);
            greenGemActive.SetActive(true);
        }
        if (blueShrine.shrineActive)
        {
            blueGem.SetActive(false);
            blueGemActive.SetActive(true);
        }
        if (yellowShrine.shrineActive)
        {
            yellowGem.SetActive(false);
            yellowGemActive.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && canInteract & yellowShrine.shrineActive && greenShrine.shrineActive && blueShrine.shrineActive)
        {
            treeShrineActive = true;
            MainGem.SetActive(false);
            MainGemActive.SetActive(true);

            activatedSound.Play();
            
            gameComplete.gameIsComplete = true;

        }
    }
}
