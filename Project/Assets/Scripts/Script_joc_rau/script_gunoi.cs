using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class script_gunoi : MonoBehaviour
{
    public script_logica logica;
    public float viteza = 5;
    public float deadzone = -8;
    public GameObject sac;
    int viu = 1;
    int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * viteza) * Time.deltaTime;

        if (transform.position.y < deadzone)
        {
            Destroy(gameObject);
        }

    
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.transform.position.y == sac.transform.position.y && gameObject.transform.position.x == sac.transform.position.x)
        {
            viu = 0;
            Destroy(gameObject);
            score++;


        }
    }
}
