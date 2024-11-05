using System.Threading.Tasks;
using UnityEngine;

public class Dash : Powers
{
    public override async void Activate()
    {
        AudioManager.Instance.PlaySFXClip(Sounds.Dash);
        await DashAsync();
    }

    async Task DashAsync()
    {
        Vector2 direction = new Vector2(PlayerMain.Instance.gameObject.transform.localScale.x, 0f);
        Rigidbody2D playerRB = PlayerMain.Instance.Movement.RB;
        float oldGravityScale = playerRB.gravityScale;
        playerRB.gravityScale = 0f;
        PlayerMain.Instance.Movement.IsLocked = true;
        PlayerMain.Instance.Powers.IsLocked = true;
        Impulse(direction, 30);
        await Task.Delay(200);
        if(playerRB != null) playerRB.gravityScale = oldGravityScale;
        PlayerMain.Instance.Movement.IsLocked = false;
        PlayerMain.Instance.Powers.IsLocked = false;
    }
}
