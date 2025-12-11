using UnityEngine;

public class CreateNewToneSequence : MonoBehaviour
{
    public int toneNum;
    public bool canInteract = false;

    public GameObject soundToneController;
    private SoundToneMatching stm;

    void Start()
    {
        stm = soundToneController.GetComponent<SoundToneMatching>();
    }

    void Update()
    {
        PlayTone();
    }

    public void PlayTone()
    {
        //Plays an audio tone once the button has been pressed
        if (canInteract && Input.GetKeyDown(KeyCode.Mouse0) && !stm.solved)
        {
            Debug.Log($"Playing tone: {toneNum}");
            //Play the individual tone audio

            CreateSequence();
        }
    }

    public void CreateSequence()
    {
        //Adds the tone number to the next index of an array
        stm.newSequence.SetValue(toneNum, stm.indexValue);
        stm.indexValue++;
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
