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
     public bool inRealWorld;

    void Start()
    {
        inRealWorld = true;

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
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            WorldSwitch();
        }
    }

    void WorldSwitch()
    {
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
        inRealWorld = !inRealWorld;
    }

    public void Died()
    {
        animator.SetTrigger("Restart");
        Invoke("Die", 1f);
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
