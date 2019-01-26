using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAudio : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] private AudioClip[] clips;

    private void Start()
    {
        source = this.GetComponent<AudioSource>();
        source.clip = clips[Random.Range(0, clips.Length)];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 2)
        {
            source.Play();

        }
    }
}
