using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    public GameObject enemyFormationPrefab;
    public float respawnDelay = 2f;

    private bool isWaitingForNextWave = false;
    private Vector3 startPosition; // เพิ่มตัวแปรนี้เพื่อจำจุดเริ่มต้น

    void Start()
    {
        // จำตำแหน่งตั้งต้นของหน้ากระดานไว้ตั้งแต่เริ่มเกม
        startPosition = transform.position;
    }

    void Update()
    {
        if (transform.childCount == 0 && !isWaitingForNextWave)
        {
            isWaitingForNextWave = true;
            Invoke(nameof(SpawnNewWave), respawnDelay);
        }
    }

    void SpawnNewWave()
    {
        // 1. ดึงยานแม่ (EnemyShip) กลับไปที่จุดเริ่มต้นก่อน!
        transform.position = startPosition;

        // 2. ค่อยสร้างศัตรูชุดใหม่ที่จุดนั้น
        GameObject newWave = Instantiate(enemyFormationPrefab, transform.position, Quaternion.identity);

        Transform[] allEnemies = new Transform[newWave.transform.childCount];
        for (int i = 0; i < newWave.transform.childCount; i++)
        {
            allEnemies[i] = newWave.transform.GetChild(i);
        }

        foreach (Transform child in allEnemies)
        {
            child.SetParent(this.transform);
        }

        Destroy(newWave);
        isWaitingForNextWave = false;
    }
}
