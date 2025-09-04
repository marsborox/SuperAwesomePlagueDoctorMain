using UnityEngine;

public class Player : Unit
{
    public Transform respawnPoint;
    //[SerializeField] private Projectile Bullet;
    //public EventHandler_Unit unitEventHandler;
    public Attack_Player attackPlayer;

    
    
    
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
        unitEventHandler.OnDeath += Die;
    }
    private void OnDisable()
    {
        unitEventHandler.OnDeath -= Die;
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
    public float ReturnHealthCurrent()
    {

        return unitHealth.healthCurrent;
    }
    public float ReturnHealthMax()
    { 
        return unitStats.healthMax_s.amount;
    }
    public float ReturnDamageAmount()
    { 
        return unitStats.damage_s.amount;
    }
    public float ReturnMovementSpeedAmount()
    { 
        return unitStats.movementSpeed_s.amount;
    }
    public float ReturnAttackSpeedAmount()
    {
        return unitStats.attackSpeed_s.amount;
    }
    public float ReturnAttackIntervalAmount()
    { 
        return unitStats.attackInterval;
    }
    public float ReturnScoreAmount()
    {
        return unitStats.score;
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
