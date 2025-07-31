using UnityEngine;

public class Enemy : Unit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Projectile _projectile;
    [SerializeField] private string _targetTag = "Player";
    public Enemy_SO enemyTemplate;
    public Player target;

    public int damage = 10;
    public int rewardScore = 5;
    public float movementSpeed = 3;
    public int range = 3;
    
    public float attackInterval;
    public float attackTimer;

    private void Start()
    {
        SetEnemyProperties();
    }
    private void Update()
    {
        PerformEnemyBehavior();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Colision");
        if (other.tag == "Projectile")
        {
            Debug.Log("BulletHitMe");

            Projectile projectile = other.gameObject.GetComponent<Projectile>();
            if (projectile.targetTag == gameObject.tag)
            { 
            Die();
            }
        }
       
        else if (other.tag == _targetTag)
        {
            target.unitEventHandler.ChangeHealth(-damage);
            Destroy(this.gameObject);


        }
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
    private void Die()
    {
        target.unitEventHandler.ChangeHealth(rewardScore);
        Destroy(this.gameObject);
    }
    private void SetEnemyProperties()
    {
        if (enemyTemplate == null)
            return;
        damage = enemyTemplate.damage;
        rewardScore = enemyTemplate.rewardScore;
        movementSpeed = enemyTemplate.movementSpeed;
        range = enemyTemplate.range;
    }
    void Test()
    {
        this.tag = "enemy";
    }

}
