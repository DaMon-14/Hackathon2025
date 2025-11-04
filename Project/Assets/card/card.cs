using UnityEngine;
using UnityEngine.InputSystem;

public class Card : MonoBehaviour
{
    public float rotationSpeed = 400f;
    public float moveSpeed = 5f;
    private bool isHit = false;
    private bool frontFacingUp = false;
    public bool flipToBack = false;
    public bool moveToDelete = false;
    public int type = -1; // Card type identifier
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Raycast to detect clicked object
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 worldPos2D = new Vector2(worldPos.x, worldPos.y);

            RaycastHit2D hit = Physics2D.Raycast(worldPos2D, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log("Card clicked: " + gameObject.name);
                isHit = true;
            }
        }
        if(isHit)
        {
            if(GameObject.Find("Card_Manager").GetComponent<Card_Manager>().selectedCardsIsFull == false)
            {
                if (RotateToFront())
                {
                    isHit = false;
                    frontFacingUp = true;
                    GameObject.Find("Card_Manager").GetComponent<Card_Manager>().CardClicked(gameObject);
                }
            }
            else
            {
               isHit = false;
            }
        }
        if(frontFacingUp)
        {
            if (flipToBack)
            {
                if (RotateToBack())
                {
                    frontFacingUp = false;
                    flipToBack = false;
                }
            }
            if (moveToDelete)
            {
                if(MoveToPosition())
                {
                    moveToDelete = false;
                    Destroy(gameObject);
                }
            }
        }
    }

    bool MoveToPosition()
    {
        Vector3 targetPosition = new Vector3(0f, 6f, 0f); // Example target position
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        return Vector3.Distance(transform.position, targetPosition) < 0.001f;
    }

    bool RotateToFront()
    {
        float angle = ReadCardAngle();
        if (angle < 180 && angle >= 0)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            return false;
        }
        transform.eulerAngles = new Vector3(0f, 180f, 0f);
        return true;
    }

    bool RotateToBack()
    {
        float angle = ReadCardAngle();
        if (angle <= 180 && angle > 0)
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            return false;
        }
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        return true;
    }

    float ReadCardAngle()
    {
        float x;
        x = transform.eulerAngles.y;
        x = (x > 180) ? x - 360 : x; // Convert angle to range [-180, 180]
        x = x < -90 ? 180 : x < 0 ? 0 : x;
        transform.eulerAngles = new Vector3(0f, x, 0f);
        return x;
    }
}
