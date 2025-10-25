using UnityEngine;
using UnityEngine.InputSystem;

public class Drag_script : MonoBehaviour
{
    private Camera cam;
    private Vector3 offset;
    private bool isDragged = false;
    private bool forceApplied = false;
    private Rigidbody2D rb;
    public Vector2 impulseDirection = Vector2.up;
    public float impulseStrength = 5f;
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 worldPos2D = new Vector2(worldPos.x, worldPos.y);

            RaycastHit2D hit = Physics2D.Raycast(worldPos2D, Vector2.zero);
        if (Mouse.current.leftButton.isPressed)
        {
            isDragged = true;
            forceApplied = false;
            // Raycast to detect clicked object
            

            if ((hit.collider != null && hit.collider.gameObject == gameObject) || isDragged == true)
            {
               transform.position = new Vector3(worldPos.x, worldPos.y, -0.1f);
            }
        }
        else
        {
            isDragged = false;
            if (!forceApplied)
            {
                rb.linearVelocity = Vector2.zero; // Reset velocity before applying impulse
                rb.AddForce(impulseDirection.normalized * impulseStrength, ForceMode2D.Impulse);
                forceApplied = true;
            }
            
        }
    }
}
