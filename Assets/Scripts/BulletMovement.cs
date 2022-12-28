using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float timeLeft;
    public GameObject bulletSpark;

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
        
        if (collision.gameObject.tag == "Triangle")
        {
            ScoreIncreasePerSecond.scoreValue += 10;
            Destroy(this.gameObject);
            Instantiate(bulletSpark, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "Pentagon")
        {
            ScoreIncreasePerSecond.scoreValue += 5;
            Destroy(this.gameObject);
            Instantiate(bulletSpark, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "HexagonTurrent" || collision.gameObject.tag == "Hexagon")
        {
            ScoreIncreasePerSecond.scoreValue += 30;
            Destroy(this.gameObject);
            Instantiate(bulletSpark, transform.position, Quaternion.identity);
        }
    }
}
