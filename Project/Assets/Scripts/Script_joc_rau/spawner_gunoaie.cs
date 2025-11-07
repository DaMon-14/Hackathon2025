using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class spawner_gunoaie : MonoBehaviour
{
    public GameObject gunoi;
    int spriteIndex;
    public float rate = 2;
    private float contor = 0;
    public float offset_h = 10;
    public GameObject sac=new GameObject();
    int viu = 1;
    int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float pct_min = transform.position.x - offset_h;
        float pct_max = transform.position.x + offset_h;


        if (contor <= rate)
        {


            contor = contor + Time.deltaTime;
        }
        else
        {
            Sprite[] blueSprites = Resources.LoadAll<Sprite>("Card/0");
            Sprite[] greenSprites = Resources.LoadAll<Sprite>("Card/1");
            Sprite[] yellowSprites = Resources.LoadAll<Sprite>("Card/2");
            Sprite[] brownSprites = Resources.LoadAll<Sprite>("Card/3");
            Sprite[] blackSprites = Resources.LoadAll<Sprite>("Card/4");

            spriteIndex = UnityEngine.Random.Range(0, 5);
            SpriteRenderer gunoirenderer = gunoi.GetComponent<SpriteRenderer>();

            if (spriteIndex == 0)
                gunoirenderer.sprite = blueSprites[UnityEngine.Random.Range(0, blueSprites.Length)];
            else if (spriteIndex == 1)
                gunoirenderer.sprite = greenSprites[UnityEngine.Random.Range(0, greenSprites.Length)];
            else if (spriteIndex == 2)
                gunoirenderer.sprite = yellowSprites[UnityEngine.Random.Range(0, yellowSprites.Length)];
            else if (spriteIndex == 3)
                gunoirenderer.sprite = brownSprites[UnityEngine.Random.Range(0, brownSprites.Length)];
            else if (spriteIndex == 4)
                gunoirenderer.sprite = blackSprites[UnityEngine.Random.Range(0, blackSprites.Length)];

            Instantiate(gunoi, new Vector3(UnityEngine.Random.Range(pct_min, pct_max), transform.position.y, 0), transform.rotation);
            contor = 0;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (gunoi.transform.position.y == sac.transform.position.y && gunoi.transform.position.x == sac.transform.position.x)
        {
            viu = 0;
            Destroy(gameObject);
            score++;


        }
    }


}