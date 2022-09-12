using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class DoorLockedHospital : MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;


    public GameObject Crosshair;
    public AudioSource LockedDoorSound;
    public GameObject BunkerDoor;
    public AudioSource doorUnlocked;
    public AudioSource BunkerUnlockeSound;

  
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
        if (SteppingPuzzleGame.gamecomplete==false)

        {
            LockedDoorSound.Play();
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
          
           
        }
        else 
        
        {
         
           
            yield return new WaitForSeconds(1.5f);
            BunkerDoor.GetComponent<Animator>().Play("BunkerDoorAnim");
            BunkerUnlockeSound.Play();
         
            yield return new WaitForSeconds(1.2f);
            this.GetComponent<BoxCollider>().enabled = false;
        }
       
       
    }
}
