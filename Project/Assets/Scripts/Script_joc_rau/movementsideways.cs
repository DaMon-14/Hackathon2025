using System.Net.Sockets;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class test : MonoBehaviour
{
    public float moveDistance = 0.1f;
    public float movementZone = 6f;

    void Update()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position = new Vector3(transform.position.x, -2.88f, 0);
        if ( Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
             transform.position = new Vector3(
                transform.position.x + moveDistance,
                transform.position.y ,
                transform.position.z
            );
        }
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            transform.position = new Vector3(
                transform.position.x - moveDistance,
                transform.position.y,
                transform.position.z
            );
        }

        if (transform.position.x < -movementZone)
        {
            transform.position = new Vector3(-movementZone,transform.position.y,transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x>movementZone)
        {   
            transform.position = new Vector3(movementZone, transform.position.y, transform.position.z);
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
