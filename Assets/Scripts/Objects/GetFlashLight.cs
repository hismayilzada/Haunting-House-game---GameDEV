using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFlashLight : MonoBehaviour
{
    public float distance;
    public GameObject flashlight;
    public GameObject actionKey;
    public GameObject activeCross;
    public GameObject getFlashText;
    public AudioSource sound;
    public bool flashTaken;

    void Start()
    {
        flashTaken = false;
    }

    void Update()
    {
        distance = PlayerRay.distanceFromTarget;
    }

    void OnMouseOver()
    {
        if (distance <= 1)
        {

            actionKey.SetActive(true);
            activeCross.SetActive(true);
        }
        else
        {

            actionKey.SetActive(false);
            activeCross.SetActive(false);
        }

        if (Input.GetButton("OpenDoor"))
        {
            if (distance <= 1)
            {
                flashTaken = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                actionKey.SetActive(false);
                activeCross.SetActive(false);
                sound.Play();
                getFlashText.SetActive(true);
                StartCoroutine(keyText());
                Destroy(flashlight, 1f);
            }
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        activeCross.SetActive(false);

    }

    IEnumerator keyText()
    {
        getFlashText.SetActive(true);
        yield return new WaitForSeconds(0.9f);
        getFlashText.SetActive(false);
    }
}
