using UnityEngine;

public class learn_script : MonoBehaviour
{

    public void SetKey(string key)
    {
        gameObject.GetComponent<LocalizedText>().key = key;
        gameObject.GetComponent<LocalizedText>().UpdateText();
    }

}
