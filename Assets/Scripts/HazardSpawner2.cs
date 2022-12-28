using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner2 : MonoBehaviour
{
    float dirX, moveSpeed = 20f;
    bool moveRight = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 50f)
            moveRight = true;
        if (transform.position.x < -50f)
            moveRight = false;

        if (moveRight)
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
    }
}
