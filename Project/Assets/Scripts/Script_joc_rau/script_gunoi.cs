using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class script_gunoi : MonoBehaviour
{
   
    public float viteza = 5;
    public float deadzone = -8;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name!="gunoi")
        transform.position = transform.position + (Vector3.down * viteza) * Time.deltaTime;

        if (transform.position.y < deadzone)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hitgunoi" + collision.gameObject.name);
        Destroy(gameObject);

    }
}
