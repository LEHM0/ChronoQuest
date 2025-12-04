using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    //Main dialogue assets
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] GameObject textBox;

    //Dialogue Tracker
    private string[] currentDialogue;
    private int currentDialogueIndex = 0;

    public void StartDialogue(string[] dialogue, string name)
    {
        //Enable all dialogue assets
        nameText.text = name;
        nameText.gameObject.SetActive(true);

        currentDialogue = dialogue;
        currentDialogueIndex = 0;

        dialogueText.text = dialogue[0];
        dialogueText.gameObject.SetActive(true);

        textBox.SetActive(true);

        RunDialogue(dialogue);
    }

    public void RunDialogue(string[] dialogue)
    {
        //Runs the coversation through all lines of dialogue
        for (int i = 0; i < dialogue.Length; i++)
        {
            dialogueText.text = dialogue[i];
        }
    }

    public void EndDialogue()
    {
        //Disable all dialogue assets
        nameText.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        textBox.SetActive(false);
    }
}
