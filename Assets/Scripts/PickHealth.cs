using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHealth : MonoBehaviour
{

    public AudioSource HealedSound;
    void OnTriggerEnter(Collider other)
    {

        GlobalHealth.currentHealth += 15;
        gameObject.SetActive(false);
        HealedSound.Play();
    }
}
