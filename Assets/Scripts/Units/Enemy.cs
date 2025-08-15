using System.Threading;

using UnityEngine;

public class Enemy : Unit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Projectile _projectile;
    //[SerializeField] public string targetTag = "Player";
    public Enemy_SO enemyTemplate;
    public Player target;


    //public int damage = 10;
    public int rewardScore = 5;
    public float range = 3;
    
    public float movementSpeed = 3;
    public float attackInterval;
    public float attackTimer=0;

    public bool attackReady = true;

    

    private void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        targetTag = "Player";
        SetEnemyProperties();
        
    }
    private void Update()
    {
        PerformEnemyBehavior();
        ShotReload();

    }
    private void OnEnable()
    {
        unitEventHandler.OnDeath += Die;
    }
    private void OnDisable()
    {
        unitEventHandler.OnDeath -= Die;
    }
    public override void OnColliderTrigger(Collider2D other)
    {
        //Debug.Log("Colision");
        if (other.tag == "Projectile")
        {
            //Debug.Log("BulletHitMe");
            Projectile projectile = other.gameObject.GetComponent<Projectile>();
            if (projectile.targetTag == gameObject.tag)
            {
                GotHit(projectile);
                Destroy(projectile.gameObject);
            }
        }
        else if (other.tag == targetTag)
        {
            target.unitEventHandler.ChangeHealth(-damage);
            Destroy(this.gameObject);
        }
    }

    
    private void SetEnemyProperties()
    {
        if (enemyTemplate == null)
        {
            SetDefaultEnemyProperties();
        }
        else
        {
            damage = enemyTemplate.damage;
            rewardScore = enemyTemplate.rewardScore;
            movementSpeed = enemyTemplate.movementSpeed;
            range = enemyTemplate.range;
            attackInterval = enemyTemplate.attackInterval;
            unitEventHandler.ResetHealth();//may be redundant - or take value from SO
            unitHealth.healthMax = enemyTemplate.healthMax;
        }
    }
    private void SetDefaultEnemyProperties()
    { 
        damage = 10;
        Debug.Log("no template on enemy");
    }
    private void PerformEnemyBehavior()
    {
        if (target == null)
            return;
        if (enemyTemplate ==null)
        {
            //Debug.Log("target not null");
            //Vector3 delta = target.transform.position*movementSpeed*Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
        }
        else
        {
            enemyTemplate.DoBehavior(target,this);
        }
    }
    private void ShotReload()
    {
        if (!attackReady)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackInterval)
            {
                attackTimer =-attackInterval;
                attackReady = true;
            }
        }
    }
    private void Die()
    {
        target.unitEventHandler.ChangeScore(rewardScore);
        Destroy(this.gameObject);
    }
    void Test()
    {
        this.tag = "enemy";
    }
    private void GotHit(Projectile projectile)
    {
        unitEventHandler.ChangeHealth(-projectile.damage);
        projectile.sourceUnit.unitEventHandler.ChangeHealth(rewardScore);
    }
        
}
