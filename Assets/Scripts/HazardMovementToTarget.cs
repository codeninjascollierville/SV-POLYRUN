using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardMovementToTarget : MonoBehaviour
{
    public float speed = 10.0f;
    public float timeLeft;

    Rigidbody2D rb;
    Player target;
    Vector2 moveDirection;

    public GameObject sparks;

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    // Update is called once per frame
    void Update()
    {
        
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
