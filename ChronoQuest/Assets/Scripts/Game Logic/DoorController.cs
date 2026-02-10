using System.Collections;
using UnityEngine;

public class DoorController : Obstacle
{
    public GameObject doorModel;

    private Vector3 startPos = Vector3.zero;
    private Vector3 endPos = Vector3.up * 5;
    private float time = 5.0f;

    public override void ClearObstacle()
    {
        //Removal logic
        StartCoroutine(MoveUp());
        cleared = true;
        Debug.Log($"{obstacleID} removed!");
    }

    IEnumerator MoveUp()
    {
        doorModel.transform.position += Vector3.Lerp(startPos, endPos, time);
        //Fix: Door moves instantly, not over time - Working On
        yield return null;
    }
}
