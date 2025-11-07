using System.Net.Sockets;
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
        if ( Keyboard.current.dKey.isPressed)
        {
             transform.position = new Vector3(
                transform.position.x + moveDistance,
                transform.position.y ,
                transform.position.z
            );
        }
        if (Keyboard.current.aKey.isPressed)
        {
            square.transform.position = new Vector3(
                transform.position.x - moveDistance,
                transform.position.y,
                transform.position.z
            );
        }

        if (square.transform.position.x < -6)
        {
            square.transform.position = new Vector3(-6,transform.position.y,transform.position.z);
        }
        else
        {
            square.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (square.transform.position.x>6)
        {
            square.transform.position = new Vector3(6, transform.position.y, transform.position.z);
        }
        else
        {
            square.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }

    }
}
