using UnityEngine;

public class CreateNewToneSequence : MonoBehaviour
{
    public int toneNum;
    public bool canInteract = false;

    public GameObject soundToneController;
    private SoundToneMatching soundToneMatching;

    void Start()
    {
        soundToneMatching = soundToneController.GetComponent<SoundToneMatching>();
    }

    void Update()
    {
        PlayTone();
    }

    public void PlayTone()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log($"Playing tone: {toneNum}");
            //Play the individual tone audio

            CreateSequence();
        }
    }

    public void CreateSequence()
    {
        soundToneMatching.newSequence.SetValue(toneNum, soundToneMatching.indexValue);
        soundToneMatching.indexValue++;
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
