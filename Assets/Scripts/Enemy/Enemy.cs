using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Player target;
    public int damage = 10;
    public int rewardScore = 5;
    public float movementSpeed = 3;
    public int range = 3;

    public float attackInterval;
    public float attackTimer;


    public Enemy_SO enemyTemplate;
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
        if (other.tag == "Bullet")
        {
            Debug.Log("BulletHitMe");
            Die();
        }

        else if (other.tag == "Player")
        {
            target.playerEventHandler.ChangeHealth(-damage);
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
        target.playerEventHandler.ChangeHealth(rewardScore);
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
}
