using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    //Getting the text objects
    public TextMeshProUGUI yellowText;
    public TextMeshProUGUI blueText;
    public TextMeshProUGUI greenText;

    //Getting shrines for number of spirits needed
    public ActivateShrine earthShrine;
    public ActivateShrine waterShrine;
    public ActivateShrine sunShrine;

    //Getting player inventory
    public PlayerInventory playerInventory;

    //Setting UI text to number in inventory
    private void Update()
    {
        yellowText.text = playerInventory.numberOfYellow.ToString() + "/" + sunShrine.spiritsNeeded.ToString();
        blueText.text = playerInventory.numberOfBlue.ToString() + "/" + waterShrine.spiritsNeeded.ToString();
        greenText.text = playerInventory.numberOfGreen.ToString() + "/" + earthShrine.spiritsNeeded.ToString();
    }

}
