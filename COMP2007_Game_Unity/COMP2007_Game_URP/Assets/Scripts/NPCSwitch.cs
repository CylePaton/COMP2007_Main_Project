using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSwitch : MonoBehaviour
{
    [Header("NPC Objects")]
    [SerializeField] NPCDialogue NPC1;
    [SerializeField] NPCDialogue NPC2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(NPC1.dialogueNum == 3 && NPC1.dialogueStarted == false)
        {
            NPC1.gameObject.SetActive(false);
            NPC2.gameObject.SetActive(true);
            
        }*/
        if(CompleteObjective.obj2Comp == true)
        {
            NPC1.gameObject.SetActive(false);
            NPC2.gameObject.SetActive(true);
        }
    }
}
