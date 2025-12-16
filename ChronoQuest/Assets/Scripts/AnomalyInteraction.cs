using UnityEngine;

public class AnomalyInteraction : MonoBehaviour
{
    public GameObject model;
    public bool canInteract;

    void Update()
    {
        MakeChoice();
    }

    public void MakeChoice()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Good Ending Test - Works
            //GameManager.instance.AddGoodKarma();
            //GameManager.instance.TestClearLevel();

            //Bad Ending Test - Works
            GameManager.instance.AddBadKarma();
            GameManager.instance.ClearLevel();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        canInteract = true;
    }

    public void OnTriggerExit(Collider other)
    {
        canInteract = false;
    }
}
