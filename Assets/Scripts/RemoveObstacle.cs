using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mummy"))
        {
            //Debug.Log("Clear Mob by collision");
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            //Debug.Log("Clear Gem by trigger");
            Destroy(other.gameObject);
        }
    }
}
