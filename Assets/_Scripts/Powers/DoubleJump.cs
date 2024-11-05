using UnityEngine;

public class DoubleJump : Powers
{
    public override void Activate()
    {
        AudioManager.Instance.PlaySFXClip(Sounds.Jump);
        PlayerMain.Instance.Movement.RB.velocity = Vector2.zero;
        Impulse(Vector2.up, 16f);
    }

    public override bool IsUsable()
    {
        return !PlayerMain.Instance.Movement.IsGrounded;
    }

}
