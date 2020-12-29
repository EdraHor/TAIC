using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public GameObject Character;




    private void OnCollisionEnter(Collision collision)
    {
        Character.GetComponent<HP_SYSTEM>().HP -= 1;
        //HP_SYSTEM.HP -= 1;
    }

 }
