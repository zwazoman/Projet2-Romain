using UnityEngine;

public class PowersUIManager : MonoBehaviour
{
    //singleton
    private static PowersUIManager instance;

    public static PowersUIManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("Powers UI Manager");
                instance = go.AddComponent<PowersUIManager>();
            }
            return instance;
        }
    }

    // dictionnaire ? vraiment mieux mais faut le serializer = package
    [field : SerializeField] public GameObject SuperJumpUi { get; private set; }
    [field : SerializeField] public GameObject DashUi { get; private set; }
    [field : SerializeField] public GameObject DoubleJumpUI { get; private set; }
    [field : SerializeField] public GameObject ShieldUI { get; private set; }
    [field : SerializeField] public GameObject ShootUI { get; private set; }


    GameObject UiPower;

    PlayerPowers _playerPowers;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _playerPowers = PlayerMain.Instance.Powers;
        _playerPowers.OnPowerAdd += ReplaceUIPower;
        _playerPowers.OnPowerUse += ReplaceUIPower;
    }

    void ReplaceUIPower()
    { 
        if (UiPower != null) UiPower.SetActive(false);
        if(_playerPowers.PossessedPowers.Count > 0)
        {
            UiPower = _playerPowers.PossessedPowers.Peek().pickupItem._powerUI;
            UiPower.SetActive(true);
        }
    }
}
