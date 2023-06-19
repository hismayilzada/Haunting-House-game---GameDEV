using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPistol : MonoBehaviour
{
    public float distance;
    public GameObject pistol;
    public GameObject realPistol;
    public GameObject actionKey;
    public GameObject getPistolText;
    public GameObject activeCross;
    public AudioSource sound;
    public GameObject AmmoPanel;


    void Update()
    {
        distance = PlayerRay.distanceFromTarget;
    }

    void OnMouseOver()
    {
        if (distance <= 2)
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
            if (distance <= 2)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                realPistol.SetActive(true);
                AmmoPanel.SetActive(true); ;
                actionKey.SetActive(false);
                activeCross.SetActive(false);
                sound.Play();
                StartCoroutine(keyText());
                Destroy(pistol, 1);
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
        getPistolText.SetActive(true);
        yield return new WaitForSeconds(0.9f);
        getPistolText.SetActive(false);
    }
}
