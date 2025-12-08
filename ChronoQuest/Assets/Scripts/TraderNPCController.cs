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
            Trade();
        }
    }

    public void Trade()
    {
        if (tradeItem == tq.hasItem)
        {
            //Trade Dialogue
            tq.hasItem += 1;
        }
    }
}
