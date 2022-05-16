using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCDialogue : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject npcUI;
    [SerializeField] Image text1;
    [SerializeField] Image text2;
    [SerializeField] Image text3;

    [Header("Cameras")]
    [SerializeField] Camera playerCam;
    [SerializeField] Camera dialogueCam;

    [Header("Animation")]
    [SerializeField] Animator animator;

    [Header("DialogueAudio")]
    [SerializeField] AudioSource dialogue;
    [SerializeField] AudioClip dialogue1;
    [SerializeField] AudioClip dialogue2;
    [SerializeField] AudioClip dialogue3;

    [Header("Variables")]
    [SerializeField] int toScene = 2;
    [SerializeField] bool sendToScene = true;

    //Variables
    public bool dialogueStarted = false;
    public int dialogueNum  = 0;
    bool showUI = false;

    //Check if sounds have played
    bool sound1HasPlayed = false;
    bool sound2HasPlayed = false;
    bool sound3HasPlayed = false;

    //Should an objective be linked to this npc
    public bool objectives = false;

    //Which objective
    public int objectiveNum = 0;

    PlayerInventory playerInventory;

    //Setting dialogue objects to false
    private void Start()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
    }

    //When something enters the collider, check if its the player, if so allow the dialogue to be shown
    private void OnTriggerEnter(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            showUI= true;
        }

    }

    //When something exits the collider, check if its the player, if so dont allow the dialogue to be shown
    private void OnTriggerExit(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            showUI = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        NPCInteraction();

        DialogueOptions();
    }

    public void NPCInteraction()
    {
        //If the player is in the collider of the npc and they press E, then start the dialogue
        if (showUI && Input.GetKeyDown(KeyCode.E))
        {
            //Starting the talk animation
            animator.SetBool("IsTalking", true);

            //Setting any objective linked to the npc
            if (objectives)
            {
                if(objectiveNum == 0)
                {
                    CompleteObjective.obj0Comp = true;
                }
                if(objectiveNum == 1)
                {
                    CompleteObjective.obj1Comp = true;
                }
                if(objectiveNum == 2)
                {
                    CompleteObjective.obj2Comp = true;
                }
                if (objectiveNum == 3)
                {
                    CompleteObjective.obj3Comp = true;
                }
            }
            
            //Setting active any UI elements and changing the cam from the pov to the dialogue scene cam
            npcUI.gameObject.SetActive(true);
            playerCam.gameObject.SetActive(false);
            dialogueCam.gameObject.SetActive(true);

            //Setting the game to a pause like state
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //Setting the dialogue started so the audio doesnt player before the UI element appear
            dialogueStarted = true;

            PauseMenu.gameIsPaused = true;
        }
    }

    public void DialogueOptions()
    {
        //If the NPC is talking then play the talk animation, when they stop, go back to the idle animcation
        if (dialogue.isPlaying)
        {
            animator.SetBool("IsTalking", true);
        }
        else
        {
            animator.SetBool("IsTalking", false);
        }

        //This code is responsible for displaying/playing the dialogue in the correct order when the next button is pressed
        if (dialogueNum == 0 && dialogueStarted)
        {
            text1.gameObject.SetActive(true);

            text2.gameObject.SetActive(false);
            text3.gameObject.SetActive(false);

            //If the sound hasnt played then play it, then make sure it doesnt play again
            if (!sound1HasPlayed)
            {
                dialogue.PlayOneShot(dialogue1);
                sound1HasPlayed = true;
            }
        }
        if (dialogueNum == 1)
        {
            text2.gameObject.SetActive(true);

            text1.gameObject.SetActive(false);
            text3.gameObject.SetActive(false);

            //If the sound hasnt played then play it, then make sure it doesnt play again
            if (!sound2HasPlayed)
            {
                dialogue.PlayOneShot(dialogue2);
                sound2HasPlayed = true;

            }
        }
        if (dialogueNum == 2)
        {
            text3.gameObject.SetActive(true);

            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(false);

            //If the sound hasnt played then play it, then make sure it doesnt play again
            if (!sound3HasPlayed)
            {
                dialogue.PlayOneShot(dialogue3);
                sound3HasPlayed = true;
            }
        }

        //This option will reset the game/player to the game state after the dialogue is finished
        if(dialogueNum == 3)
        {

            npcUI.gameObject.SetActive(false);
            playerCam.gameObject.SetActive(true);
            dialogueCam.gameObject.SetActive(false);


            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            PauseMenu.gameIsPaused = false;

            dialogueStarted = false;

        }
        //This option will start a new scene, which is used in the intro and tutorial
        if (dialogueNum == 3 && sendToScene)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            PauseMenu.gameIsPaused = false;

            dialogueStarted = false;

            SceneManager.LoadScene(toScene);
        }
       
    }
    //This code is for the next button to progress the dialogue
    public void NextDialogue()
    {
        dialogueNum += 1;
    }
}
