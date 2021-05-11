using UnityEngine;

[DisallowMultipleComponent]
public class ShipInputController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbodyShip;

    [SerializeField]
    ShipHitController shipHitController;

    [SerializeField]
    ShipInputReader shipInputReader;

    [SerializeField]
    GameObjectPool bulletPool;

    [SerializeField]
    float forwardSpeed = 10;

    [SerializeField]
    float rotateSpeed = 15;

    bool ShootingRestricted { get; set; }

    void Start()
    {
        shipHitController.SetOnHit(() => ShootingRestricted = true);
        shipHitController.SetOnReset(() => ShootingRestricted = false);

        //Spawn bullet with small offset ahead
        shipInputReader.OnShootPressed += () =>
        {
            if (!ShootingRestricted)
            {
                bulletPool.GetObject(transform.position + (transform.right * .75f), transform.rotation);
                AudioController.Instance.PlayShootSound();
            }
        };
    }

    void FixedUpdate()
    {
        if (shipInputReader.moveForward)
        {
            rigidbodyShip.AddForce(transform.right * forwardSpeed, ForceMode2D.Force);
        }

        if (shipInputReader.rotateClockwise)
        {
            rigidbodyShip.AddTorque(-rotateSpeed);
        }

        if (shipInputReader.rotateAntiClockwise)
        {
            rigidbodyShip.AddTorque(rotateSpeed);
        }
    }
}
