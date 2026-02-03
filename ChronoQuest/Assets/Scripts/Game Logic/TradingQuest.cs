using UnityEngine;

public class TradingQuest : Puzzle
{
    public GameObject tradeController; // Redundant?
    public GameObject[] traderNpcs;
    public int hasItem = 0;

    protected override void Update()
    {
        if (hasItem == 2 && !solved)
        {
            solved = true;
        }
    }
}
