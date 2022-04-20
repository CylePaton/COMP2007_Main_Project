using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null && Input.GetMouseButtonDown(0))
        {
            playerInventory.ItemCollected();
            gameObject.SetActive(false);
        }
    }
}
