using System.Collections;
using UnityEngine;


public class ProjectileShoot : MonoBehaviour
{   
    public GameObject projectilePrefab;//prefab ของกระสุนที่เราจะยิงออกไป
    AudioManager audioManager;
    public float delayTime = 0.5f; //เวลาที่จะต้องรอระหว่างการยิงแต่ละครั้ง
    public bool canShoot = true; //ตัวแปรที่ใช้ตรวจสอบว่าผู้เล่นสามารถยิงได้หรือไม่

    private void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot == true)
        {
            audioManager.PlaySFX(audioManager.LaserShot);//เล่นเสียงยิงกระสุน
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);//สร้างกระสุนที่ตำแหน่งของผู้เล่น โดยไม่มีการหมุน
            canShoot = false; //ตั้งค่า canShoot เป็น false เพื่อไม่ให้ผู้เล่นยิงได้ทันที
            StartCoroutine(ResetShoot()); //เริ่มต้น Coroutine เพื่อรีเซ็ตสถานะการยิงหลังจากเวลาที่กำหนด
        }
    }
    private IEnumerator ResetShoot()
    {
        yield return new WaitForSeconds(delayTime); //รอเวลาที่กำหนดก่อนที่จะสามารถยิงได้อีกครั้ง
        canShoot = true; //ตั้งค่า canShoot เป็น true เพื่อให้ผู้เล่นสามารถยิงได้อีกครั้ง
    }
}
