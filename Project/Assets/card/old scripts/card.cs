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

    float card_angle = 0;

    bool isHit = false;

    private float elapsedTime = 0;
    public float delay = 1f; // Delay in seconds
    float hitTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
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
                isHit = true;
                hitTime = elapsedTime;
                //GameObject.Find("Card_Manager").GetComponent<Card_Manager>().CardClicked(gameObject);
            }
        }
        if (isHit) 
        {
            
            RotateToFront();
            if(elapsedTime < hitTime + delay)
            {

            }
            else
            {
               RotateToBack();
            }
        }


    }

    void RotateCard(bool toFront)
    {
        float angle = ReadCardAngle();
        if (toFront && (angle < 180 && angle >= 0))
        {
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
            angle = ReadCardAngle();
        }
        else if(toFront && (angle <= 180 && angle > 0))
        {
            transform.Rotate(rotationAxis, -rotationSpeed * Time.deltaTime);
            //Wait(100);
            angle = ReadCardAngle();
            /*
            while (angle <= 180 && angle > 0)
            {
                
            }
            */
        }
        else 
        {
            isHit = false;
        }
    }

    public void RotateToFront()
    {
        RotateCard(true);
    }

    public void RotateToBack()
    {
        RotateCard(false);
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
            Wait(1000);
        }
        transform.position = targetPosition; // Ensure exact position at the end
    }

    private void Wait(int milliseconds)
    {
        float targetTime = elapsedTime + (milliseconds / 1000.0f);
        while (elapsedTime < targetTime)
        {
            elapsedTime += Time.deltaTime;
        }
        return;
    }
}
