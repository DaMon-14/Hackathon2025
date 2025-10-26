using UnityEngine;
using UnityEngine.InputSystem;

public class Item_Manager : MonoBehaviour
{
    public GameObject Item_Model;
    public float Spawn_Height = 10f;
    public float deviation = 2f;
    public float power_x=4f;
    public float[] power_y = new float[2] { 1.0f, 2.0f };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Spawn_Item();
    }

    void Spawn_Item()
    {
        float x_position = Random.Range(-deviation, deviation);
        Vector3 spawn_position = new Vector3(x_position, Spawn_Height, -0.1f);
        GameObject temp = Instantiate(Item_Model, spawn_position, Quaternion.identity);
        //temp.GetComponent<Rigidbody2D>().gravityScale = Random.Range(1.0f, 3.0f);
        temp.GetComponent<Rigidbody2D>().simulated = true;
        Vector2 impulseDirection = new Vector2(Random.Range(-power_x, power_x), Random.Range(power_y[0], power_y[1]));
        temp.GetComponent<Rigidbody2D>().AddForce(impulseDirection , ForceMode2D.Impulse);
    }
}
