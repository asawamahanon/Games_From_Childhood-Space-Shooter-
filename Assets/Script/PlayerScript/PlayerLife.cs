using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLife : MonoBehaviour
{
    public int Life = 3; //จำนวนชีวิตเริ่มต้น
    public Image[] LivesUI; //อาร์เรย์ของไอคอนพลังชีวิตใน UI
    public GameObject explosionPrefab;  //prefabของเอฟเฟกต์ระเบิดเมื่อโดนศัตรู
    public float invisibleDuration = 1.5f; //ระยะเวลาอมตะ
    public bool isInvisible = false; //สถานะอมตะเริ่มต้นเป็นเท็จ
    AudioManager audioManager;
    //ฟังก์ชันเริ่มต้นอมตะ จะทำงานเมื่อผู้เล่นโดนศัตรูและกระสุน
    public void StartInvisible()
    {
        if (!isInvisible) //ตรวจสอบว่าผู้เล่นไม่อยู่ในสถานะอมตะก่อนที่จะใช้StartCoroutine แล้วสั่งไปยังฟังก์ชัน iFarmeCoroutine เพื่อเริ่มต้นการทำงานของ Coroutine
        { 
        StartCoroutine(iFarmeCoroutine());
        }
    }
    private void Awake()
    {
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }   

    //ฟังก์ชันตรวจจับตามเงื่อนไขการชนกับศัตรู เมื่อกับวัตถุที่มีแท็ก "Enemy"   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            if (isInvisible)
            {
                return;
            }
            Destroy(collision.gameObject);
            audioManager.PlaySFX(audioManager.ExplosionUnderSnowSFX);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            StartInvisible();
            Life--;
            for (int i = 0; i < LivesUI.Length; i++)
            {
                if (i < Life)
                {
                    LivesUI[i].enabled = true;
                }
                else
                {
                    LivesUI[i].enabled = false;
                }
            }
            if (Life <= 0)
            {
                Die();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isInvisible) //ทำการตรวจสอบสถานะอมตะ
            {
                return;
            }
            //ถ้าไม่อยู่ในสถานะอมตะจะทำการทำลายวัตถุที่ชน สร้างเอฟเฟกต์ระเบิด เริ่มต้นสถานะอมตะ ลดจำนวนชีวิต และอัปเดต UI ของชีวิต
            Destroy(collision.gameObject);
            audioManager.PlaySFX(audioManager.ExplosionUnderSnowSFX);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            StartInvisible();
            Life--;
            for (int i = 0; i < LivesUI.Length; i++)
            {
                if (i < Life)
                {
                    LivesUI[i].enabled = true;
                }
                else
                {
                    LivesUI[i].enabled = false;
                }
            }
            if (Life <= 0)//ถ้าชีวิตลดลงเหลือ 0 หรือน้อยกว่า จะเรียกใช้ฟังก์ชัน Die เพื่อจัดการกับการตายของผู้เล่น
            {
                Die();
            }
        }
    }

    //ฟังก์ชันที่จัดการกับการตายของผู้เล่น โดยจะทำลายวัตถุผู้เล่นและโหลดฉาก "GameOver"
    private void Die()
    {
        Destroy(gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    //ฟังก์ชันCoroutine ที่ทำให้ผู้เล่นอมตะและกระพริบเมื่อโดนศัตรูหรือกระสุน  
    private IEnumerator iFarmeCoroutine()
    {
        isInvisible = true; //ตั้งค่าสถานะอมตะเป็นจริง
        SpriteRenderer sr = GetComponent<SpriteRenderer>();//รับคอมโพเนนต์ SpriteRenderer 
        for (float i = 0; i < invisibleDuration; i += 1.5f)//ลูปทำให้ผู้เล่นกระพริบในระหว่างที่อมตะ โดยจะทำการเปลี่ยนสีของ SpriteRenderer เพื่อสร้างเอฟเฟกต์กระพริบ
        {
            sr.color = new Color(1, 1, 1, 0.5f);//ทำให้ผู้เล่นโปร่งใสครึ่งหนึ่ง
            yield return new WaitForSeconds(0.75f);//รอ 0.75 วินาที
            sr.color = new Color(1, 1, 1, 1f);//ทำให้ผู้เล่นกลับมาเป็นปกติ
            yield return new WaitForSeconds(0.75f);
        }
        sr.color = new Color(1, 1, 1, 1f);
        isInvisible = false;//ตั้งค่าสถานะอมตะเป็นเท็จเมื่อระยะเวลาอมตะสิ้นสุดลง
    }
}

