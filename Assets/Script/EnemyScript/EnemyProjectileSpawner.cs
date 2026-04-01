using UnityEngine;

public class EnemyProjectileSpawner : MonoBehaviour
{
    public GameObject enemyProjectilePrefab; 
    public float spawnTimer = 10; // ตัวจับเวลาสำหรับการเกิดกระสุน
    public float spawnMax = 10;// เกิดกระสุนมากสุด
    public float spawnMin = 3;// เกิดกระสุนต่ำสุด
    AudioManager audioManager;
    private void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);// ตั้งค่าตัวจับเวลาครั้งแรกเป็นค่าระหว่าง spawnMin และ spawnMax
    }
    private void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
        void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0) 
        {
            audioManager.PlaySFX(audioManager.LaserShot);
            Instantiate(enemyProjectilePrefab, transform.position, Quaternion.identity);
            spawnTimer = Random.Range(spawnMin, spawnMax);// รีเซ็ตตัวจับเวลาเป็นค่าระหว่าง spawnMin และ spawnMax อีกครั้ง
        }
       
    }
}
