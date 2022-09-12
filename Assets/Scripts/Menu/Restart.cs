using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject FadeOut;
    public AudioSource ButtonClick;
    public void RestartButton()
    {
        StartCoroutine(RestartGame());

    }

    IEnumerator RestartGame()
    {
        Time.timeScale = 1;
        FadeOut.SetActive(true);
        ButtonClick.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
        GlobalAmmo.ammoCount = 0;
        GlobalHealth.currentHealth = 20;
    }
}
