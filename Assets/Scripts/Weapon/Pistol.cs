using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    RaycastHit hit;

    public ParticleSystem flash;
    AudioSource pistolAS;
    public AudioClip shootAC;
    Animator anim;

    //RaycastHit hit; //oyuncudan çıkan ışın demeti

    [SerializeField]
    public int currentAmmo = 12; //şarjördeki mermi
    public int maxAmmo = 12;
    public int carriedAmmo = 60;

    public AudioClip emptyFir;
    public AudioClip reloadSound;

    bool isReloading;

    [SerializeField]
    float rateOfFire; // ne kadar sürede ateş edebiliriz
    float nextFire=0;

    [SerializeField]
    float weaponRange; //merminin gittiği uzaklık

    public float damage = 20f;

    public Transform shootPoint; //rayın çıkacağı nokta

    EnemyHealth enemy;

    public Text CurrentAmmo;
    public Text CarriedAmmo;

    public GameObject zeroAmmoText;
    public GameObject bloodEffect;

    void Start()
    {
        updateAmmoUI();
        anim = GetComponent<Animator>();
        pistolAS = GetComponent<AudioSource>();
        flash.Stop();
        //enemy = FindObjectOfType<EnemyHealth>();
    }

    
    void Update()
    {
        if (Input.GetButton("Fire1") && currentAmmo > 0)
        {
            shoot();
        }
        else if (Input.GetButton("Fire1") && currentAmmo <= 0 && !isReloading)
        {
            emptyFire();
        }
        else if (Input.GetKeyDown(KeyCode.R) && currentAmmo <=maxAmmo && !isReloading) //şarjör değiştirme
        {
            isReloading = true;
            Reload();
        }
    }

    void shoot() //mermiyi aralıklı olarak atsın
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;
            anim.SetTrigger("Shoot");
            currentAmmo--;
            shootRay();
            updateAmmoUI();


        }
    }

    void shootRay()
    {
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weaponRange)) //bizden çıkan ray bir yere vurursa gel burayı yap
        {
            if (hit.transform.tag == "Enemy")
            {
                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
                Instantiate(bloodEffect, hit.point,transform.rotation);
                enemy.ReduceHealth(damage);
            }
            else
            {
                Debug.Log("Something else.");
            }
        }
    }

    void Reload()
    {
        if (carriedAmmo <= 0)
        {
            StartCoroutine(keyText());
            isReloading = false;
        }
        else
        {
            anim.SetTrigger("Reload");
            pistolAS.PlayOneShot(reloadSound);
            StartCoroutine(ReloadCountDown(2f));
        }
    }

    public void updateAmmoUI()
    {
        CurrentAmmo.text = currentAmmo.ToString();
        CarriedAmmo.text = carriedAmmo.ToString();
    }

    void emptyFire() //kuru atış
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;
            pistolAS.PlayOneShot(emptyFir);
            anim.SetTrigger("Empty");
        }
    }

    IEnumerator pistolEffect()
    {
        flash.Play();
        pistolAS.PlayOneShot(shootAC);
        yield return new WaitForEndOfFrame();
        flash.Stop();
    }

    IEnumerator keyText()
    {
        zeroAmmoText.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        zeroAmmoText.SetActive(false);
    }

    IEnumerator ReloadCountDown(float timer)
    {
        while (timer > 0f)
        {
            //isReloading = true;
            timer -= Time.deltaTime; //işlem için geçen süre
            yield return null;
        }

        if (timer <= 0f)
        {
            isReloading = false;
            int bulletNeeded = maxAmmo - currentAmmo;  //şarjörü tamamlamak için gereken mermi
            int bulletToDeduct = (carriedAmmo >= bulletNeeded) ? bulletNeeded : carriedAmmo; //düşen mermi sayısı
            carriedAmmo -= bulletToDeduct;
            currentAmmo += bulletToDeduct;
            updateAmmoUI();
        }
    }
}
