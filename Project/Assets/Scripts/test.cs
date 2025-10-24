using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class test : MonoBehaviour
{
    public float moveDistance = 0.1f;
    void Update()
    {
        // Detect Space key press (once per press)
        if ( Keyboard.current.sKey.isPressed)
        {
             transform.position = new Vector3(
                transform.position.x,
                transform.position.y + moveDistance,
                transform.position.z
            );
        }
    }
}
