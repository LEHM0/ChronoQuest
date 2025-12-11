using UnityEngine;

public class TileMatchSolution : Puzzle
{
    //Tile Points
    public GameObject tileOne;
    public GameObject tileTwo;
    public GameObject tileThree;
    public GameObject tileFour;

    //Tile Point Scripts
    private TileMatching tileOneScript;
    private TileMatching tileTwoScript;
    private TileMatching tileThreeScript;
    private TileMatching tileFourScript;


    void Start()
    {
        tileOneScript = tileOne.GetComponent<TileMatching>();
        tileTwoScript = tileTwo.GetComponent<TileMatching>();
        tileThreeScript = tileThree.GetComponent<TileMatching>();
        tileFourScript = tileFour.GetComponent<TileMatching>();
    }

    protected override void Update()
    {
       base.Update();
    }

    public override void Solution()
    {
        //Checks each tile to see if it is set to the correct sequence of colors
        if (tileOneScript.isColor == tileOneScript.solvedColor)
        {
            if (tileTwoScript.isColor == tileTwoScript.solvedColor)
            {
                if (tileThreeScript.isColor == tileThreeScript.solvedColor)
                {
                    if (tileFourScript.isColor == tileFourScript.solvedColor)
                    {
                        solved = true;
                        Debug.Log($"{puzzleID} solved!");
                    }
                }
            }
        }
    }
}
