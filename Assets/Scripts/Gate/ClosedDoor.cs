using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour
{
    public float distance;
    public GameObject doorAnim;
    public GameObject actionKey;
    public GameObject getClosedText;
    public GameObject actionText;
    public AudioSource doorSound;
    public AudioSource lockedSound;
    GetKey key;

    void Start()
    {
        key = FindObjectOfType<GetKey>();
    }

    void Update()
    {
        distance = PlayerRay.distanceFromTarget;
    }

    void OnMouseOver()
    {
        if (distance <= 2)
        {
            if ((key.keyTaken == false))
            {
                actionText.SetActive(true);
            }
            actionKey.SetActive(true);
        }
        else
        {
            actionText.SetActive(false);
            actionKey.SetActive(false);
        }

        if (Input.GetButton("OpenDoor") && (key.keyTaken==true))
        {
            if (distance <= 1)
            {
                actionText.SetActive(false);
                actionKey.SetActive(false);
                doorAnim.GetComponent<Animation>().Play("DoorOpenClose");
                doorSound.Play();
            }
        }
        else if (Input.GetButton("OpenDoor") && (key.keyTaken == false))
        {
            StartCoroutine(keyText());
            lockedSound.Play();
        }
    }

    void OnMouseExit()
    {
        actionText.SetActive(false);
        actionKey.SetActive(false);
    }

    IEnumerator keyText()
    {
        getClosedText.SetActive(true);
        yield return new WaitForSeconds(3f);
        getClosedText.SetActive(false);
    }
}
