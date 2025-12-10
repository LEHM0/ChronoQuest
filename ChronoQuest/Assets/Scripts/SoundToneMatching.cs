using System.Linq;
using UnityEngine;

public class SoundToneMatching : Puzzle
{
    public int[] toneSequence;
    public int[] newSequence;

    public int indexValue = 0;

    void Start()
    {
        //
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Solution()
    {
        //
        if (toneSequence.SequenceEqual(newSequence))
        {
            solved = true;

            indexValue = 0;

            Debug.Log($"{puzzleID} solved!");
        }

        else if (indexValue == 4 &&  !toneSequence.SequenceEqual(newSequence))
        {
            ResetSequence();
        }
    }

    public void ResetSequence()
    {
        //Play error noise
        System.Array.Clear(newSequence, 0, newSequence.Length);

        indexValue = 0;

        Debug.Log($"{puzzleID} reset");
    }
}
