using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPickup : MonoBehaviour
{
    public GameObject itemObj;
    public bool canPickUp = false;
    public bool itemObtained = false;

    public GameObject tradeController;
    private TradingQuest tq;

    void Start()
    {
        tq = tradeController.GetComponent<TradingQuest>();
    }

    void Update()
    {
        if (!itemObtained)
        {
            PickUpItem();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        canPickUp = true;
    }

    public void OnTriggerExit(Collider other)
    {
        canPickUp = false;
    }

    public void PickUpItem()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.Mouse0))
        {
            tq.hasItem += 1;
            itemObtained = true;

            Destroy(itemObj);
            canPickUp = false;

            Debug.Log("Item Get");
        }
    }
}
