using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager instance;
    public Image fadeImage;
    public Color startColor;
    public Color endColor;
    public float duration;

    public bool isFading = false;

    private void Awake()
    {
        instance = this;
    }

    public void FadeIn()
    {
        StartCoroutine(BeginFade());
    }

    public void FadeOutToScene()
    {
        StartCoroutine(BeginFade());
    }

    private IEnumerator BeginFade()
    {
        isFading = true;
        float timer = 0;

        while(timer <= duration)
        {
            fadeImage.color = Color.Lerp(startColor, endColor, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        isFading = false;
    }

    // Start is called before the first frame update
    private void Start()
    {
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
