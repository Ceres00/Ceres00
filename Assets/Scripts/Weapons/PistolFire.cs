using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolFire : MonoBehaviour
{
    public GameObject M9;
    public bool isFiring = false;
    public GameObject muzzleFlash;
    public AudioSource pistolShot;
    public float toTarget;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (isFiring == false)
            {
                StartCoroutine(FireThePistol());
            }
        }
    }
    IEnumerator FireThePistol()
    {
        isFiring = true;
        toTarget = PlayerCasting.distanceFromTarget;
        M9.GetComponent<Animator>().Play("Fire_Pistol");
        pistolShot.Play();
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        M9.GetComponent<Animator>().Play("PistolFire");
        isFiring = false;
    }
}
