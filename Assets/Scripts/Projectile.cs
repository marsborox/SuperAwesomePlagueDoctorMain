using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string targetTag;
    [SerializeField] private float movementSpeed = 8f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (other.tag == targetTag)
        { 
            
        }
    }
    private void Update()
    {
        BulletMovement();
    }
    void BulletMovement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
    }
}
