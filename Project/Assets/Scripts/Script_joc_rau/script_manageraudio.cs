using UnityEngine;

public class script_manageraudio : MonoBehaviour
{
    [Header("-------Sursa audio------")]
    [SerializeField] AudioSource sursa_muzica;

    [Header("-------Sursa audio------")]
    [SerializeField] AudioSource sursa_fx;

    [Header("-------Clip audio----")]
    public AudioClip background;

    [Header("-------gunoi gresit----")]
    public AudioClip gresit;

    [Header("-------gunoi corect----")]
    public AudioClip corect;

    private void Start()
    {
        sursa_muzica.clip = background;
        sursa_muzica.Play();
        sursa_fx.clip = corect;
    }

    public void fgresit()
    {
        sursa_fx.clip = gresit;
        sursa_fx.Play();
    }

    public void fcorect()
    {
        sursa_fx.clip = corect;
        sursa_fx.Play();
    }

}
