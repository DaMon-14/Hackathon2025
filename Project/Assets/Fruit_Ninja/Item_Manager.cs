using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Item_Manager : MonoBehaviour
{
    public GameObject Item_Model;
    public float Spawn_Height = 10f;
    public float deviation = 2f;
    public float power_x=4f;
    public float[] power_y = new float[2] { 1.0f, 2.0f };

    public int score = 0;
    public int mistakes_left = 3;

    Sprite[] blueSprites;
    Sprite[] greenSprites;
    Sprite[] yellowSprites;
    Sprite[] brownSprites;
    Sprite[] blackSprites;

    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text mistakesLeftText;

    public float Spawn_Interval = 2f; // in seconds
    public float Spawn_Interval_Original = 2f;
    public float Last_Spawn_Time = 0f;
    public float Difficulty_Increase_Rate = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blueSprites = Resources.LoadAll<Sprite>("Fruit_Ninja/0");
        greenSprites = Resources.LoadAll<Sprite>("Fruit_Ninja/1");
        yellowSprites = Resources.LoadAll<Sprite>("Fruit_Ninja/2");
        brownSprites = Resources.LoadAll<Sprite>("Fruit_Ninja/3");
        blackSprites = Resources.LoadAll<Sprite>("Fruit_Ninja/4");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - Last_Spawn_Time > Spawn_Interval)
        {
            Last_Spawn_Time = Time.time;
            Spawn_Item();
        }
        if (Spawn_Interval > 0.5f)
            Spawn_Interval = Spawn_Interval_Original - Difficulty_Increase_Rate * score;

        scoreText.text = "Score: " + score.ToString();
        mistakesLeftText.text = "Mistakes Left: " + mistakes_left.ToString();
    }

    void Spawn_Item()
    {
        float x_position = Random.Range(-deviation, deviation);
        Vector3 spawn_position = new Vector3(x_position, Spawn_Height, -0.1f);
        GameObject temp = Instantiate(Item_Model, spawn_position, Quaternion.identity);
        int type = Random.Range(0, 5);// 0-blue 1-green 2-yellow 3-brown 4-black
        temp.GetComponent<Drag_script>().type = type;
        if (type == 0)
            temp.GetComponent<SpriteRenderer>().sprite = blueSprites[Random.Range(0, blueSprites.Length)];
        else if (type == 1)
            temp.GetComponent<SpriteRenderer>().sprite = greenSprites[Random.Range(0, greenSprites.Length)];
        else if (type == 2)
            temp.GetComponent<SpriteRenderer>().sprite = yellowSprites[Random.Range(0, yellowSprites.Length)];
        else if (type == 3)
            temp.GetComponent<SpriteRenderer>().sprite = brownSprites[Random.Range(0, brownSprites.Length)];
        else if (type == 4)
            temp.GetComponent<SpriteRenderer>().sprite = blackSprites[Random.Range(0, blackSprites.Length)];
        temp.GetComponent<Rigidbody2D>().simulated = true;
        Vector2 impulseDirection = new Vector2(Random.Range(-power_x, power_x), Random.Range(power_y[0], power_y[1]));
        temp.GetComponent<Rigidbody2D>().AddForce(impulseDirection , ForceMode2D.Impulse);
    }
}
