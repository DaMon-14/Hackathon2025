using UnityEngine;

public class script_manageraudio : MonoBehaviour
{
    [Header("-------Sursa audio------")]
    [SerializeField] AudioSource sursa_muzica;

    [Header("-------Clip audio----")]
    public AudioClip background;


    private void Start()
    {
        sursa_muzica.clip = background;
        sursa_muzica.Play();
    }

}
