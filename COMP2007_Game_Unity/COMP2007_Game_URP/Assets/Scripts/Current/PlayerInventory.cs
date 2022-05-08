using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int numberCollected { get; private set; }

    //Variable to hold number of each spirit thats been caught
    public int numberOfYellow { get; private set; }
    public int numberOfGreen { get; private set; }
    public int numberOfBlue { get; private set; }

    //Unity event to handle updating the inventory
    public UnityEvent<PlayerInventory> OnItemCollected;

    public void ItemCollected()
    {
        numberCollected++;
        OnItemCollected.Invoke(this);
    }

    //Add yellow spirit
    public void YellowCollected()
    {
        numberOfYellow++;
        OnItemCollected.Invoke(this);
    }

    //Add green spirit
    public void GreenCollected()
    {
        numberOfGreen++;
        OnItemCollected.Invoke(this);
    }

    //Add blue spirit
    public void BlueCollected()
    {
        numberOfBlue++;
        OnItemCollected.Invoke(this);
   
    }

}
