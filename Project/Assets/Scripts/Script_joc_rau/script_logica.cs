using System.Net.Sockets;
using UnityEngine;

public class script_logica : MonoBehaviour
{
    public GameObject gunoi;
    public GameObject sac;
    int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        int viu = 1;
        if (gunoi.transform.position.y == sac.transform.position.y && gunoi.transform.position.x == sac.transform.position.x)
        {
            viu = 0;
            Destroy(gunoi);
            score++;


        }
    }
}
