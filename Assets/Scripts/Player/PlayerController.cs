using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveInput;
    private PlayerMovement _playerMovement;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        _playerMovement.Move(moveInput);
    }
    void OnMove(InputValue value)
    { 
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }
    void OnAttack(InputValue value)
    {
        if (value.isPressed)
        { 
            
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Crash");
    }
}
