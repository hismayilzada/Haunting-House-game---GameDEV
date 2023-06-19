using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light flight;
    public bool drainOverTime; //ışığın gücü
    public float maxBrightness;
    public float minBrightness;
    public float drainRate;
    public AudioSource sound;
    GetFlashLight flash;

    void Start()
    {
        flight = GetComponent<Light>();
        flash = FindObjectOfType<GetFlashLight>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && flash.flashTaken==true) //Input.GetButton("Flash")
        {
            flight.enabled = !flight.enabled; //kapalıysa aç, açıksa kapat
            sound.Play();
        }
        if (drainOverTime == true && flight.enabled == true && flash.flashTaken == true) //pil sistemi kullanılıyorsa
        {
            flight.intensity = Mathf.Clamp(flight.intensity, minBrightness, maxBrightness);
            if (flight.intensity > minBrightness) //pilin ömrü varsa
            {
                flight.intensity -= Time.deltaTime * (drainRate / 1000); //pil azalacak
            }
        }
        else if(drainOverTime == true && flight.enabled == false && flash.flashTaken == true) //kapalıyken, şarj olsun
        {
            if (flight.intensity < maxBrightness) //pilin ömrü varsa
            {
                flight.intensity += Time.deltaTime * (drainRate / 1000); //pil azalacak
            }
        }
    }
}
