using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoots : MonoBehaviour
{
    [SerializeField]
    [Range(-3, 3)]
    public float MinPitch = 1.0f;
    [SerializeField]
    [Range(-3, 3)]
    public float MaxPitch = 1.0f;
    private AudioSource[] myAudioSource;
    private int nextStep;


    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponents<AudioSource>();
        nextStep = 0;
    }

    public void PlayWalkSound()
    {
        if(myAudioSource != null && myAudioSource.Length > 0)
        {
            if(myAudioSource.Length <= nextStep)
            {
                nextStep = 0;
            }
            myAudioSource[nextStep].pitch = Random.Range(MinPitch, MaxPitch);
            myAudioSource[nextStep].Play();
            nextStep++;
        }
    }
}
