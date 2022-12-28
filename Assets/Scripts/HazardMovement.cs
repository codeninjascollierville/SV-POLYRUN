using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float timeLeft;
    public GameObject sparks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            HealthCounter.healthValue -= 1;
            Destroy(this.gameObject);
            Instantiate(sparks, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Instantiate(sparks, transform.position, Quaternion.identity);
        }
    }
}
