using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject pistol;
    public GameObject Flash;
    public AudioSource shotSound;
    public float targetDistance;
    public int DamageAmount = 5;

    public bool isFiring = false;
    public static bool usingPistol = true;
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && GlobalAmmo.ammoCount>=1 && usingPistol==true)
        {
          
            if (isFiring == false)
            {
                GlobalAmmo.ammoCount -= 1;
            StartCoroutine(FiringPistol());
            }
        
        }
    }

    IEnumerator FiringPistol()
    {
        RaycastHit shot;
        isFiring = true;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            shot.transform.SendMessage("ZoombieDamage",DamageAmount,SendMessageOptions.DontRequireReceiver);
        }
        pistol.GetComponent<Animation>().Play("PistolAnim");
        Flash.SetActive(true);

        Flash.GetComponent<Animation>().Play("GunShotAnim");
        shotSound.Play();
        yield return new WaitForSeconds(0.5f);
        isFiring = false;
    }
}
