using UnityEngine;
using UnityEngine.InputSystem;

public class script_sac : MonoBehaviour
{
    public float pasi=2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.rightArrowKey.isPressed)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x + pasi, transform.position.y, 0);

        }

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x - pasi, transform.position.y, 0);

        }
    }

   
}
