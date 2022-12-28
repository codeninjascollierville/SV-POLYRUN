using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float moveSpeed = 5f;
    public GameObject dashEffect;
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    //[SerializeField]
    //public float jumpforce = 500f;

    void Start()
    {
        //Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        //HoppyMovement();
        DashMovement();
        Clamp();
    }

    /*void HoppyMovement()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpforce);
            Instantiate(dashEffect, transform.position, Quaternion.identity);
        }
    }*/

    void DashMovement()
    {
        if(direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
                direction = 2;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
                direction = 3;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                direction = 4;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
        } else {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            } else {
                dashTime -= Time.deltaTime;

                if(direction == 1) {
                    rb.velocity = Vector2.left * dashSpeed;
                } else if(direction == 2) {
                    rb.velocity = Vector2.right * dashSpeed;
                } else if(direction == 3) {
                    rb.velocity = Vector2.up * dashSpeed;
                } else if(direction == 4) {
                    rb.velocity = Vector2.down * dashSpeed;
                }
            }
        }
    }

    void Clamp()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -34, 34),
            Mathf.Clamp(transform.position.y, -20, 14), transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EnemyPentagonToTarget" || collision.gameObject.name == "EnemyHexagonBulletTurrentToTarget"
            || collision.gameObject.name == "EnemyHexagonBulletTurrent" || collision.gameObject.name == "EnemyTriangle")
        {
            Destroy(collision.gameObject);
        }
    }
}
