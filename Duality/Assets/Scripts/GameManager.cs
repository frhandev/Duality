using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject dreamWorld;
    [SerializeField] GameObject realWorld;
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
}
