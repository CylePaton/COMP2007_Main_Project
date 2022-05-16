using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSwitch : MonoBehaviour
{
    //This code switches out 1 instance of an NPC to another to allow new dialogue for the player
    [Header("NPC Objects")]
    [SerializeField] NPCDialogue NPC1;
    [SerializeField] NPCDialogue NPC2;

    // Update is called once per frame
    void Update()
    {
        if(CompleteObjective.obj2Comp == true)
        {
            NPC1.gameObject.SetActive(false);
            NPC2.gameObject.SetActive(true);
        }
    }
}
