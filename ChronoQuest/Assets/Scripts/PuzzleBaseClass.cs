using UnityEngine;

public class PuzzleBaseClass : MonoBehaviour
{
    void Start()
    {
        GameObject puzzleObj = new GameObject("Test Puzzle");
        TestPuzzle tp = puzzleObj.AddComponent<TestPuzzle>();
        tp.puzzleID = "Test Puzzle 01";

        Debug.Log("Test puzzle instantiated");
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

public class Puzzle : MonoBehaviour, ISolved
{
    //The variable checked for progression, an ID for debugging purposes, and the solution logic
    [SerializeField] private bool _solved { get; set; }
    [SerializeField] private string _puzzleID { get; set; }

    public bool solved
    {
        get { return _solved; }
        set { _solved = value; }
    }

    public string puzzleID
    {
        get { return _puzzleID; }
        set { _puzzleID = value; }
    }

    protected virtual void Update()
    {
        if (!_solved)
        {
            Solution();
        }
    }

    public virtual void Solution()
    {
        Debug.Log("If you're seeing this, something went wrong");
    }
}

public class TestPuzzle : Puzzle
{
    public TestPuzzle(string id) { }

    public override void Solution()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log($"{puzzleID} solved!");
            solved = true;
        }
    }
}
