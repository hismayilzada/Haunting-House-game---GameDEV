using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetOpen : MonoBehaviour
{
    public float distance;
    public GameObject cabinetleft;
    public GameObject cabinetright;
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
                actionKey.SetActive(false);
                cabinetleft.GetComponent<Animation>().Play("Left");
                cabinetright.GetComponent<Animation>().Play("RightCabinet");
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


