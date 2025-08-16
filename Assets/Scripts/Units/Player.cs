using UnityEngine;

public class Player : Unit
{
    public Transform respawnPoint;
    //[SerializeField] private Projectile Bullet;
    //public EventHandler_Unit unitEventHandler;

    public int score=0;
    
    
    void Awake()
    {
        base.Awake();
        Debug.Log("Player awake done");

        
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
        unitEventHandler.OnResetScore += ResetScore;
    }
    private void OnDisable()
    {
        unitEventHandler.OnDeath -= Die;
        unitEventHandler.OnScoreChange -= ChangeScore;
        unitEventHandler.OnResetScore -= ResetScore;
    }
    void Die()
    {
        Debug.Log("plyer ded");
        /*score = 0;
        unitEventHandler.ResetHealth();*/
        
        unitEventHandler.ResetHealth();
        unitEventHandler.ResetScore();
        transform.position=respawnPoint.position;
    }
    void ChangeScore(int changeHealthValue)
    {
        score += changeHealthValue;
        //Debug.Log("HeroGotHit");
    }

    private void ResetScore()
    { 
        score = 0;
    }
    public override void OnColliderTrigger(Collider2D other)
    {
        //Debug.Log("PlayerGotHit");
        if (other.tag == "Projectile")
        {
            //Debug.Log("PlayerGotHit with projectile");
            Projectile projectile = other.gameObject.GetComponent<Projectile>();
            if (projectile.targetTag == gameObject.tag)
            {
                //Debug.Log("PlayerGotHit with projectile by enemy w damage " + projectile.damage);
                unitEventHandler.ChangeHealth(-projectile.damage);
                Destroy(projectile.gameObject);
            }
        }
    }
}
