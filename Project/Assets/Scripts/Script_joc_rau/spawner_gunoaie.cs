using JetBrains.Annotations;
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
    public GameObject sac;
    public GameObject gunoi;
    int spriteIndex;
    public float rate = 2;
    private float contor = 0;
    public float offset_h;
    private float pct_min;
    private float pct_max;
    public int ct = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset_h = GameObject.Find("sac").GetComponent<script_sac>().movementZone;
        pct_min = transform.position.x - offset_h;
        pct_max = transform.position.x + offset_h;
    }

    // Update is called once per frame
    void Update()
    {
        if (contor <= rate)
        {
            contor = contor + Time.deltaTime;
        }
        else
        {
            Sprite[] blueSprites = Resources.LoadAll<Sprite>("joc_rau/0");
            Sprite[] greenSprites = Resources.LoadAll<Sprite>("joc_rau/1");
            Sprite[] yellowSprites = Resources.LoadAll<Sprite>("joc_rau/2");
            Sprite[] brownSprites = Resources.LoadAll<Sprite>("joc_rau/3");
            Sprite[] blackSprites = Resources.LoadAll<Sprite>("joc_rau/4");

            spriteIndex = UnityEngine.Random.Range(0, 5);
            SpriteRenderer gunoirenderer = gunoi.GetComponent<SpriteRenderer>();
            gunoi.GetComponent<script_gunoi>().type = spriteIndex;


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
}