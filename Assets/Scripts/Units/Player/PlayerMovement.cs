using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed=10f;

    public void Move(Vector2 moveInput)
    {
        Vector3 delta = moveInput * movementSpeed * Time.deltaTime;
        transform.position += delta;
    }
}
