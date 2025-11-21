using UnityEngine;

public class TileMatching : MonoBehaviour
{
    public GameObject tilePoint;
    public string isColor = "Blank";
    public string solvedColor;
    public bool canInteract;

    public GameObject blueTilePrefab;
    public GameObject greenTilePrefab;
    public GameObject redTilePrefab;
    public GameObject yellowTilePrefab;

    void Start()
    {
        //Multiple Tile Bases that can be interacted w/ individually - DONE
        //One Base w/ multiple Tile spots - DONE
        //Tile can only be interacted w/ when standing in front of - DONE
        //Multiple Tile Bases + Obstacles that don't interfere w/ each other
        //Add: Tiles cannot be interacted with after puzzle is solved
        //Add Related Obstacle
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    public void SwitchColor()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.Mouse0))
        {
            switch (isColor)
            {
                case "Blue":
                    {
                        isColor = "Green";
                        SetToGreen();

                        break;
                    }
                case "Green":
                    {
                        isColor = "Red";
                        SetToRed();

                        break;
                    }
                case "Red":
                    {
                        isColor = "Yellow";
                        SetToYellow();

                        break;
                    }
                case "Yellow":
                    {
                        isColor = "Blue";
                        SetToBlue();

                        break;
                    }
                default:
                    {
                        Debug.Log("Tile color is not assinged");

                        break;
                    }
            }
        }
    }

    public void SetToBlue()
    {
        yellowTilePrefab.SetActive(false);

        blueTilePrefab.SetActive(true);
    }

    public void SetToGreen()
    {
        blueTilePrefab.SetActive(false);

        greenTilePrefab.SetActive(true);
    }

    public void SetToRed()
    {
        greenTilePrefab.SetActive(false);

        redTilePrefab.SetActive(true);
    }

    public void SetToYellow()
    {
        redTilePrefab.SetActive(false);

        yellowTilePrefab.SetActive(true);
    }

    void Update()
    {
        SwitchColor();
    }
}
