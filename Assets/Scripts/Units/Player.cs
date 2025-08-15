using UnityEngine;

public class Player : Unit
{
    //[SerializeField] private Projectile Bullet;
    //public EventHandler_Unit unitEventHandler;

    public int score=20;

    
    private void Awake()
    {
        base.Awake();//unitEventHandler = GetComponent<EventHandler_Unit>();
    }
    void Start()
    {
        targetTag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnEnable()
    {
        //unitEventHandler.OnHealthChange += ChangeScore;
        unitEventHandler.OnDeath += Die;
        unitEventHandler.OnScoreChange += ChangeScore;
    }
    private void OnDisable()
    {
        //unitEventHandler.OnHealthChange -= ChangeScore;
    }
    void ChangeScore(int changeHealthValue)
    {
        score += changeHealthValue;
        //Debug.Log("HeroGotHit");
    }
    void Die()
    {
        score = 0;
        unitEventHandler.ResetHealth();
    }
    public override void OnColliderTrigger(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            Projectile projectile = other.gameObject.GetComponent<Projectile>();
            if (projectile.targetTag == gameObject.tag)
            {
                unitEventHandler.ChangeHealth(-projectile.damage);
                Destroy(projectile.gameObject);
            }
        }
    }
}
