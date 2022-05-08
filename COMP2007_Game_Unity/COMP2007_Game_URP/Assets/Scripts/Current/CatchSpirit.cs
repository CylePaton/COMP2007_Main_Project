using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchSpirit : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float rotationSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    Rigidbody rb;
    
    // Checking which spirit(0 = green, 1 = blue, 2 = yellow)
    public int spiritColour;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //AI Movement, which randomly choose wether to move a random amount or rotate a random amount
        if(isWandering == false)
        {
            StartCoroutine(Wander());
        }
        //Rotate right random amount
        if(isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        //Rotate left random amount
        if(isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }
        //Walk random amount
        if(isWalking == true)
        {
            rb.AddForce(transform.forward * movementSpeed);
        }
    }

    IEnumerator Wander()
    {

        //Getting a random range for each movement variable
        int rotationTime = Random.Range(1, 3);
        int rotationWait = Random.Range(1, 3);
        int rotationDirecion = Random.Range(1, 3);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);

        isWandering = true;

        //Wait a between 1 - 3 seconds
        yield return new WaitForSeconds(walkWait);

        isWalking = true;

        //Walks for between 1 - 3 seconds
        yield return new WaitForSeconds(walkTime);

        isWalking = false;

        //Wait between range to rotate
        yield return new WaitForSeconds(rotationWait);

        // Depending on rotation direction, chooses a random amount to rotate left or right

        if(rotationDirecion == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }
        if (rotationDirecion == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }

        isWandering = false;
    }
}
