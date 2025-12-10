using UnityEngine;

public class PlayToneSequence : MonoBehaviour
{
    public bool canInteract = false;

    public GameObject soundToneController;
    private SoundToneMatching soundToneMatching;

    void Start()
    {
        soundToneMatching = soundToneController.GetComponent<SoundToneMatching>();
    }

    void Update()
    {
        PlaySequence();
    }

    public void PlaySequence()
    {
        //
        if (canInteract && Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach (int i in soundToneMatching.toneSequence)
            {
                Debug.Log($"Playing tone in sequence: {i}");
                //Will play each tone audio in sequence
                //Maybe w/ a Coroutine?
            }
        }
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
