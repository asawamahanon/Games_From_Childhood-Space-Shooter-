using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    public GameObject enemyFormationPrefab;//prefab ของกลุ่มศัตรูที่เราจะสร้างใหม่
    public float respawnDelay = 2f;//เวลาที่จะรอก่อนที่จะสร้างกลุ่มศัตรูใหม่

    private bool isWaitingForNextWave = false;//ตัวแปรที่ใช้ในการตรวจสอบว่าเรากำลังรอการสร้างกลุ่มศัตรูใหม่อยู่หรือไม่
    private Vector3 startPosition; //ตำแหน่งเริ่มต้นของกลุ่มศัตรู

    void Start()
    {
        startPosition = transform.position;//เก็บตำแหน่งเริ่มต้นของกลุ่มศัตรูเมื่อเริ่มเกม
    }
    void Update()
    {
        if (transform.childCount == 0 && !isWaitingForNextWave)//ตรวจสอบว่ากลุ่มศัตรูไม่มีลูกศรหรือไม่ และเรายังไม่รอการสร้างกลุ่มศัตรูใหม่
        {
            isWaitingForNextWave = true;
            Invoke(nameof(SpawnNewWave), respawnDelay);
        }
    }
    void SpawnNewWave()//ฟังก์ชันที่ใช้ในการสร้างกลุ่มศัตรูใหม่
    {
        transform.position = startPosition;
        GameObject newWave = Instantiate(enemyFormationPrefab, transform.position, Quaternion.identity);
        Transform[] allEnemies = new Transform[newWave.transform.childCount];//สร้างอาร์เรย์เพื่อเก็บตัวศัตรูทั้งหมดในกลุ่มใหม่
        for (int i = 0; i < newWave.transform.childCount; i++)//วนลูปเพื่อกำหนดให้ศัตรูทั้งหมด
        {
            allEnemies[i] = newWave.transform.GetChild(i);//ดึงตัวศัตรูแต่ละตัวจากกลุ่มใหม่มาเก็บลงในอาร์เรย์
        }

        foreach (Transform child in allEnemies)//วนลูปเพื่อกำหนดพ่อแม่ของศัตรูแต่ละตัวในกลุ่มใหม่ให้เป็นกลุ่มศัตรูนี้
        {
            child.SetParent(this.transform);//กำหนดพ่อแม่ของศัตรูแต่ละตัวในกลุ่มใหม่ให้เป็นกลุ่มศัตรูนี้ เพื่อให้พวกมันเคลื่อนที่ไปพร้อมกัน
        }

        Destroy(newWave);
        isWaitingForNextWave = false;
    }
}
