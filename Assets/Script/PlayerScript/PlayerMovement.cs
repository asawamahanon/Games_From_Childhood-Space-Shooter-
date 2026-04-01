using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public float moveX;//ตัวแปรสำหรับเก็บค่าการเคลื่อนที่ในแนวนอน

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }
}
