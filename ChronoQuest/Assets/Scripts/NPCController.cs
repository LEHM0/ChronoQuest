using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject model;
    public bool canTalk;
    public string npcName;

    void Start()
    {
        //
    }

    void Update()
    {
        Talk();
    }

    private void OnTriggerEnter(Collider other)
    {
        canTalk = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canTalk = false;
    }

    private void Talk()
    {
        if (canTalk && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log($"{npcName} says hello!");
        }
    }

    private void FacePlayer()
    {
        //
    }
}
