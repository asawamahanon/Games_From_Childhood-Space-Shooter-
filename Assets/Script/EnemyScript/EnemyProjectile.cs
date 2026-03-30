using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
