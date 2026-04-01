using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; 
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))//ตรวจสอบว่าชนกับBoundaryหรือไม่
        {
            transform.position =new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);//เลื่อนลงมา 1 หน่วยเมื่อชนขอบเขต
            speed *= -1;//กลับทิศทางการเคลื่อนที่เมื่อชนขอบเขต
        }
    }
}
