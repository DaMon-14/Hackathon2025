using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class spawner_gunoaie : MonoBehaviour
{
    public Button exit;
    public GameObject sac;
    public GameObject gunoi;
    int spriteIndex;
    public float rate = 2;
    private float contor = 0;
    public float offset_h;
    private float pct_min;
    private float pct_max;
    public TMPro.TMP_Text vieti;
    public TMPro.TMP_Text score;
    public int score_int = 0;
    public int nr_vieti = 3;
    private string text_score;
    private string text_vieti;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset_h = GameObject.Find("sac").GetComponent<script_sac>().movementZone;
        pct_min = transform.position.x - offset_h;
        pct_max = transform.position.x + offset_h;
        text_score = score.text;
        score.text = text_score + score_int.ToString();
        text_vieti = vieti.text;
        vieti.text = text_vieti + nr_vieti.ToString();
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

    public void adaugare()
    {
        score_int = score_int + 1;
        score.text = text_score + score_int.ToString();
        if(score_int>10)
        {
            gunoi.GetComponent<script_gunoi>().viteza = gunoi.GetComponent<script_gunoi>().viteza + 0.3f;
        }
    }

    public void scadere()
    {
        nr_vieti = nr_vieti - 1;
        vieti.text = text_vieti + nr_vieti.ToString();
        if(nr_vieti<=0)
        {
            main_scene();
        }
    }

    public void main_scene()
    {
        SceneManager.LoadScene("CharacterCustomisation");
    }
}