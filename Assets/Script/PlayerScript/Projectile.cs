using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed ;
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);//การเคลื่อนที่ของกระสุนในทิศทางขึ้นไป โดยใช้ความเร็วและเวลาที่ผ่านไป
    }
    
}
