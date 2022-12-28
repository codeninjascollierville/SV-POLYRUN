using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner4 : MonoBehaviour
{
    float dirX, moveSpeed = 20f;
    bool moveRight = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 25f)
            moveRight = false;
        if (transform.position.y < -25f)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
    }
}
