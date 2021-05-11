using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    Vector2 teleportOffset;

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = (Vector2)collision.transform.position + teleportOffset;
    }
}
