using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Vector2 moveInput;
    private PlayerMovement _playerMovement;
    private Attack_Player _playerAttack;
    private PlayerInput _playerInput;
    private InputAction _attackInputAction;
    [SerializeField] private Player _player;
    private bool _isAttacking=false;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _attackInputAction = _playerInput.actions["Attack"];
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<Attack_Player>();
    }
    private void FixedUpdate()
    {
        _playerMovement.Move(moveInput);
    }
    private void OnEnable()
    {
        _attackInputAction.started += ctx => StartAttacking();
        _attackInputAction.canceled += ctx => StopAttacking();
    }

    private void OnDisable()
    {
        _attackInputAction.started -= ctx => StartAttacking();
        _attackInputAction.canceled -= ctx => StopAttacking();
    }
    private void OnMove(InputValue value)
    { 
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);
    }
    private void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            _playerAttack.Attack();
        }
    }
    private void StartAttacking()
    {
        _isAttacking = true;
        _player.attackPlayer.isAttacking = true;
    }
    private void StopAttacking()
    {
        _isAttacking= false;
        _player.attackPlayer.isAttacking = false;
    }

}
