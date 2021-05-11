using System.Collections;
using UnityEngine;

public class Bullet : PoolObject
{
    [SerializeField]
    float speed = 1;

    [SerializeField]
    float timeBeforeRemoving = 3;

    [SerializeField]
    Rigidbody2D rigidbodyBullet;

    [SerializeField]
    float maxTravelDistance;

    [Tooltip("If true this will destroy bullets as soon as they reach the edge of the play area")]
    [SerializeField]
    bool destroyBulletOnEdgeHit;

    void OnEnable()
    {
        StartCoroutine(ReturnTimer());
        rigidbodyBullet.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    IEnumerator ReturnTimer()
    {
        yield return new WaitForSeconds(timeBeforeRemoving);
        ReturnToPool();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (destroyBulletOnEdgeHit)
        {
            ReturnToPool();
            return;
        }

        if (!collision.CompareTag(TagContainer.TagWall))
        {
            ReturnToPool();
        }
    }
}
