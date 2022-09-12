using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickUp: MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;
    public GameObject Crosshair;

    public GameObject Key;



    public GameObject InventoryDisplay;
    public GameObject keyImg;
    public GameObject InventoryAmount;

    public AudioSource keyPickedUp;
    void Update()
    {
        distance = PlayerCast.DistanceFromTarget;
    }
    private void OnMouseOver()
    {
        if (distance <= 2)
        {
            Crosshair.SetActive(true);
            TextAction.GetComponent<Text>().text = "Pick the key";
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
                Key.SetActive(false);
                Inventory.firstDoorKey = true;
                keyPickedUp.Play();
                if (Inventory.firstDoorKey == true)
                {
                    InventoryDisplay.SetActive(true);
                    keyImg.SetActive(true);
                    InventoryAmount.SetActive(true);

                }
               
            }



        }



    }
    private void OnMouseExit()
    {
        Crosshair.SetActive(false);
        DisplayAction.SetActive(false);
        TextAction.SetActive(false);
    }

   
}
