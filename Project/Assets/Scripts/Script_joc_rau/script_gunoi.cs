using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class script_gunoi : MonoBehaviour
{
    public GameObject spawn;
    public float viteza = 2f;
    public float deadzone = -3f;
    public int type;
    public int score_int = 0;
    // Update is called once per frame
    public GameObject audio;

    void Update()
    {
        if (gameObject.name != "gunoi")
        {
            transform.position = transform.position + (Vector3.down * viteza) * Time.deltaTime;
        }
        
        if (transform.position.y < deadzone)
        {
            audio.GetComponent<script_manageraudio_rau>().fgresit();
            spawn.GetComponent<spawner_gunoaie>().scadere();
            Destroy(gameObject);
            
        }

       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(type==collision.gameObject.GetComponent<script_sac>().type)
        {
            audio.GetComponent<script_manageraudio_rau>().fcorect();
            Destroy(gameObject);
            spawn.GetComponent<spawner_gunoaie>().adaugare();
            
           
        }
        else
        {
            audio.GetComponent<script_manageraudio_rau>().fgresit();
            Destroy(gameObject);
            spawn.GetComponent<spawner_gunoaie>().scadere();
           
        }   

          
    }
}
