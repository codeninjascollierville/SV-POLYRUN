using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject beatDetection, SpawnPoint1, SpawnPoint2, SpawnPoint3, SpawnPoint4;
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                audioSource.volume = 0.05f;
                beatDetection.GetComponent<BeatDetection>().enabled = false;
                SpawnPoint1.SetActive(false);
                SpawnPoint2.SetActive(false);
                SpawnPoint3.SetActive(false);
                SpawnPoint4.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                audioSource.volume = 0.26f;
                beatDetection.GetComponent<BeatDetection>().enabled = true;
                SpawnPoint1.SetActive(true);
                SpawnPoint2.SetActive(true);
                SpawnPoint3.SetActive(true);
                SpawnPoint4.SetActive(true);
            }
        }
    }
}
