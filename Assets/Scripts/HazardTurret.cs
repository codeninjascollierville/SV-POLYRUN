using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTurret : MonoBehaviour
{
    [SerializeField]
    public GameObject bullet;

    public float fireRate;
    public float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
