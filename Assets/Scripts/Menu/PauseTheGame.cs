using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTheGame : MonoBehaviour
{
    public bool gamePaused=false;
    public GameObject pauseMenu;
    public GameObject Restart;
    public GameObject Menu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (gamePaused == false)
            {
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
               
                pauseMenu.SetActive(true);
                Restart.SetActive(true);
               Menu.SetActive(true);
            }
            else 
            
            {
                pauseMenu.SetActive(false);

               
                gamePaused = false;
                Time.timeScale = 1;
            }
        
        }
    }
}
