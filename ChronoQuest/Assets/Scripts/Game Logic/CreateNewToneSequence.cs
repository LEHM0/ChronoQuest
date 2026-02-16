using UnityEngine;

public class CreateNewToneSequence : MonoBehaviour
{
    public int toneNum;
    public bool canInteract = false;

    public GameObject soundToneController;
    public AudioClip soundTone;
    private SoundToneMatching stm;
    private AudioSource audioSource;

    void Start()
    {
        stm = soundToneController.GetComponent<SoundToneMatching>();
        audioSource = gameObject.GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(soundTone, 1);

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
