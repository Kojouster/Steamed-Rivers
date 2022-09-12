using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HospitalTrig : MonoBehaviour
{
    public GameObject player;
    public GameObject PlayerSays;
    public GameObject marker;
     public AudioSource RoomMusic;
    public AudioSource BackMus;

    public AudioSource SayNote;

      void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        player.GetComponent<CharController_Motor>().enabled = false;
        BackMus.Stop();
        RoomMusic.Play();
        StartCoroutine(ScenePlayer());
    
       
    }
    IEnumerator ScenePlayer()
    {
        SayNote.Play();
        PlayerSays.GetComponent<Text>().text = "Looks like there is a note on the table ";
        yield return new WaitForSeconds(2.5f);
      
        PlayerSays.GetComponent<Text>().text = "";
        player.GetComponent<CharController_Motor>().enabled = true;

        marker.SetActive(true);
      
    }
}
