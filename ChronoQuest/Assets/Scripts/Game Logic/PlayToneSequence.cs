using System.Collections;
using UnityEngine;

public class PlayToneSequence : MonoBehaviour
{
    public bool canInteract = false;

    public GameObject soundToneController;
    private SoundToneMatching stm;

    void Start()
    {
        stm = soundToneController.GetComponent<SoundToneMatching>();
    }

    void Update()
    {
        PlaySequence();
    }

    public void PlaySequence()
    {
        //When pressed, a unique series of sound tones is played
        if (canInteract && Input.GetKeyDown(KeyCode.Mouse0) && !stm.solved)
        {
            foreach (int i in stm.toneSequence)
            {
                Debug.Log($"Playing tone in sequence: {i}");
                //StartCoroutine(CoroutineName());
            }
        }
    }

    //Use a forloop to play each audio clip? WaitForSeconds?
    IEnumerator CoroutineName()
    {
        //audioSource.PlayOneShot(soundName, 1);
        yield return null;
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
