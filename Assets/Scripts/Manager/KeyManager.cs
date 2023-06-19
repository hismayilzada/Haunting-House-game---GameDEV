using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public bool isKeyObtained;
    public GameObject key;
    public static int numberOfKey;

    void Start()
    {
        isKeyObtained = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "key")
        {
            isKeyObtained = true;
            numberOfKey++; 
            numberOfKey++;
            Destroy(key);
        }
    }

 
}
