using UnityEngine;

public class DetroyEnemy : MonoBehaviour
{
    public GameObject explosionPrefab; //prefabของเอฟเฟกต์ระเบิด
    private PlayerScore scoreManager; //ตัวแปรสำหรับจัดการคะแนน
    AudioManager audioManager; //ตัวแปรสำหรับจัดการเสียง

    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<PlayerScore>();//หา GameObject ชื่อ "ScoreManager" และดึงคอมโพเนนต์ PlayerScore มาเพื่อจัดการคะแนน
    }
    private void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>(); //หา GameObject ชื่อ "AudioManager" และดึงคอมโพเนนต์ AudioManager มาเพื่อจัดการเสียง
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Enemy"))
        {
            audioManager.PlaySFX(audioManager.ExplosionUnderSnowSFX);//เล่นเสียงเอฟเฟกต์ระเบิดมื่อโดนศัตรู
            Instantiate(explosionPrefab,collision.transform.position, Quaternion.identity);//สร้างเอฟเฟกต์ระเบิดที่ตำแหน่งของศัตรูที่ถูกทำลาย
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
