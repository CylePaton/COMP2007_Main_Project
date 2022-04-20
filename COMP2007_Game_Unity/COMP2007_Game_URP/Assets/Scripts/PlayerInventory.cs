using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int numberCollected { get; private set; }

    public UnityEvent<PlayerInventory> OnItemCollected;

    public void ItemCollected()
    {
        numberCollected++;
        OnItemCollected.Invoke(this);
    }
}
