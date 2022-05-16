using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHint : MonoBehaviour
{
    //Bool to check if player is in collider
    bool showHint = false;

    //Image ref
    public Image hint;

    //To check if its the player colliding
    PlayerInventory playerInventory;

    //If player has entered collider than allow the hint to be shown
    private void OnTriggerEnter(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if(playerInventory != null)
        {
            showHint = true;
        }
        
    }

    //If the player exits the collider than make the hint invisable
    private void OnTriggerExit(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            showHint = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Show hint if the player has entered collider else dont show it
        if (showHint)
        {
            hint.gameObject.SetActive(true);
        }
        else
        {
            hint.gameObject.SetActive(false);
        }
    }
}
