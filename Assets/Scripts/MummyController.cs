using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : MonoBehaviour
{

    //TODO : Random Move Left Right Function for Mummy; How ???

    private Rigidbody mummyRb;
    public float runSpeed;
    
    private void Awake()
    {
        mummyRb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.IsGameStart())
        {
            mummyRb.MovePosition(transform.position + transform.forward * runSpeed * Time.deltaTime);
        }
    }
}
