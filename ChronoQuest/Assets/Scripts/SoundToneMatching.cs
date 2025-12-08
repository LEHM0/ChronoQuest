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
        //PlayTone();
    }

    public override void Solution()
    {
        //
    }

    public void PlaySequence()
    {
        //
        if (canInteract && Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach (int i in toneSequence)
            {
                Debug.Log($"Playing tone in sequence: {i}");
            }
        }
    }

    public void PlayTone()
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
