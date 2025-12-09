using UnityEngine;

public class SoundToneMatching : Puzzle
{
    public int[] toneSequence;
    public int toneNum; //Replace when finalizing
    public bool canInteract = false;
    //public audio? toneOne

    void Start()
    {
        //
    }

    protected override void Update()
    {
        base.Update();

        PlaySequence();
    }

    public override void Solution()
    {
        //
        CompareSequence();
    }

    public void PlaySequence()
    {
        //
        if (canInteract && Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach (int i in toneSequence)
            {
                Debug.Log($"Playing tone in sequence: {i}");
                //Will play each tone audio in sequence
            }
        }
    }

    public void PlayTone()
    {
        //
        Debug.Log($"Playing tone: {toneNum}");
        //Add toneNum to empty array
    }

    /*public void CreateSequence()
     * {Pressing the buttons in PlayTone() adds that toneNum to an array[], then compares that array to the toneSequence; if they are equal, set solved to true}
     */
    public void CreateSequence()
    {
        //
    }

    public void CompareSequence()
    {
        //
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
