using UnityEngine;

public class TraderNPCController : NPCController
{
    public DialogueAsset baseDialogue;
    public DialogueAsset tradingDialogue;
    public DialogueAsset finishedDialogue;

    public int tradeItem;

    public GameObject tradeController;
    private TradingQuest tq;

    void Start()
    {
        tq = tradeController.GetComponent<TradingQuest>();
    }

    void Update()
    {
        Talk();
    }

    public override void Talk()
    {
        if (canTalk && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (tradeItem > tq.hasItem)
            {
                //Trade Request Dialogue
                if (!isDialogueActive)
                {
                    Debug.Log($"{npcName} wants to trade!");
                    dUI.StartDialogue(baseDialogue.dialogue, npcName);
                    isDialogueActive = true;
                }
                else
                {
                    dUI.EndDialogue();
                    isDialogueActive = false;
                }
            }

            else if (tradeItem < tq.hasItem)
            {
                //Trade Finished Dialogue
                if (!isDialogueActive)
                {
                    Debug.Log($"{npcName} thanks you for the trade!");
                    dUI.StartDialogue(finishedDialogue.dialogue, npcName);
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
                //Trading Dialogue
                if (!isDialogueActive)
                {
                    Debug.Log($"{npcName} has traded with you!");
                    dUI.StartDialogue(tradingDialogue.dialogue, npcName);
                    isDialogueActive = true;
                }
                else
                {
                    dUI.EndDialogue();
                    isDialogueActive = false;
                }

                Trade();
            }
        }
    }

    public void Trade()
    {
        if (tradeItem == tq.hasItem)
        {
            tq.hasItem += 1;
        }
    }
}
