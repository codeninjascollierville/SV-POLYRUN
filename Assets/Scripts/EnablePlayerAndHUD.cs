using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayerAndHUD : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject HUD, player;

    public static int health;

    void Start()
    {

    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            HUD.SetActive(false);
            player.SetActive(false);
        }
        else 
        {
            HUD.SetActive(true);
            player.SetActive(true);
        }
    }
}
