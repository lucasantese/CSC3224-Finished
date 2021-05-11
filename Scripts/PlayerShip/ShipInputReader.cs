using System;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class ShipInputReader : MonoBehaviour
{
    public bool moveForward { get; protected set; }
    public bool rotateClockwise { get; protected set; }
    public bool rotateAntiClockwise { get; protected set; }
    public Action OnShootPressed;
}
