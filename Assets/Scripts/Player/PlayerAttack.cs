using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;//where is mouse
        //where is our screen
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        //Mathf.Atan we ne
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        Vector2 direction = transform.position - playerScreenPoint;
        
    }
    public void Shoot()
    {
        Vector3 mousePos = Input.mousePosition;//where is mouse
        //where is our screen
        mousePos = Camera.main.WorldToScreenPoint(mousePos);

        //Mathf.Atan we ne
        //float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        
        Vector3 direction = transform.position - mousePos;

        var angle = Vector2.SignedAngle(transform.position, mousePos);
        
        Debug.Log(angle);
        Instantiate(bullet.gameObject, transform.position, Quaternion.Euler(0,0,angle));
        
    }




}
