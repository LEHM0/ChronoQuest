using UnityEngine;

public class DoorController : Obstacle
{
    public GameObject doorModel;

    public override void ClearObstacle()
    {
        //Removal logic
        doorModel.transform.Translate(Vector3.up * Time.deltaTime * 200); //Fix: Door moves instantly, not over time
        cleared = true;
        Debug.Log($"{obstacleID} removed!");
    }
}
