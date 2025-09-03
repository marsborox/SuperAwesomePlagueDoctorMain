using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Unit sourceUnit;
    public string targetTag;
    [SerializeField] private float movementSpeed = 8f;
    public float damage;
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (other.tag == targetTag)
        {
            //Debug.Log("bullet Hit");
        }
    }
    public void Update()
    {
        BulletMovement();
    }
    public void BulletMovement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
    }
}
