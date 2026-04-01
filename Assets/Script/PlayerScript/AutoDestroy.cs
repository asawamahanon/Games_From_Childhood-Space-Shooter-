using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.5f);//ทำลายวัตถุนี้หลังจาก 0.5 วินาที ใช้สำหรับทำลายเอฟเฟกต์ระเบิดหลังจากแสดงผลแล้ว
    }

 
}
