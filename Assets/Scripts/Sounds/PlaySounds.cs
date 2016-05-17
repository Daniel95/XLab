using UnityEngine;
using System.Collections;

public class PlaySounds : MonoBehaviour {

    [SerializeField]
    private AudioClip startConnectionSound;

    [SerializeField]
    private AudioClip endConnectionSound;

    private AudioSource audioSource;

    private MoveTowards moveTowards;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
        moveTowards = GetComponent<MoveTowards>();
    }

    void OnEnable()
    {
        moveTowards.FinishedRotating += PlayStartConnectionSound;
        moveTowards.FinishedConnection += PlayEndConnectionSound;
    }

    void OnDisable()
    {
        moveTowards.FinishedRotating -= PlayStartConnectionSound;
        moveTowards.FinishedConnection += PlayEndConnectionSound;
    }

    void PlayStartConnectionSound() {
        //assing the sound in the AudioSource.
        audioSource.clip = startConnectionSound;

        //play the assigned sound.
        audioSource.Play();
    }

    void PlayEndConnectionSound()
    {
        //assing the sound in the AudioSource.
        audioSource.clip = endConnectionSound;

        //play the assigned sound.
        audioSource.Play();
    }
}
