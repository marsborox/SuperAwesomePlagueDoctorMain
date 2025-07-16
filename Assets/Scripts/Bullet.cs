using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 8f;
    private void Update()
    {
        BulletMovement();
    }
    void BulletMovement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
    }
}
