public class ShieldPickup : PowerPickup
{
    private void Start()
    {
        _powerUI = PowersUIManager.Instance.ShieldUI;
    }

    protected override void OnPickup()
    {
        Shield shield = new Shield();
        shield.pickupItem = this;
        PlayerMain.Instance.Powers.AddPower(shield);
    }
}
