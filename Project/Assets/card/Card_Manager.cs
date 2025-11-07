using Unity.VisualScripting;
using UnityEngine;

public class Card_Manager : MonoBehaviour
{
    public int score = 0;
    public static int rows = 4;
    public static int cols = 5;
    GameObject[,] cards = new GameObject[cols, rows];
    GameObject[,] nullCardsArray = new GameObject[cols, rows]; 
    private GameObject cardModel;
    private GameObject[] selectedCards;

    private int[] cardTypesIndex = new int[5]; // 0-blue 1-green 2-yellow 3-brown 4-black

    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text remainingAttemptsText;
    public int attempts = 15;

    public float startTime;
    public float currentTime;
    public float waitTime = 1.0f;

    private bool rotateBack = false;

    public bool selectedCardsIsFull = false;
    public bool allCardsCleared = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardModel = new GameObject();
        scoreText.text = "Score: 0";
        remainingAttemptsText.text = "Attempts Left: " + attempts.ToString();
        Sprite[] blueSprites = Resources.LoadAll<Sprite>("Card/0");
        Sprite[] greenSprites = Resources.LoadAll<Sprite>("Card/1");
        Sprite[] yellowSprites = Resources.LoadAll<Sprite>("Card/2");
        Sprite[] brownSprites = Resources.LoadAll<Sprite>("Card/3");
        Sprite[] blackSprites = Resources.LoadAll<Sprite>("Card/4");
        Transform child;
        selectedCards = new GameObject[2] { null, null };
        cardTypesIndex = new int[5] { 0, 0, 0, 0, 0 };
        cardModel = GameObject.Find("Card_Model");
        nullCardsArray = new GameObject[cols, rows];
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                string cardName = "card_" + i.ToString() + "_" + j.ToString();
                cards[i, j] = Instantiate(cardModel, new Vector3(i * 3.0f - 6, j * 2.0f - 3.5f, -0.1f), Quaternion.identity);
                cards[i, j].name = cardName;
                
                child = cards[i, j].transform.Find("Front");
                if (child != null)
                {
                    SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();
                    int spriteIndex;
                    do
                    {
                        spriteIndex = Random.Range(0, 5); // 0-blue 1-green 2-yellow 3-brown 4-black
                    } while (cardTypesIndex[spriteIndex] >= 4);
                    cardTypesIndex[spriteIndex] += 1;
                    cards[i, j].GetComponent<Card>().type = spriteIndex;
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
                    }
                }
            }
        }
    }

    public void CardClicked(GameObject card)
    {
        if (selectedCards[0] == null)
        {
            selectedCards[0] = card;
        }else if(selectedCards[1] == null && card != selectedCards[0])
        {
            selectedCards[1] = card;
            Debug.Log("Two cards selected");
            startTime = Time.time;
            currentTime = startTime;
            rotateBack = true;
            selectedCardsIsFull = true;
        }
    }

    void Update()
    {
        if (rotateBack)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= startTime + waitTime)
            {
                if (selectedCards[0] != null && selectedCards[1] != null)
                {
                    selectedCardsIsFull = false;
                    if (GameObject.Find(selectedCards[0].name).GetComponent<Card>().type == GameObject.Find(selectedCards[1].name).GetComponent<Card>().type)
                    {
                        // Match found
                        GameObject.Find(selectedCards[0].name).GetComponent<Card>().moveToDelete = true;
                        GameObject.Find(selectedCards[1].name).GetComponent<Card>().moveToDelete = true;
                        score++;
                        scoreText.text = "Score: " + score.ToString();
                    }
                    else
                    {
                        // No match
                        GameObject.Find(selectedCards[0].name).GetComponent<Card>().flipToBack = true;
                        GameObject.Find(selectedCards[1].name).GetComponent<Card>().flipToBack = true;
                        attempts -= 1;
                        remainingAttemptsText.text = "Attempts Left: " + attempts.ToString();
                    }
                    selectedCards = new GameObject[2] { null, null };

                }
                rotateBack = false;
            }
        }
        
        if (AllNull(cards) == true)
        {
            Debug.Log("All cards cleared!");
            allCardsCleared = true;
        }
    }
    private bool AllNull(GameObject[,] objects)
    {
        foreach (var obj in objects)
        {
            if (obj != null)
                return false;
        }
        return true;
    }
}
