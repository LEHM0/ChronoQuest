using UnityEngine;

public class PuzzleBaseClass : MonoBehaviour
{
    void Start()
    {
        //TestPuzzle tp = new TestPuzzle("Test Puzzle 01");
    }

    void Update()
    {
        
    }
}

interface ISolved
{
    //An inheritable bool value checked for by progression gates
    bool solved { get; set; }
}

public class Puzzle : ISolved
{
    //The variable checked for progression, an ID constructor for debugging purposes, and the solution logic
    public bool solved { get; set; }
    public string puzzleID { get; set; }

    public Puzzle(string id)
    {
        solved = false;
        puzzleID = id;
    }

    public virtual void Solution()
    {
        Debug.Log("If you're seeing this, something went wrong");
    }
}

public class TestPuzzle : Puzzle
{
    public TestPuzzle(string id) : base(id) { }

    public override void Solution()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log($"{puzzleID} solved!");
            solved = true;
        }
    }
}
