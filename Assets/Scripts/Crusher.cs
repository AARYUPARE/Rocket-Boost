using System;
using Unity.VisualScripting;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    Vector3 Post1;
    [SerializeField] Vector3 Post2;
    [SerializeField] float CrushSpeed;
    [SerializeField] float Angle;
    [SerializeField] float UpSpeed;
    [SerializeField] AudioClip CrushSound;
    [SerializeField] AudioClip RevertSound;
    [SerializeField] GameObject Next;
    [SerializeField] int StartCount;
    [SerializeField] float Reload_Volume;

    int PostCheck = 1;
    AudioSource sound;

    private void Start()
    {
        Post1 = transform.position;
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (PostCheck == 1)
        {
            GoDown();
        }
        else
        {
            GoUp();
        }
    }

    private void GoDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, Post2, Time.deltaTime * CrushSpeed);

        if(transform.position == Post2)
        {
            sound.PlayOneShot(CrushSound);
            if(StartCount == 1)
            {
                Next.GetComponent<Crusher>().enabled = true;
                StartCount = 0;
            }
            PostCheck = 2;
        }
    }

    private void GoUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, Post1, Time.deltaTime * UpSpeed);
        transform.Rotate(0, Angle, 0);

        if (!sound.isPlaying)
        {
            sound.PlayOneShot(RevertSound, Reload_Volume);
        }

        if(transform.position == Post1)
        {
            sound.Stop();
            PostCheck = 1;
        }

    }
}
