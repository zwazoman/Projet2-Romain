using UnityEngine;

public class SuperJump : Powers
{
    public override void Activate()
    {
        for (int i = 0; i < 5; i++) AudioManager.Instance.PlaySFXClip(Sounds.Jump);
        Impulse(Vector2.up, 32f);
    }

    public override bool IsUsable()
    {
        return PlayerMain.Instance.Movement.IsGrounded;
    }
}
