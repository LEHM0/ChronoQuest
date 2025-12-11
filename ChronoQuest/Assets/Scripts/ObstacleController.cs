using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //Main Obstacle components
    public bool cleared;
    public string obstacleID;
    public GameObject connectedPuzzleObj;
    protected Puzzle connectedPuzzle;

    protected virtual void Start()
    {
        connectedPuzzle = connectedPuzzleObj.GetComponent<Puzzle>();
    }

    protected virtual void Update()
    {
        //Checks to see if the puzzle has been solved and the obstacle is not already cleared
        if (!cleared && connectedPuzzle.solved)
        {
            ClearObstacle();
        }
    }

    public virtual void ClearObstacle()
    {
        //Base overridable method for clearing an obstacle out of the way
        Destroy(gameObject);
        cleared = true;
        Debug.Log($"{obstacleID} removed!");
    }
}

//Basic Obstacle for testing purposes
public class TestObstacle : Obstacle
{
    public override void ClearObstacle()
    {
        Destroy(gameObject);
        cleared = true;
        Debug.Log($"{obstacleID} removed!");
    }
}
