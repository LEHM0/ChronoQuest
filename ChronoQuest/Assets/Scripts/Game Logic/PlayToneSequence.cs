using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayToneSequence : MonoBehaviour
{
    public bool canInteract = false;

    public GameObject soundToneController;
    private SoundToneMatching stm;
    private AudioSource audioSource;

    public AudioClip[] soundToneArray = new AudioClip[4];

    void Start()
    {
        stm = soundToneController.GetComponent<SoundToneMatching>();
        audioSource = gameObject.GetComponent<AudioSource>();
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
            StartCoroutine(PlaySequenceCoroutine());
        }
    }

    IEnumerator PlaySequenceCoroutine()
    {
        foreach (int i in stm.toneSequence)
        {
            audioSource.PlayOneShot(soundToneArray[i]);
            Debug.Log($"Playing tone in sequence: {i}");

            yield return new WaitForSeconds(soundToneArray[i].length + 0.1f);
        }

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
