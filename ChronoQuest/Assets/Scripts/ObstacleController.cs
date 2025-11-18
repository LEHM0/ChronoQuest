using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject testObstacleOne;
    public GameObject testObstacleTwo;
    public GameObject connectedPuzzleOneObj;
    public GameObject connectedPuzzleTwoObj;

    private PuzzleBaseClass puzzleBaseClass;
    private TestPuzzle connectedPuzzleOne;
    private TestPuzzle connectedPuzzleTwo;
    private bool obstacleOneRemoved = false;
    private bool obstacleTwoRemoved = false;

    void Start()
    {
        puzzleBaseClass = GameObject.Find("Puzzle Controller").GetComponent<PuzzleBaseClass>();
        connectedPuzzleOne = connectedPuzzleOneObj.GetComponent<TestPuzzle>();
        connectedPuzzleTwo = connectedPuzzleTwoObj.GetComponent<TestPuzzle>();
    }

    void Update()
    {
        if (connectedPuzzleOne.solved && !obstacleOneRemoved)
        {
            Destroy(testObstacleOne);
            Debug.Log($"{connectedPuzzleOne.puzzleID} solved, Obstacle removed");
            obstacleOneRemoved = true;
        }
        if (connectedPuzzleTwo.solved && !obstacleTwoRemoved)
        {
            Destroy(testObstacleTwo);
            Debug.Log($"{connectedPuzzleTwo.puzzleID} solved, Obstacle removed");
            obstacleTwoRemoved = true;
        }
    }
}

public class Obstacle
{
    [SerializeField] private bool _cleared { get; set; }
    [SerializeField] private string _obstacleID { get; set; }
    //connectedPuzzle var
    //connectedPuzzle TestPuzzle component var

    public bool cleared
    {
        get { return _cleared; }
        set { _cleared = value; }
    }

    public string obstacleID
    {
        get { return _obstacleID; }
        set { _obstacleID = value; }
    }

    public virtual void ClearObstacle()
    {
        Debug.Log("Base Obstacle Method: You Shouldn't Be Seeing This");
    }
}

public class TestObstacle : Obstacle
{
    public TestObstacle(string obstacleID) { }

    public override void ClearObstacle()
    {
        //if (connected)
        //Check if connectedPuzzle is cleared and the obstacle hasn't been removed yet
        /*
         * if (puzzleVar.solved && !cleared)
         * Destroy(this.gameObject);
         * cleared = true;
         * Debug.Log($"{obstacleID} removed!");
         */
    }
}
