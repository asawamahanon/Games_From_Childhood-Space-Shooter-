using UnityEngine;
using System.Collections;   
using System.Collections.Generic;
public class DetroyEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Enemy"))
       {
           Destroy(collision.gameObject);
           Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Boundary")) 
        { 
            Destroy(gameObject);
        }
    }
}
