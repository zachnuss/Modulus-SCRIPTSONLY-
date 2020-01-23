using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astoroid : MonoBehaviour
{
    float speed = 2;
    float tempZ;
    int health = 50;
    int damage = 10;

    // Update is called once per frame
    void Update()
    {
        tempZ = transform.position.z;

        tempZ -= Time.deltaTime * speed;

        transform.position = new Vector3(transform.position.x, 0, tempZ);
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "requeue")
        {
            gameObject.SetActive(false);



        }
        if(collision.gameObject.tag == "bullet")
        {
            health -= 2;
            collision.gameObject.SetActive(false);
            if (health <= 0)
            {
                health = 50;
                gameObject.SetActive(false);
            }
            
        }


    }
}
