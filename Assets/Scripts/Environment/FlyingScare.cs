using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingScare : MonoBehaviour
{
    public GameObject mugObject;
    public GameObject sphere;

    public AudioSource MugSound;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        sphere.SetActive(true);
        StartCoroutine(DeactivateSphere());
    }

    IEnumerator DeactivateSphere()
    {
        yield return new WaitForSeconds(1);
        sphere.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        MugSound.Play();
    }
}
