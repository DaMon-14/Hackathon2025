using System.Collections;
using UnityEngine;

public class card_rotate : MonoBehaviour
{
    public float rotationSpeed = 50f;
    private Vector3 rotationAxis = new Vector3(0, 1, 0);
    bool rotated = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float angle = transform.eulerAngles.y;
        if(angle <= 180 && rotated ==false)
        {
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
        }
        if(angle >= 180)
        {
            rotated = true;
        }
        StartCoroutine(Wait());
        if(angle >= 0 && rotated ==true)
        {
            transform.Rotate(rotationAxis, -rotationSpeed * Time.deltaTime);
        }
        if (angle <= 0)
        {
            rotated = false;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
    }
}
