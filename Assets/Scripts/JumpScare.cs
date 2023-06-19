using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{

    public GameObject tv;
    public AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            tv.SetActive(true);
            sound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(tv, 2.5f);
        return;
    }

}

