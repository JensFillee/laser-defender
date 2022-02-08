using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f; // audio = between 0 & 1 (= full volume)


    [Header("Hit")]
    [SerializeField] AudioClip hitClip;
    [SerializeField] [Range(0f, 1f)] float hitVolume = 1f; // audio = between 0 & 1 (= full volume)

    // Way 2: static variable
    // Don't have to use FindObjectOfType<AudioPlayer>() in Awake() of other components anymore
    // Instead: just audioPlayer.GetInstance().PlayShootingClip()
    static AudioPlayer instance;

    // Make instance globally accessible (AVOID WHEN POSSIBLE)
    // WORSE BECAUSE: tracking down singleton problems = a nightmare

    // public AudioPlayer GetInstance()
    // {
    //     return instance;
    // }


    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        // Way 1: instanceCount
        // // FindObjectsOfType(GetType()): will find all objects with the type of this class (= AudioPlayer)
        // // = same as FindObjectsOfType<AudioPlayer>(), but more generic
        // int instanceCount = FindObjectsOfType(GetType()).Length;

        // // If there is already an AudioPlayer -> destroy this
        // if (instanceCount > 1)
        // {
        //     // SetActive(false) -> prevent other objects from trying to use it right before it gets destroyed (very small chance)
        //     gameObject.SetActive(false);
        //     Destroy(gameObject);
        // }
        // // If this is the first AudioPlayer -> make this a singleton
        // else 
        // {
        //     DontDestroyOnLoad(gameObject);
        // }


        // Way 2: static variable
        // If there is already an instance (static variable) -> destroy this
        if (instance != null)
        {
            // SetActive(false) -> prevent other objects from trying to use it right before it gets destroyed (very small chance)
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        // If this is the first AudioPlayer -> make this the instance (static variable)
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayHitSound()
    {
        PlayClip(hitClip, hitVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            // Creates a "One shot audio" object at runtime that has an AudioSource-component (containing the audioclip)
            // Gets listened to by an Audio Listener (Main camera has an Audio Listener => play it there)
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
