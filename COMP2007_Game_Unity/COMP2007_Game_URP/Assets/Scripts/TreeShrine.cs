using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShrine : MonoBehaviour
{
    public YellowShrine yellowShrine;
    public GreenShrine greenShrine;
    public BlueShrine blueShrine;

    PlayerInventory playerInventory;

    bool canInteract = false;

    private void OnTriggerEnter(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            canInteract = false;
        }
    }

    public void treeShrineActive()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract & yellowShrine.shrineActive && greenShrine.shrineActive && blueShrine.shrineActive)
        {
            print("Game Complete");
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && canInteract & yellowShrine.shrineActive && greenShrine.shrineActive && blueShrine.shrineActive)
        {
            print("Game Complete");
        }
    }
}
