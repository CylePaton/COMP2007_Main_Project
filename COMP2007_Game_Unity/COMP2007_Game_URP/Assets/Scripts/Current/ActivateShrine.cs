using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShrine : MonoBehaviour
{
    //Bool which will be set true when player is in collider of shrine
    bool canActivate = false;

    //Bool set to true when shrine has been activated
    public bool shrineActive = false;

    //Variables which will change which type of shrine the object is and how many spirits it needs
    [Header("Shrine Variables")]
    [SerializeField] int shrineType = 0;
    [SerializeField] public int spiritsNeeded = 10;

    //References to the visual and audiable FX used on the shrine
    [Header("Game Objects")]
    [SerializeField] GameObject deactiveGem;
    [SerializeField] GameObject activeGem;
    [SerializeField] AudioSource activatedSound;

    //Used to check if the object colliding is the player and to check spirit number
    PlayerInventory playerInventory;

    // If player enters collider then they can activate the shrine
    private void OnTriggerEnter(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if(playerInventory != null)
        {
            canActivate = true;
        }
    }

    // If player exits collider then they cannot activate the shrine
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
        //When the player presses E and is in the collider
        if (Input.GetKeyDown(KeyCode.E) && canActivate)
        {
            //If the current shrine is an earth shrine (0) and the player has the required number of earth spirits then activate the shrine
            if(shrineType == 0 && playerInventory.numberOfGreen >= spiritsNeeded)
            {
                //Visual effect
                deactiveGem.SetActive(false);
                activeGem.SetActive(true);

                //Audio effect
                activatedSound.Play();
                
                //Bool for checking if shrine is active
                shrineActive = true;
                
                //Objective 2 complete
                CompleteObjective.obj2Comp = true;
                
            }

            //If the current shrine is a water shrine (1) and the player has the required number of water spirits then activate the shrine
            if (shrineType == 1 && playerInventory.numberOfBlue >= spiritsNeeded)
            {
                //Visual effect
                deactiveGem.SetActive(false);
                activeGem.SetActive(true);

                //Audio effect
                activatedSound.Play();

                //Bool for checking if shrine is active
                shrineActive = true;

            }

            //If the current shrine is a sun shrine (2) and the player has the required number of sun spirits then activate the shrine
            if (shrineType == 2 && playerInventory.numberOfYellow >= spiritsNeeded)
            {
                //Visual effect
                deactiveGem.SetActive(false);
                activeGem.SetActive(true);

                //Audio effect
                activatedSound.Play();

                //Bool for checking if shrine is active
                shrineActive = true;

            }
        }
    }
}
