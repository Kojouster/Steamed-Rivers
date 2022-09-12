using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOtherVase : MonoBehaviour
{
    public GameObject fakeVase;
    public GameObject broakenVase;
    public GameObject sphere;
    public AudioSource BreakSound;

    void ZoombieDamage(int DamageAmount)
    {


        StartCoroutine(BrakeVase2());
    }
    IEnumerator BrakeVase2()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        BreakSound.Play();
        fakeVase.SetActive(false);
        broakenVase.SetActive(true);
       
       
       yield return new WaitForSeconds(0.05f);
        sphere.SetActive(true);

        yield return new WaitForSeconds(0.05f);
        sphere.SetActive(false);



    }
}
