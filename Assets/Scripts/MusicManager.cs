using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] MusicCollection;

    private AudioSource _audioSource;

    public static MusicManager Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(int trackIndex)
    {
        _audioSource.clip = MusicCollection[trackIndex];
        _audioSource.loop = true;
        _audioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();
        PlayMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
