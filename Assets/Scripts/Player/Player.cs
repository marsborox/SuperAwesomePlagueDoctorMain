using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet Bullet;
    public PlayerEventHandler playerEventHandler;

    public int score=20;


    private void Awake()
    {
        playerEventHandler = GetComponent<PlayerEventHandler>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEnable()
    {
        playerEventHandler.OnHealthChange += ChangeScore;

    }
    void ChangeScore(int changeHealthValue)
    {
        score += changeHealthValue;
        Debug.Log("HeroGotHit");
    }
}
