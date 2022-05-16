using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMagic : MonoBehaviour
{
    //How far the staff can be used from
    public float range = 50f;

    //Referncing game objects
    public Camera fpsCam;
    public GameObject player;

    public GameObject impactEffectBlue;
    public GameObject impactEffectGreen;
    public GameObject impactEffectYellow;

    //Referencing code
    PlayerInventory playerInventory;
    CatchSpirit catchSpirit;

    private void Start()
    {
        //Getting player inventory
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        //player input
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShootDelay());
        }
    }

    public IEnumerator ShootDelay()
    {

        //Store info on hit object
        RaycastHit hit;

        //if the raycast hits something, store object data in hit
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Getting the CatchSpirit component
            catchSpirit = hit.transform.gameObject.GetComponent<CatchSpirit>();

            //If object has catch spirit component
            if (catchSpirit != null)
            {
                //Delay
                yield return new WaitForSeconds(0.3f);

                //Depending on spirit color, add a spirit to inventory
                if (catchSpirit.spiritColour == 1)
                {
                    playerInventory.GreenCollected();
                    hit.collider.gameObject.SetActive(false);
                    Instantiate(impactEffectGreen, hit.point, Quaternion.LookRotation(hit.normal));
                }
                else if (catchSpirit.spiritColour == 2)
                {
                    playerInventory.BlueCollected();
                    hit.collider.gameObject.SetActive(false);
                    Instantiate(impactEffectBlue, hit.point, Quaternion.LookRotation(hit.normal));
                }
                else if (catchSpirit.spiritColour == 3)
                {
                    playerInventory.YellowCollected();
                    Instantiate(impactEffectYellow, hit.point, Quaternion.LookRotation(hit.normal));
                    hit.collider.gameObject.SetActive(false);
                }

            }
        }
    }
    
}
