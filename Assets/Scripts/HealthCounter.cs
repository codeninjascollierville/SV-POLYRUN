using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthCounter : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public static int healthValue = 0;
    public AudioSource audioSource;
    public Text health;
    public Color loadToColor = Color.black;

    public string sceneNameToLoad;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Text>();
        healthValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "" + healthValue;
        timeElapsed += Time.deltaTime;

        if (healthValue <= 0)
        {
            audioSource.Stop();
            gameOverCanvas.SetActive(true);
        }
    }
}
