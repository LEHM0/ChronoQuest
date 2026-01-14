using UnityEngine;
using UnityEngine.UI;

public class AnomalyInteraction : MonoBehaviour
{
    public GameObject model;
    public bool canInteract;

    public GameObject choiceWindow;
    public Button posKarmaButton;
    public Button negKarmaButton;

    private void Start()
    {
        posKarmaButton.onClick.AddListener(GoodKarmaChoice);
        negKarmaButton.onClick.AddListener(BadKarmaChoice);

    }

    void Update()
    {
        MakeChoice();
    }

    public void MakeChoice()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.Mouse0))
        {
            choiceWindow.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void GoodKarmaChoice()
    {
        choiceWindow.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

        GameManager.instance.AddGoodKarma();
        GameManager.instance.ClearLevel();
    }

    public void BadKarmaChoice()
    {
        choiceWindow.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

        GameManager.instance.AddBadKarma();
        GameManager.instance.ClearLevel();
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
