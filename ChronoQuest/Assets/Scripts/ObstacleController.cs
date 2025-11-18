using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject testObstacle;
    public GameObject connectedPuzzleObj;

    private PuzzleBaseClass puzzleBaseClass;
    private TestPuzzle connectedPuzzle;
    private bool obstacleRemoved = false;

    void Start()
    {
        puzzleBaseClass = GameObject.Find("Puzzle Controller").GetComponent<PuzzleBaseClass>();
        connectedPuzzle = connectedPuzzleObj.GetComponent<TestPuzzle>();
    }

    void Update()
    {
        if (connectedPuzzle.solved && !obstacleRemoved)
        {
            Destroy(testObstacle);
            Debug.Log($"{connectedPuzzle.puzzleID} solved, Obstacle removed");
            obstacleRemoved = true;
        }
    }
}
