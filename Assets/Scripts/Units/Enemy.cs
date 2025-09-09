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
   
    [SerializeField] private SpriteRenderer _sprite;
    
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
            Debug.Log("touched enemy");
            /*target.TakeDamage(ReturnDamageAmount());
            Destroy(this.gameObject);*/
            enemyTemplate.enemyBehavior_SO.TouchedTarget(this);

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
            unitStats.damage_s.amount = enemyTemplate.damage;
            rewardScore = enemyTemplate.rewardScore;
            unitStats.movementSpeed_s.amount = enemyTemplate.movementSpeed;
            range = enemyTemplate.range;
            //unitStats.attackInterval = enemyTemplate.attackInterval;
            unitStats.attackSpeed_s.amount = enemyTemplate.attackSpeed;
            unitEventHandler.ResetHealth();//may be redundant - or take value from SO
            unitStats.healthMax_s.amount = enemyTemplate.healthMax;
            _sprite.color = enemyTemplate.color;
        }
    }
    private void SetDefaultEnemyProperties()
    {
        unitStats.damage_s.amount = 10;
        Debug.Log("no template on enemy");
    }
    private void PerformEnemyBehavior()
    {
        if (target == null)
            return;
        if (enemyTemplate ==null)
        {
            //Debug.Log("target not null");
            Debug.Log("template null");
            //Vector3 delta = target.transform.position*movementSpeed*Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, ReturnMovementSpeedAmount() * Time.deltaTime);
        }
        else
        {
            enemyTemplate.DoBehavior(target,this);
        }
    }
    private void ShotReload()
    {
        if (!isAttackReady)
        {
            unitStats.attackTimer += Time.deltaTime;
            if (unitStats.attackTimer >= ReturnAttackIntervalAmount())
            {
                unitStats.attackTimer =- ReturnAttackIntervalAmount();
                isAttackReady = true;
            }
        }
    }
    private void Die()
    {
        //Debug.Log("Implement Loot");
        target.AddScore(rewardScore);
        Destroy(this.gameObject);

    }
    void Test()
    {
        this.tag = "enemy";
    }
    private void GotHit(Projectile projectile)
    {
        TakeDamage(projectile.damage);
        //projectile.sourceUnit.AddScore(rewardScore);
    }
    /*
    private void GotHit(Projectile projectile)
    {
        unitEventHandler.ChangeHealth(-projectile.damage);
        projectile.sourceUnit.unitEventHandler.ChangeScore(rewardScore);
    }
     */   
}
