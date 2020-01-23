using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    int damage = 2;

    private void Update()
    {
        Vector3 temp;


        temp = transform.position;
        temp.z += Time.deltaTime * 10;
        transform.position = temp;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "requeue")
        {
            gameObject.SetActive(false);
        }


    }
}
