using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed=10f;

    [SerializeField] private MouseFollow mouseFollow;
    [SerializeField] private GameObject mainVisuals;

    private void Update()
    {
        FlipSprite();
    }
    public void Move(Vector2 moveInput)
    {
        Vector3 delta = moveInput * movementSpeed * Time.deltaTime;
        transform.position += delta;
    }
    void FlipSprite()
    {
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        if (Input.mousePosition.x > playerScreenPoint.x)
        {
            mainVisuals.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }
        else if(Input.mousePosition.x < playerScreenPoint.x)
        {
            mainVisuals.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

}
