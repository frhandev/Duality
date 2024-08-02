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

    }

    void Update()
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
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            WorldSwitch();
        }
    }

    void WorldSwitch()
    {
        inRealWorld = !inRealWorld;
    }

    public void Died()
    {
        Invoke("Die", 1f);
        animator.SetTrigger("Restart");
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
