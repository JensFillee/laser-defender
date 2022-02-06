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
