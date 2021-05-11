using System;
using System.Collections;
using UnityEngine;

public class ShipHitController : MonoBehaviour
{
    [SerializeField]
    Vector3 resetPosition = Vector3.zero;

    [SerializeField]
    float immunityDelayTime = 1;

    SpriteRenderer spriteRenderer;

    public bool ImmuneToAsteroids { get; private set; }

    Action onHit;
    Action onReset;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetOnHit(Action action)
    {
        onHit += action;
    }

    public void SetOnReset(Action action)
    {
        onReset += action;
    }

    public void TogglePlayerObject(bool enabled)
    {
        gameObject.SetActive(enabled);
    }

    void OnEnable()
    {
        ResetPlayerAfterHit();
    }

    void ResetPlayerAfterHit()
    {
        spriteRenderer.color = new Color(1, 1, 1, .25f);
        transform.position = resetPosition;
        ImmuneToAsteroids = true;
        StartCoroutine(DelayEnableCollider());
    }

    IEnumerator DelayEnableCollider()
    {
        yield return new WaitForSeconds(immunityDelayTime);
        spriteRenderer.color = Color.white;
        onReset?.Invoke();
        ImmuneToAsteroids = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagContainer.TagAsteroid) && !ImmuneToAsteroids)
        {
            onHit?.Invoke();

            if (gameObject.activeSelf)
            {
                ResetPlayerAfterHit();
            }
        }
    }
}
