using Unity.VisualScripting;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    //Dialogue System provided by:
    //https://gamedevbeginner.com/dialogue-systems-in-unity/

    //Main NPC assets and dialogue
    public GameObject model;
    public bool canTalk;
    public string npcName;
    public DialogueAsset defaultDialogue;
    public DialogueAsset mainDialogue;

    //Dialogue system assets
    public GameObject dialogueWindow;
    protected DialogueUI dUI;
    protected bool isDialogueActive = false;

    void Awake()
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

    public virtual void Talk()
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
}
