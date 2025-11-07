using System.Net.Sockets;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class script_sac : MonoBehaviour
{
    public float moveDistance = 0.1f;
    public float movementZone = 6f;
    SpriteRenderer sacrenderer;
    public int type;
    void Start()
    {
        sacrenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position = new Vector3(transform.position.x, -2.88f, 0);
        if (Keyboard.current.rightArrowKey.isPressed)
        {
             transform.position = new Vector3(
                transform.position.x + moveDistance,
                transform.position.y ,
                transform.position.z
            );
        }
        if (Keyboard.current.leftArrowKey.isPressed)
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

        Sprite[] saci = Resources.LoadAll<Sprite>("joc_rau/saci");
        if (Keyboard.current.aKey.isPressed)//sac negru
        {
            gameObject.GetComponent<script_sac>().type = 4;
            sacrenderer.sprite = saci[0];
        }

        if (Keyboard.current.sKey.isPressed)//sac albastru
        {
            gameObject.GetComponent<script_sac>().type = 0;
            sacrenderer.sprite = saci[1];
        }
        if (Keyboard.current.dKey.isPressed)//sac maro
        {
            gameObject.GetComponent<script_sac>().type = 3;
            sacrenderer.sprite = saci[2];
        }
        if (Keyboard.current.fKey.isPressed)//sac verde
        {
            gameObject.GetComponent<script_sac>().type = 1;
            sacrenderer.sprite = saci[3];
        }

        if (Keyboard.current.gKey.isPressed)//sac galben
        {
            gameObject.GetComponent<script_sac>().type =2;
            sacrenderer.sprite = saci[4];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit" + collision.gameObject.name);

    }

    
   
}