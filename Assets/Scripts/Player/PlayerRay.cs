using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
  
    public static float distanceFromTarget;
    public float toTarget;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; //playerdan çıkan ışın demeti
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit)) 
            //ışın gönderiyoruz ve nesneye çarparsa(ışın nerden çıkar, nereye gider)
        {
            toTarget = hit.distance;
            distanceFromTarget = toTarget;
        }
    }
}
