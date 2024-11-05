using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    [field : SerializeField]
    public PlayerInputs Inputs {  get; private set; }

    [field : SerializeField]
    public PlayerMovement Movement { get; private set; }

    [field : SerializeField]
    public PlayerCollision Collision { get; private set; }

    [field : SerializeField]
    public PlayerPowers Powers { get; private set; }

    [field : SerializeField] 
    public GameObject Shield { get; private set; }

    //singleton
    private static PlayerMain instance;

    public static PlayerMain Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("Player Main");
                instance = go.AddComponent<PlayerMain>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
}
