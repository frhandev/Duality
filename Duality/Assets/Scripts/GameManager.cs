using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject dreamWorld;
    [SerializeField] GameObject realWorld;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource switchSFX;
    [SerializeField] AudioSource dieSFX;
    public bool inRealWorld;

    void Start()
    {
        inRealWorld = true;

    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            return;
        }
        if (inRealWorld)
        {
            dreamWorld.SetActive(false);
            realWorld.SetActive(true);
        }
        else
        {
            realWorld.SetActive(false);
            dreamWorld.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            WorldSwitch();
        }
    }

    void WorldSwitch()
    {
        inRealWorld = !inRealWorld;
        switchSFX.Play();
    }

    public void Died()
    {
        dieSFX.Play();
        Invoke("Die", 1f);
        animator.SetTrigger("Restart");
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevelInvoker()
    {
        Invoke("NextLevel", 1f);
        animator.SetTrigger("Restart");

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void StartGame()
    {
        Invoke("SGame", 1f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void SGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Youtube()
    {
        Application.OpenURL("https://www.youtube.com/@frhandev/");
    }
}
