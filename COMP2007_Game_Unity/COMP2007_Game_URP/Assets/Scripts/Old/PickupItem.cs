using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    bool canPickUp = false;

    PlayerInventory playerInventory;

    private void OnTriggerEnter(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            canPickUp = false;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canPickUp)
        {
            playerInventory.ItemCollected();
            gameObject.SetActive(false);
        }
    }
        
}
