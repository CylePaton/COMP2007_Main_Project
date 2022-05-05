using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowShrine : MonoBehaviour
{
    bool canInteract = false;

    public bool shrineActive = false;

    [Header("This Shrine")]
    [SerializeField] GameObject deactiveLight;
    [SerializeField] GameObject activeLight;

    [Header("TreeShrine")]
    [SerializeField] GameObject mainDeactiveLight;
    [SerializeField] GameObject mainActiveLight;
 
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
        if (Input.GetKeyDown(KeyCode.E) && canInteract && playerInventory.numberOfYellow >= 5)
        {
            deactiveLight.SetActive(false);
            mainDeactiveLight.SetActive(false);

            activeLight.SetActive(true);
            mainActiveLight.SetActive(true);

            shrineActive = true;

        }
    }
}
