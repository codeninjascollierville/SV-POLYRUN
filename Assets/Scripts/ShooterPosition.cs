using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPosition : MonoBehaviour
{
    public Transform shooter;
    public Transform shooterPosition1;
    public Transform shooterPosition2;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            shooter.transform.rotation = Quaternion.Euler(0, 0, 0);
            Instantiate(bullet, shooterPosition1.transform.position, shooterPosition1.transform.rotation);
            Instantiate(bullet, shooterPosition2.transform.position, shooterPosition2.transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            shooter.transform.rotation = Quaternion.Euler(0, 0, 180);
            Instantiate(bullet, shooterPosition1.transform.position, shooterPosition1.transform.rotation);
            Instantiate(bullet, shooterPosition2.transform.position, shooterPosition2.transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            shooter.transform.rotation = Quaternion.Euler(0, 0, -90);
            Instantiate(bullet, shooterPosition1.transform.position, shooterPosition1.transform.rotation);
            Instantiate(bullet, shooterPosition2.transform.position, shooterPosition2.transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            shooter.transform.rotation = Quaternion.Euler(0, 0, 90);
            Instantiate(bullet, shooterPosition1.transform.position, shooterPosition1.transform.rotation);
            Instantiate(bullet, shooterPosition2.transform.position, shooterPosition2.transform.rotation);
        }
    }
}
