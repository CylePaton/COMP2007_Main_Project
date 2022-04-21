using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI itemText;

    public TextMeshProUGUI yellowText;
    public TextMeshProUGUI blueText;
    public TextMeshProUGUI greenText;

    // Start is called before the first frame update
    void Start()
    {
        itemText = GetComponent<TextMeshProUGUI>();
    }

    public void updateItemText(PlayerInventory playerInventory)
    {
        itemText.text = playerInventory.numberCollected.ToString();

        yellowText.text = playerInventory.numberOfYellow.ToString();
        blueText.text = playerInventory.numberOfBlue.ToString();
        greenText.text = playerInventory.numberOfGreen.ToString();
    }
    
}
