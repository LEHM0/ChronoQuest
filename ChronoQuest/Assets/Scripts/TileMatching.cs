using UnityEngine;

public class TileMatching : Puzzle//MonoBehaviour
{
    public GameObject tileBase;
    public string isColor = "Blank";

    public GameObject blueTile;
    public GameObject greenTile;
    public GameObject redTile;
    public GameObject yellowTile;

    private PuzzleBaseClass puzzleBaseClass;

    void Start()
    {
        puzzleBaseClass = GameObject.Find("Puzzle Controller").GetComponent<PuzzleBaseClass>();

        //Set to an Empty GameObject w/ 3-4 other objects (tiles) attached to the script - DONE
        //Player can interact w/ Tile - DONE
        //Interacting w/ Tile changes Tile to next in sequence - DONE
        //Tiles change in a loop - DONE

        //Multiple Tile Bases that can be interacted w/ individually - Working On
        //One Base w/ multiple Tile spots
        //Tile can only be interacted w/ when standing in front of
        //Multiple Tile Bases + Obstacles that don't interfere w/ each other

        //Refactor SetColor into Switch Statement?
        //Refactor SetColor into SwitchColor? <---
    }

    public void SwitchColor()
    {
        //Box Collider + Input.GetKeyDown(KeyCode.E)
        if (Input.GetKeyDown(KeyCode.Mouse0))
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
                        Debug.Log($"{puzzleID} color is not assinged");

                        break;
                    }
            }
        }
    }

    //public void SetColor()
    //{
    //    if (isColor == "Blue")
    //    {
    //        SetToBlue();
    //    }
    //    else if (isColor == "Green")
    //    {
    //        SetToGreen();
    //    }
    //    else if (isColor == "Red")
    //    {
    //        SetToRed();
    //    }
    //    else if (isColor == "Yellow")
    //    {
    //        SetToYellow();
    //    }
    //    else
    //    {
    //        Debug.Log($"{puzzleID} is blank");
    //    }
    //}

    public void SetToBlue()
    {
        yellowTile.SetActive(false);

        blueTile.SetActive(true);
    }

    public void SetToGreen()
    {
        blueTile.SetActive(false);

        greenTile.SetActive(true);
    }

    public void SetToRed()
    {
        greenTile.SetActive(false);

        redTile.SetActive(true);
    }

    public void SetToYellow()
    {
        redTile.SetActive(false);

        yellowTile.SetActive(true);
    }

    public override void Solution()
    {
        //Insert Solution Logic
    }

    protected override void Update()
    {
        base.Update();

        SwitchColor();

        //SetColor();

        //if (!solved)
        //{
        //    Solution();
        //}
    }
}
