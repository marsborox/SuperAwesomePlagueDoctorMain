using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveInput;
    private PlayerMovement _playerMovement;
    private PlayerAttack _playerAttack;

    
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<PlayerAttack>();
    }
    private void Update()
    {
        _playerMovement.Move(moveInput);
    }
    void OnMove(InputValue value)
    { 
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);
    }
    void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            _playerAttack.Shoot();
        }
    }

}
