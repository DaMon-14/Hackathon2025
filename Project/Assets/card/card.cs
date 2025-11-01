using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class card : MonoBehaviour
{
    public float rotationSpeed = 400f;
    public float moveSpeed = 5f;
    private Vector3 rotationAxis = new Vector3(0, 1, 0);
    public int type = 0; // Card type identifier
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Detect left mouse click (new Input System)
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Raycast to detect clicked object
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 worldPos2D = new Vector2(worldPos.x, worldPos.y);

            RaycastHit2D hit = Physics2D.Raycast(worldPos2D, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            { 
                GameObject.Find("Card_Manager").GetComponent<Card_Manager>().CardClicked(gameObject);
            }
        }

    }
    public async Task RotateToFront()
    {
        float angle = ReadCardAngle();
        while (angle < 180 && angle >= 0)
        {
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
            await Task.Delay(10);
            angle = ReadCardAngle();
        }
    }

    public async Task RotateToBack()
    {
        float angle = ReadCardAngle();
        while (angle <= 180 && angle > 0)
        {  
            transform.Rotate(rotationAxis, -rotationSpeed * Time.deltaTime);
            await Task.Delay(10);
            angle = ReadCardAngle();
        }
    }
    
    float ReadCardAngle()
    {
        float x;
        x= transform.eulerAngles.y;
        x= (x > 180) ? x - 360 : x; // Convert angle to range [-180, 180]
        x = x < -90 ? 180 : x < 0 ? 0 : x;
        transform.eulerAngles = new Vector3(0f, x, 0f);
        return x;
    }

    public async Task MoveToPosition(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            await Task.Delay(10);
        }
        transform.position = targetPosition; // Ensure exact position at the end
    }
}
