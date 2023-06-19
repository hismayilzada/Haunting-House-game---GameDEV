using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVoice : MonoBehaviour
{
    public GameObject doorCollider;
    public AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(doorCollider, 3f);
    }
}
