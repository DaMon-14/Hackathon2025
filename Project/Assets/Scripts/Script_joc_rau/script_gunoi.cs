using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class script_gunoi : MonoBehaviour
{
    public GameObject spawn;
    public float viteza = 5;
    public float deadzone = -8;
    public int type;
    public int score_int = 0;
    // Update is called once per frame


    void Update()
    {
        if (gameObject.name != "gunoi")
        {
            transform.position = transform.position + (Vector3.down * viteza) * Time.deltaTime;
        }
        
        if (transform.position.y < deadzone)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(type==collision.gameObject.GetComponent<script_sac>().type)
        {
            spawn.GetComponent<spawner_gunoaie>().adaugare();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }    

          
    }
}
