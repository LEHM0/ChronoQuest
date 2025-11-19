using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject testObstacleOne;
    public GameObject testObstacleTwo;
    public GameObject connectedPuzzleOneObj;
    public GameObject connectedPuzzleTwoObj;

    private PuzzleBaseClass puzzleBaseClass;
    //private TestPuzzle connectedPuzzleOne;
    //private TestPuzzle connectedPuzzleTwo;
    //private bool obstacleOneRemoved = false;
    //private bool obstacleTwoRemoved = false;

    void Start()
    {
        puzzleBaseClass = GameObject.Find("Puzzle Controller").GetComponent<PuzzleBaseClass>();

        //Initialize two testObs (w/ obsID) + conPuz objects
        TestObstacle toOne = testObstacleOne.AddComponent<TestObstacle>();
        toOne.obstacleID = "Test Obstacle 01";
        toOne.connectedPuzzleObj = connectedPuzzleOneObj;

        TestObstacle toTwo = testObstacleTwo.AddComponent<TestObstacle>();
        toTwo.obstacleID = "Test Obstacle 02";
        toTwo.connectedPuzzleObj = connectedPuzzleTwoObj;
    }

    void Update()
    {
        //if (connectedPuzzleOne.solved && !obstacleOneRemoved)
        //{
        //    Destroy(testObstacleOne);
        //    Debug.Log($"{connectedPuzzleOne.puzzleID} solved, Obstacle removed");
        //    obstacleOneRemoved = true;
        //}
        //if (connectedPuzzleTwo.solved && !obstacleTwoRemoved)
        //{
        //    Destroy(testObstacleTwo);
        //    Debug.Log($"{connectedPuzzleTwo.puzzleID} solved, Obstacle removed");
        //    obstacleTwoRemoved = true;
        //}
    }
}

public class Obstacle : MonoBehaviour
{
    public bool cleared;
    public string obstacleID;
    public GameObject connectedPuzzleObj;
    protected Puzzle connectedPuzzle;

    //public bool cleared
    //{
    //    get { return _cleared; }
    //    set { _cleared = value; }
    //}

    //public string obstacleID
    //{
    //    get { return _obstacleID; }
    //    set { _obstacleID = value; }
    //}

    //public GameObject connectedPuzzleObj
    //{
    //    get { return _connectedPuzzleObj; }
    //    set { _connectedPuzzleObj = value; }
    //}

    //public var connectedPuzzleComponentVar
    //{
    //    get { return _connectedPuzzleComponentVar; }
    //    set { _connectedPuzzleComponentVar = value; }
    //}

    protected virtual void Start()
    {
        connectedPuzzle = connectedPuzzleObj.GetComponent<TestPuzzle>();
    }

    protected virtual void Update()
    {
        if (!cleared && connectedPuzzle.solved)
        {
            ClearObstacle();
        }
    }

    public virtual void ClearObstacle()
    {
        Debug.Log("Base Obstacle Method: You Shouldn't Be Seeing This");
    }
}

public class TestObstacle : Obstacle
{
    public override void ClearObstacle()
    {
        Destroy(gameObject);
        cleared = true;
        Debug.Log($"{obstacleID} removed!");
    }
}
