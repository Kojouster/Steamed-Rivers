using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorLocked : MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;


    public GameObject Crosshair;
    public AudioSource LockedDoorSound;
    public GameObject HingeDoor;
    public AudioSource doorUnlocked;
    public AudioSource Creek;

    public GameObject KeyImg;
    public GameObject TextCount;

    void Update()
    {
        distance = PlayerCast.DistanceFromTarget;
    }
    private void OnMouseOver()
    {
        if (distance <= 2)
        {
            Crosshair.SetActive(true);
            TextAction.GetComponent<Text>().text = "Open the door";
            DisplayAction.SetActive(true);
            TextAction.SetActive(true);

        }
        if (Input.GetButtonDown("Action"))

        {
            if (distance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                DisplayAction.SetActive(false);
                TextAction.SetActive(false);
                Crosshair.SetActive(false);
                StartCoroutine(DoorReset());

            }



        }



    }
    private void OnMouseExit()
    {
        Crosshair.SetActive(false);
        DisplayAction.SetActive(false);
        TextAction.SetActive(false);
    }

    IEnumerator DoorReset()
    {
        if (Inventory.firstDoorKey == false)

        {
            LockedDoorSound.Play();
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;


        }
        else 
        
        {
            KeyImg.SetActive(false);
            TextCount.SetActive(false);
            doorUnlocked.Play();
            yield return new WaitForSeconds(2.5f);
            HingeDoor.GetComponent<Animator>().Play("DoorKeyOpenAnim");
            Creek.Play();
         
            yield return new WaitForSeconds(1.2f);
            this.GetComponent<BoxCollider>().enabled = false;
        }
       
       
    }
}
