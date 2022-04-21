using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int numberCollected { get; private set; }

    public int numberOfYellow { get; private set; }
    public int numberOfGreen { get; private set; }
    public int numberOfBlue { get; private set; }

    public UnityEvent<PlayerInventory> OnItemCollected;

    public void ItemCollected()
    {
        numberCollected++;
        OnItemCollected.Invoke(this);
    }

    public void YellowCollected()
    {
        numberOfYellow++;
        OnItemCollected.Invoke(this);
    }

    public void GreenCollected()
    {
        numberOfGreen++;
        OnItemCollected.Invoke(this);
    }

    public void BlueCollected()
    {
        numberOfBlue++;
        OnItemCollected.Invoke(this);
    }

}
