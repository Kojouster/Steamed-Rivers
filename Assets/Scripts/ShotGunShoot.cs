using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunShoot : MonoBehaviour
{
    public GameObject ShotGun;
    public GameObject Flash;
    public GameObject Flash2;
    public float targetDistance;
    public int DamageAmount = 15;
    public AudioSource shootSound;
    public bool isFiring = false;
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && GlobalAmmo.ShotgunAmmoCount >= 1 && Pistol.usingPistol == false)
        {
            if (isFiring == false)
            {
                GlobalAmmo.ShotgunAmmoCount -= 1;
                StartCoroutine(FiringShotGun());
            }
        
        }
    }

    IEnumerator FiringShotGun()
    {
        RaycastHit shot;
        isFiring = true;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            shot.transform.SendMessage("ZoombieDamage",DamageAmount,SendMessageOptions.DontRequireReceiver);
        }
        shootSound.Play();
        ShotGun.GetComponent<Animation>().Play("ShotGunAnim");
        Flash.SetActive(true);
        Flash.GetComponent<Animation>().Play("GunShotAnim");
        Flash2.SetActive(true);
        Flash2.GetComponent<Animation>().Play("GunShotAnim");

        yield return new WaitForSeconds(0.5f);
        isFiring = false;
    }
}
