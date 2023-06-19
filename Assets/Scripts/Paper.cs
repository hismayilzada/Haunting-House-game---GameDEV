using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public GameObject paper;
    public GameObject paper2;
    public AudioSource sound;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            paper2.SetActive(false);
            paper.SetActive(true);
            sound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        paper.SetActive(false);
        paper2.SetActive(true);
    }
}
