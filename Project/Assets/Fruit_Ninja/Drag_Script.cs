using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SocialPlatforms.Impl;

public class Drag_script : MonoBehaviour
{
    private Camera cam;
    private Vector3 offset;
    private bool isDragged = false;
    private bool forceApplied = false;
    private Rigidbody2D rb;
    public float impulseStrength = 5f;

    Vector2 mousePos;
    RaycastHit2D hit;
    Vector3 worldPos;
    Vector2 worldPos2D;

    Vector2 oldWorldPos2D = Vector2.zero;

    private Vector2 impulse;
    public float maxImpulse = 20f;

    public int type; // 0-blue 1-green 2-yellow 3-brown 4-black
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos2D = new Vector2(worldPos.x, worldPos.y);
        if (Mouse.current.leftButton.isPressed)
        {
            hit = Physics2D.Raycast(worldPos2D, Vector2.zero);
            if((hit.collider != null && hit.collider.gameObject == gameObject))
            {
                isDragged = true;
            }
            if (isDragged)
            {
                forceApplied = false;
                transform.position = new Vector3(worldPos.x, worldPos.y, -0.1f);
            }
        }
        else
        {
            if (!forceApplied && isDragged)
            {
                Vector2 impulseDirection = (worldPos2D - oldWorldPos2D)/Time.deltaTime;
                impulse = impulseDirection * impulseStrength;
                if (impulse.x > maxImpulse || impulse.x<-maxImpulse) impulse = new Vector2(sign(impulse.x)* maxImpulse, impulse.y);
                if (impulse.y > maxImpulse || impulse.y<-maxImpulse) impulse = new Vector2(impulse.x, sign(impulse.y)* maxImpulse);
                rb.linearVelocity = Vector2.zero; // Reset velocity before applying impulse
                rb.linearVelocity = impulse;
                //rb.AddForce(impulseDirection * impulseStrength, ForceMode2D.Impulse);
                forceApplied = true;
            }
            isDragged = false;
            
        }
        oldWorldPos2D = worldPos2D;
    }

    private int sign(float value)
    {
        return value < 0 ? -1 : 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}");
        if(type.ToString() == collision.gameObject.tag)
        {
            GameObject.Find("Item_Manager").GetComponent<Item_Manager>().score += 1;
        }else if(collision.gameObject.tag == gameObject.tag)  
        {
            // Do nothing
        }
        else
        {
            GameObject.Find("Item_Manager").GetComponent<Item_Manager>().mistakes_left -= 1;
        }
        if (!(collision.gameObject.tag == gameObject.tag) || collision.gameObject.tag == "Fail_Area")
        {
            Destroy(gameObject);
        }
    }
}
