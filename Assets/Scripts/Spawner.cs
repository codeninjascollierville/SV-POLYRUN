using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("ChallengeObj Game Object")]
    public GameObject challengeObject;
    [Header("Default spawn delay time")]
    public float spawnDelay = 1f;
    [Header("Default spawn time")]
    public float spawnTime = 2f;
    [Header("Deafault Speed")]
    public float speed;
    // Start is called before the first frame update
    void Start()
    { 
        
        InvokeRepeating("InstintiateObjects", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(4.03f, -0.16f, 0);
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void InstintiateObjects()
    {
        Instantiate(challengeObject, transform.position, transform.rotation);
    }
}
