using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShrine : MonoBehaviour
{
    bool canActivate = false;
    public bool shrineActive = false;

    [Header("Shrine Variables")]
    [SerializeField] int shrineType = 0;
    [SerializeField] int spiritsNeeded = 10;

    [Header("Game Objects")]
    [SerializeField] GameObject deactiveGem;
    [SerializeField] GameObject activeGem;
    [SerializeField] AudioSource activatedSound;

    PlayerInventory playerInventory;

    private void OnTriggerEnter(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if(playerInventory != null)
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if(playerInventory != null)
        {
            canActivate = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && canActivate)
        {

            if(shrineType == 0 && playerInventory.numberOfGreen >= spiritsNeeded)
            {
                deactiveGem.SetActive(false);
                activeGem.SetActive(true);

                activatedSound.Play();
                shrineActive = true;
            }

            if (shrineType == 1 && playerInventory.numberOfBlue >= spiritsNeeded)
            {
                deactiveGem.SetActive(false);
                activeGem.SetActive(true);

                activatedSound.Play();
                shrineActive = true;
            }

            if (shrineType == 2 && playerInventory.numberOfYellow >= spiritsNeeded)
            {
                deactiveGem.SetActive(false);
                activeGem.SetActive(true);

                activatedSound.Play();
                shrineActive = true;
            }
        }
    }
}
