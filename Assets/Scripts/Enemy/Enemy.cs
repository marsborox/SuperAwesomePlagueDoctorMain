using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Player target;
    public float movementSpeed = 300;

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (target == null)
            return;
        Debug.Log("target not null");
        //Vector3 delta = target.transform.position*movementSpeed*Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position,movementSpeed*Time.deltaTime);
    }
}
