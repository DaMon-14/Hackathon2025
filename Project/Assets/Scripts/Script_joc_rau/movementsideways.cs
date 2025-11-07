using System.Net.Sockets;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class test : MonoBehaviour
{
    public float moveDistance = 0.1f;

    void Start()
    {

    }

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
            transform.position = new Vector3(
                transform.position.x - moveDistance,
                transform.position.y,
                transform.position.z
            );
        }

        if (transform.position.x < -6)
        {
            transform.position = new Vector3(-6,transform.position.y,transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x>6)
        {   
            transform.position = new Vector3(6, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit" + collision.gameObject.name);
    }
}
