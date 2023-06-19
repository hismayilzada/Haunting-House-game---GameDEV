using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    public float distance;
    public GameObject key;
    public GameObject actionKey;
    public GameObject activeCross;
    public GameObject getKeyText;
    public AudioSource sound;
    public bool keyTaken;

    void Start()
    {
        keyTaken = false;
    }

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
                keyTaken = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                actionKey.SetActive(false);
                activeCross.SetActive(false);
                sound.Play();
                getKeyText.SetActive(true);
                StartCoroutine(keyText());
                Destroy(key,1f);
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
        getKeyText.SetActive(true);
        yield return new WaitForSeconds(0.9f);
        getKeyText.SetActive(false);
    }
    
}
