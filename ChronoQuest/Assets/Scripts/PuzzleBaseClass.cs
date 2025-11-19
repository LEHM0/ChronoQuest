using UnityEngine;

public class PuzzleBaseClass : MonoBehaviour
{
    public GameObject puzzleObjOne;
    public GameObject puzzleObjTwo;

    //Awake runs before Start, so this script assigns the TestPuzzle component in Awake, and the ObstacleController script checks for the component in Start
    void Awake()
    {
        TestPuzzle tpOne = puzzleObjOne.AddComponent<TestPuzzle>();
        tpOne.puzzleID = "Test Puzzle 01";

        Debug.Log("Test puzzle 01 instantiated");

        TestPuzzle tpTwo = puzzleObjTwo.AddComponent<TestPuzzle>();
        tpTwo.puzzleID = "Test Puzzle 02";

        Debug.Log("Test puzzle 02 instantiated");
    }
}

//interface ISolved
//{
//    //An inheritable bool value checked for by progression gates
//    bool solved;// { get; set; }
//}

public class Puzzle : MonoBehaviour//, ISolved
{
    //The variable checked for progression, an ID for debugging purposes, and the solution logic
    [SerializeField] private bool _solved;
    [SerializeField] private string _puzzleID;

    public bool solved;
    public string puzzleID;

    //public bool solved
    //{
    //    get { return _solved; }
    //    set { _solved = value; }
    //}

    //public string puzzleID
    //{
    //    get { return _puzzleID; }
    //    set { _puzzleID = value; }
    //}

    protected virtual void Update()
    {
        if (!_solved)
        {
            Solution();
        }
    }

    public virtual void Solution()
    {
        Debug.Log("Base Solution Method: You Shouldn't Be Seeing This");
    }
}

public class TestPuzzle : Puzzle
{
    public TestPuzzle(string id) { }

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
