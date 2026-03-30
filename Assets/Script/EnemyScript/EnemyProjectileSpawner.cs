using UnityEngine;

public class EnemyProjectileSpawner : MonoBehaviour
{
    public GameObject enemyProjectilePrefab;
    public float spawnTimer = 10;
    public float spawnMax = 10;
    public float spawnMin = 5;
    private void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }
   
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0) 
        {
            Instantiate(enemyProjectilePrefab, transform.position, Quaternion.identity);
            spawnTimer = Random.Range(spawnMin, spawnMax);
        }
       
    }
}
