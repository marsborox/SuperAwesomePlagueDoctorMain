using System.Collections;

using UnityEngine;

public class Explosion : Projectile
{
    public float explosionRadius = 10f;
    public float explosionSpeed = 60f;
    public float craterDisplayTime = 0.5f;
    private bool _isExploding = false;
    private bool _isExploded = false; 
    private Vector3 _scaleChange;
    private CircleCollider2D _myCollider2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _myCollider2D = GetComponent<CircleCollider2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (_isExploding)
        {
            ExplosionGrowth();
        }
        else if (!_isExploded) 
        {

            base.BulletMovement();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Explode();
        }
        else if (other.tag == targetTag)
        {
            Explode();//Debug.Log("bullet Hit");
        }
    }
    public void Explode()
    { 
        _isExploding = true;
    }
    private void ExplosionGrowth()
    {
        if (gameObject.transform.localScale.x > explosionRadius)
        { 
            _isExploded = true;
            _isExploding = false;
            _myCollider2D.enabled = false;
            StartCoroutine(PostExplosionRoutine());
        }
        else 
        { 
            float increase = explosionSpeed * Time.deltaTime;
            _scaleChange = new Vector3(increase, increase, 0);
            gameObject.transform.localScale += _scaleChange;
        }
    }
    IEnumerator PostExplosionRoutine()
    { 
        yield return new WaitForSeconds(craterDisplayTime);
        Destroy(gameObject);
    }

}
