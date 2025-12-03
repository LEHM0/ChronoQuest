using Unity.VisualScripting;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject model;
    public bool canTalk;
    public string npcName;
    public DialogueAsset defaultDialogue;

    public GameObject dialogueWindow;
    private DialogueUI dUI;

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
        canTalk = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canTalk = false;
    }

    private void Talk()
    {
        if (canTalk && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log($"{npcName} says hello!");
            dUI.StartDialogue("Hello", npcName);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                dUI.EndDialogue();
            }
        }
    }

    private void FacePlayer()
    {
        //
    }
}
