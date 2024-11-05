using System.Threading.Tasks;

public class Shield : Powers
{
    public override bool IsUsable()
    {
        return !PlayerMain.Instance.Shield.activeSelf;
    }

    public override async void Activate()
    {
        AudioManager.Instance.PlaySFXClip(Sounds.Shield);
        await StartShielding();
    }

    async Task StartShielding()
    {
        ActiveShield();
        await Task.Delay(2000);
        ActiveShield(false);
    }
}
