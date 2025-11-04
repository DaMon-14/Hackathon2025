using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Card_Manager_old : MonoBehaviour
{
    Vector3 outPos = new Vector3(0, 8, 0);
    public int score = 0;
    public static int rows = 4;
    public static int cols = 5;
    GameObject[ , ] cards = new GameObject[cols, rows];
    GameObject cardModel;
    private GameObject[] selectedCards;
    public int waitTime = 3000;
    private int[] cardTypesIndex = new int[5]; // 0-blue 1-green 2-yellow 3-brown 4-black
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text remainingAttemptsText;
    public int attempts = 15;

    private float elapsedTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardModel = new GameObject();
        scoreText.text = "Score: 0";
        remainingAttemptsText.text = "Attempts Left: "+ attempts.ToString();
        Sprite[] blueSprites = Resources.LoadAll<Sprite>("Card/0");
        Sprite[] greenSprites = Resources.LoadAll<Sprite>("Card/1");
        Sprite[] yellowSprites = Resources.LoadAll<Sprite>("Card/2");
        Sprite[] brownSprites = Resources.LoadAll<Sprite>("Card/3");
        Sprite[] blackSprites = Resources.LoadAll<Sprite>("Card/4");
        Transform child;
        cardTypesIndex = new int[5] { 0, 0, 0, 0, 0 };
        selectedCards = new GameObject[2] { null, null };
        cardModel = GameObject.Find("Card_Model");
        for (int i =0;i< cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                string cardName = "card_" + i.ToString() + "_" + j.ToString();
                cards[i,j] = Instantiate(cardModel, new Vector3(i*3.0f -6 , j*2.0f-3, -0.1f), Quaternion.identity);
                cards[i,j].name = cardName;
                child = cards[i,j].transform.Find("Front");
                if (child != null)
                {
                    SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();
                    int spriteIndex;
                    do
                    {
                        spriteIndex = Random.Range(0, 5); // 0-blue 1-green 2-yellow 3-brown 4-black
                    }while(cardTypesIndex[spriteIndex] >= 4);
                    cardTypesIndex[spriteIndex] += 1;
                    cards[i,j].GetComponent<card>().type = spriteIndex;

                    if (childRenderer != null)
                    {
                        if (spriteIndex == 0)
                            childRenderer.sprite = blueSprites[Random.Range(0, blueSprites.Length)];
                        else if (spriteIndex == 1)
                            childRenderer.sprite = greenSprites[Random.Range(0, greenSprites.Length)];
                        else if (spriteIndex == 2)
                            childRenderer.sprite = yellowSprites[Random.Range(0, yellowSprites.Length)];
                        else if (spriteIndex == 3)
                            childRenderer.sprite = brownSprites[Random.Range(0, brownSprites.Length)];
                        else if (spriteIndex == 4)
                            childRenderer.sprite = blackSprites[Random.Range(0, blackSprites.Length)];
                        Debug.Log("Child sprite set successfully!");
                    }
                    else
                    {
                        Debug.LogWarning("Child has no SpriteRenderer!");
                    }
                }
                else
                {
                    Debug.LogWarning("Child not found!");
                }
                
            }
        }
    }

    public async Task CardClicked(GameObject obj)
    {
        Debug.Log("Clicked" + obj.name);
        if (selectedCards[0] == null)
        {
            selectedCards[0] = obj;
            obj.GetComponent<card>().RotateToFront();
        }else if(selectedCards[1] == null && obj!= selectedCards[0])
        {
            selectedCards[1] = obj;
            Debug.Log("Two cards already selected");
            obj.GetComponent<card>().RotateToFront();
            if (selectedCards[0].GetComponent<card>().type == selectedCards[1].GetComponent<card>().type)
            {
                selectedCards[0].GetComponent<card>().MoveToPosition(outPos);
                await selectedCards[1].GetComponent<card>().MoveToPosition(outPos);
                Destroy(selectedCards[0]);
                Destroy(selectedCards[1]);
                scoreText.text = "Score: " + (++score).ToString();
                
            }
            else
            {
                Wait(1000);
                selectedCards[0].GetComponent<card>().RotateToBack();
                Wait(1000);
                selectedCards[1].GetComponent<card>().RotateToBack();
                remainingAttemptsText.text = "Attempts Left: " + (--attempts).ToString();
            }
            selectedCards = new GameObject[2] { null, null };
        }
    }

    private void Wait(int milliseconds)
    {
        float targetTime = elapsedTime + (milliseconds / 1000.0f);
        while(elapsedTime < targetTime)
        {
            elapsedTime += Time.deltaTime;
        }
        return;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
    }
}
