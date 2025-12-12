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
            //Good Ending Test
            GameManager.instance.AddGoodKarma();
            GameManager.instance.TestClearLevel();

            //Bad Ending Test
            //GameManager.instance.AddBadKarma();
            //GameManager.instance.TestClearLevel();
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
