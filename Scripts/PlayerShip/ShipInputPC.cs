using UnityEngine;

public class ShipInputPC : ShipInputReader
{
    void Update()
    {
        moveForward = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        rotateClockwise = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        rotateAntiClockwise = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        PollShootPressed();
    }

    void PollShootPressed()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            OnShootPressed?.Invoke();
    }
}
