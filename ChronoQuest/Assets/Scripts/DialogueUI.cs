using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    //Dialogue System provided by:
    //https://gamedevbeginner.com/dialogue-systems-in-unity/

    //Main dialogue assets
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] GameObject textBox;

    //Dialogue Tracker
    public static event Action OnDialogueStarted;
    public static event Action OnDialogueEnded;
    bool skipLineTriggered;
    //private string[] currentDialogue;
    //private int currentDialogueIndex = 0;

    public void StartDialogue(string[] dialogue, string name)
    {
        //Enable all dialogue assets
        nameText.text = name;
        nameText.gameObject.SetActive(true);
        dialogueText.gameObject.SetActive(true);
        textBox.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(RunDialogue(dialogue));

        //currentDialogue = dialogue;
        //currentDialogueIndex = 0;

        //dialogueText.text = dialogue[0];
        //dialogueText.gameObject.SetActive(true);

        //textBox.SetActive(true);

        //RunDialogue(dialogue);
    }

    IEnumerator RunDialogue(string[] dialogue)
    {
        //Runs the coversation through all lines of dialogue
        skipLineTriggered = false;
        OnDialogueStarted?.Invoke();

        for (int i = 0; i < dialogue.Length; i++)
        {
            dialogueText.text = dialogue[i];
            while (skipLineTriggered == false)
            {
                // Wait for the current line to be skipped
                yield return null;
            }
            skipLineTriggered = false;
        }

        OnDialogueEnded?.Invoke();
        textBox.gameObject.SetActive(false);
    }

    public void SkipLine()
    {
        skipLineTriggered = true;
    }

    public void EndDialogue()
    {
        //Disable all dialogue assets
        nameText.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        textBox.SetActive(false);
    }
}
