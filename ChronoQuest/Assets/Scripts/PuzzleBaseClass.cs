using UnityEngine;

public class Puzzle : MonoBehaviour
{
    //The variable checked for progression, an ID for debugging purposes, and the solution logic
    public bool solved;
    public string puzzleID;

    protected virtual void Update()
    {
        //Ensures the Solution method does not run infinitely
        if (!solved)
        {
            Solution();
        }
    }

    public virtual void Solution()
    {
        //Overridable function for unique puzzle solutions
        Debug.Log("Base Solution Method: You Shouldn't Be Seeing This");
    }
}

//Basic Puzzle for testing purposes
public class TestPuzzle : Puzzle
{
    public override void Solution()
    {
        if (puzzleID == "Test Puzzle 01" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log($"{puzzleID} solved!");
            solved = true;
        }
        if (puzzleID == "Test Puzzle 02" && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log($"{puzzleID} solved!");
            solved = true;
        }
    }
}
