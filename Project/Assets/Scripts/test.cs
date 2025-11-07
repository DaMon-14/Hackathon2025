using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class test : MonoBehaviour
{
    public float moveDistance = 0.1f;
    public GameObject square = new GameObject();
    
    void Update()
    {
        
        // Detect Space key press (once per press)
        if ( Keyboard.current.spaceKey.isPressed)
        {
             transform.position = new Vector3(
                transform.position.x,
                transform.position.y + moveDistance,
                transform.position.z
            );
        }

        if (square.transform.position.y <= -3)
        {
            square.transform.position = new Vector3(transform.position.x,-3,transform.position.z);
        }
        else
        {
            square.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (square.transform.position.y>5)
        {
            square.transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }
        else
        {
            square.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }

    }
}
