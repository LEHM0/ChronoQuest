using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] GameObject textBox;

    public void StartDialogue(string dialogue, string name)
    {
        //Fix: Object reference not set to an instance of an object
        nameText.text = name;
        dialogueText.text = dialogue;
        textBox.SetActive(true);
    }

    public void EndDialogue()
    {
        nameText = null;
        dialogueText = null;
        textBox.SetActive(false);
    }
}
