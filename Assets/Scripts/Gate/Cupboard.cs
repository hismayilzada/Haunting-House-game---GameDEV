using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard : MonoBehaviour
{

    public float distance;
    public GameObject actionKey;
    public GameObject actionText;
    public AudioSource doorSound;

    void Update()
    {
        distance = PlayerRay.distanceFromTarget;
    }

    void OnMouseOver()
    {
        if (distance <= 2)
        {
            actionText.SetActive(true);
            actionKey.SetActive(true);
        }
        else
        {
            actionText.SetActive(false);
            actionKey.SetActive(false);
        }

        if (Input.GetButton("OpenDoor"))
        {
            if (distance <= 2)
            {

                actionText.SetActive(false);
                doorSound.Play();
            }
        }
    }

    void OnMouseExit()
    {
        actionText.SetActive(false);
        actionKey.SetActive(false);
    }
}



