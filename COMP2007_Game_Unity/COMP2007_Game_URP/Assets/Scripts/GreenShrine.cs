using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenShrine : MonoBehaviour
{
    bool canInteract = false;

    PlayerInventory playerInventory;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract && playerInventory.numberOfGreen >= 5)
        {
            print("Give Green Gem");
        }
    }
}
