using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAmmo : MonoBehaviour
{
    public float distance;
    public GameObject actionKey;
    public GameObject pistol;
    public GameObject activeCross;
    public AudioSource AmmoSound;
    public GameObject AmmoBox;
    public GameObject getAmmoText;
    public GameObject capacityFull;



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
                Pistol pistolScript = pistol.GetComponent<Pistol>();
                pistolScript.carriedAmmo += 8;
                if (pistolScript.carriedAmmo > 40)
                {
                    pistolScript.carriedAmmo = 40;
                    StartCoroutine(ammoFullText());
                    return;
                }
                pistolScript.updateAmmoUI();
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
               
                actionKey.SetActive(false);
                activeCross.SetActive(false);
                AmmoSound.Play();
                StartCoroutine(keyText());
                Destroy(AmmoBox, 1);
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
        getAmmoText.SetActive(true);
        yield return new WaitForSeconds(0.9f);
        getAmmoText.SetActive(false);
    }

    IEnumerator ammoFullText()
    {
        capacityFull.SetActive(true);
        yield return new WaitForSeconds(0.9f);
        capacityFull.SetActive(false);
    }
}

