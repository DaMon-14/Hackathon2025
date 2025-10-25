using System.Threading.Tasks;
using UnityEngine;

public class Card_Manager : MonoBehaviour
{
    public static int rows = 4;
    public static int cols = 5;
    GameObject[ , ] cards = new GameObject[cols, rows];
    GameObject cardModel = new GameObject();
    private GameObject[] selectedCards;
    public int waitTime = 3000;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectedCards = new GameObject[2] { null, null };
        cardModel = GameObject.Find("Card_Model");
        for (int i =0;i< cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                string cardName = "card_" + i.ToString() + "_" + j.ToString();
                cards[i,j] = Instantiate(cardModel, new Vector3(i*3.0f -6 , j*2.0f-3, -0.1f), Quaternion.identity);
                cards[i,j].name = cardName;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async Task CardClicked(GameObject obj)
    {
        Debug.Log("Clicked" + obj.name);
        if (selectedCards[0] == null)
        {
            selectedCards[0] = obj;
            await obj.GetComponent<card>().RotateToFront();
        }else if(selectedCards[1] == null)
        {
            selectedCards[1] = obj;
            Debug.Log("Two cards already selected");
            await obj.GetComponent<card>().RotateToFront();
            await Task.Delay(waitTime);
            selectedCards[0].GetComponent<card>().RotateToBack();
            await selectedCards[1].GetComponent<card>().RotateToBack();
            selectedCards = new GameObject[2] { null, null };
        }
    }
}
