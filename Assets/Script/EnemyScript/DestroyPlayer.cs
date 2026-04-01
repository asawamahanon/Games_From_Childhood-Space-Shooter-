using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoundaryDown"))//ตรวจสอบว่าชนกับวัตถุที่มีแท็ก "BoundaryDown" หรือไม่
        {
            Destroy(gameObject);//ถ้าชนกับวัตถุที่มีแท็ก "BoundaryDown" ให้ทำลายวัตถุนี้ (ทำลายกระสุนของศัตรู(ตอนสร้างสคริปเขียนผิดครับ))
        }
    }
}
