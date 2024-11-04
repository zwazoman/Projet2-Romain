using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : Powers
{
    public override void Activate()
    {
        Impulse(Vector2.up, 32f);
    }

    public override bool IsUsable()
    {
        return PlayerMain.Instance.Movement.IsGrounded;
    }
}
