using UnityEngine;

public class Player : Unit
{
    //[SerializeField] private Projectile Bullet;
    public EventHandler_Unit unitEventHandler;

    public int score=20;


    private void Awake()
    {
        unitEventHandler = GetComponent<EventHandler_Unit>();
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
        unitEventHandler.OnHealthChange += ChangeScore;

    }
    void ChangeScore(int changeHealthValue)
    {
        score += changeHealthValue;
        Debug.Log("HeroGotHit");
    }
}
