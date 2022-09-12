using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAmmo : MonoBehaviour
{
    public GameObject DisplayAmmoBox;
    public AudioSource AmmoPickSound;
    void OnTriggerEnter(Collider other)
    {
        DisplayAmmoBox.SetActive(true);
        GlobalAmmo.ammoCount += 7;
        gameObject.SetActive(false);
        AmmoPickSound.Play();
    }
}
