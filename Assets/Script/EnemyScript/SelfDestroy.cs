using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoundaryDown"))
        {
            Destroy(gameObject);
        }
    }
}
