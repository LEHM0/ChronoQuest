using System.Linq;
using UnityEngine;

public class SoundToneMatching : Puzzle
{
    //The solution and input arrays
    public int[] toneSequence;
    public int[] newSequence;

    //Int controlling where a new input is added into the array
    public int indexValue = 0;

    protected override void Update()
    {
        base.Update();
    }

    public override void Solution()
    {
        //Compares the input array to the solution array to see if all the values are equal to each other
        if (toneSequence.SequenceEqual(newSequence))
        {
            solved = true;

            indexValue = 0;

            Debug.Log($"{puzzleID} solved!");
        }

        //Checks if the player has inputted the solution incorrectly before reseting the puzzle
        else if (indexValue == 4 &&  !toneSequence.SequenceEqual(newSequence))
        {
            ResetSequence();
        }
    }

    public void ResetSequence()
    {
        //Clears the input array and resets the array index
        //Play error noise
        System.Array.Clear(newSequence, 0, newSequence.Length);

        indexValue = 0;

        Debug.Log($"{puzzleID} reset");
    }
}
