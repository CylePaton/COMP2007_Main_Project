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

    bool showUI = false;
    bool dialogueStarted = false;
    int dialogueNum  = 0;

    bool sound1HasPlayed = false;
    bool sound2HasPlayed = false;
    bool sound3HasPlayed = false;

    PlayerInventory playerInventory;

    private void Start()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            showUI= true;
        }

    }

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
        if (showUI && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("IsTalking", true);

            npcUI.gameObject.SetActive(true);
            playerCam.gameObject.SetActive(false);
            dialogueCam.gameObject.SetActive(true);

            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            dialogueStarted = true;

            PauseMenu.gameIsPaused = true;
        }
    }

    public void DialogueOptions()
    {
        if (dialogue.isPlaying)
        {
            animator.SetBool("IsTalking", true);
        }
        else
        {
            animator.SetBool("IsTalking", false);
        }

        if (dialogueNum == 0 && dialogueStarted)
        {
            text1.gameObject.SetActive(true);

            text2.gameObject.SetActive(false);
            text3.gameObject.SetActive(false);

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

            if (!sound3HasPlayed)
            {
                dialogue.PlayOneShot(dialogue3);
                sound3HasPlayed = true;
            }
        }
        if (dialogueNum == 3)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            PauseMenu.gameIsPaused = false;

            SceneManager.LoadScene(2);
        }
       
    }

    public void NextDialogue()
    {
        dialogueNum += 1;
    }
}
