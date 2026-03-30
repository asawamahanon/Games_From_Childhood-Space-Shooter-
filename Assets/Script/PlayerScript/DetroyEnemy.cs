using System.Collections;   
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetroyEnemy : MonoBehaviour
{
    public GameObject explosionPrefab;
    private PlayerScore scoreManager;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<PlayerScore>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionPrefab,collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            scoreManager.UpdateScore(10);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Boundary")) 
        { 
            Destroy(gameObject);
        }
    }
}
