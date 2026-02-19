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
    public List<AudioClip> sequenceList;

    void Start()
    {
        stm = soundToneController.GetComponent<SoundToneMatching>();
        audioSource = gameObject.GetComponent<AudioSource>();

        GenerateSequence();
    }

    void Update()
    {
        PlaySequence();
    }

    public void GenerateSequence()
    {
        //sequenceList.Add(soundToneArray[i]); //Fix: Only adds two slots to the list
    }

    public void PlaySequence()
    {
        //When pressed, a unique series of sound tones is played
        if (canInteract && Input.GetKeyDown(KeyCode.Mouse0) && !stm.solved)
        {
            foreach (int i in stm.toneSequence)
            {
                Debug.Log($"Playing tone in sequence: {i}");
                StartCoroutine(PlaySequenceCoroutine());
            }
        }
    }

    IEnumerator PlaySequenceCoroutine()
    {
        //audioSource.PlayOneShot(soundName, 1);
        yield return null;

        for (int i = 0; i < soundToneArray.Length; i++)
        {
            audioSource.clip = soundToneArray[i];
            audioSource.Play();

            while (audioSource.isPlaying)
            {
                yield return null;
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
