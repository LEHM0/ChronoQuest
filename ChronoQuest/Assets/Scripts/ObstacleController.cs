using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject testObstacleOne;
    public GameObject testObstacleTwo;
    public GameObject connectedPuzzleOneObj;
    public GameObject connectedPuzzleTwoObj;

    private PuzzleBaseClass puzzleBaseClass;

    void Start()
    {
        puzzleBaseClass = GameObject.Find("Puzzle Controller").GetComponent<PuzzleBaseClass>();

        TestObstacle toOne = testObstacleOne.AddComponent<TestObstacle>();
        toOne.obstacleID = "Test Obstacle 01";
        toOne.connectedPuzzleObj = connectedPuzzleOneObj;

        TestObstacle toTwo = testObstacleTwo.AddComponent<TestObstacle>();
        toTwo.obstacleID = "Test Obstacle 02";
        toTwo.connectedPuzzleObj = connectedPuzzleTwoObj;
    }
}

public class Obstacle : MonoBehaviour
{
    public bool cleared;
    public string obstacleID;
    public GameObject connectedPuzzleObj;
    protected Puzzle connectedPuzzle;

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
