using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZone : MonoBehaviour
{
    public Rigidbody rb;
    public float verticalImpulse;




        private void OnCollisionEnter(Collision collision)
        {
                if (collision.gameObject.tag == "Player")
                {                                                                   //Jump
                    rb.AddForce(new Vector2(0, verticalImpulse), ForceMode.Impulse);
                    Debug.Log("MegaJumpButton");
                }
        }
}
