using Unity.VisualScripting;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    //Main NPC assets and dialogue
    public GameObject model;
    public bool canTalk;
    public string npcName;
    public DialogueAsset defaultDialogue;
    public DialogueAsset mainDialogue;

    //Dialogue system assets
    public GameObject dialogueWindow;
    private DialogueUI dUI;
    private bool isDialogueActive = false;

    void Start()
    {
        dUI = dialogueWindow.GetComponent<DialogueUI>();
    }

    void Update()
    {
        Talk();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = false;
        }
    }

    private void Talk()
    {
        if (canTalk && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (mainDialogue == null)
            {
                if (!isDialogueActive)
                {
                    //Deafult dialogue if main dialogue cannot be found
                    Debug.Log($"{npcName} couldn't find their dialogue");
                    dUI.StartDialogue(defaultDialogue.dialogue, npcName);
                    isDialogueActive = true;
                }
                else
                {
                    dUI.EndDialogue();
                    isDialogueActive = false;
                }
            }
            else
            {
                if (!isDialogueActive)
                {
                    Debug.Log($"{npcName} says hello!");
                    //ToDo: Loop through all available dialogue
                    dUI.StartDialogue(mainDialogue.dialogue, npcName);
                    isDialogueActive = true;
                }
                else
                {
                    dUI.EndDialogue();
                    isDialogueActive = false;
                }
            }
        }
    }

    private void FacePlayer()
    {
        //if canTalk == true, turn to face the player
    }
}
