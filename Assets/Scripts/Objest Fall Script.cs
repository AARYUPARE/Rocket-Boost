using System;
using UnityEngine;

public class ObjestFallScript : MonoBehaviour
{
    [SerializeField] GameObject Obj;

    private void OnEnable()
    {
        Obj.gameObject.GetComponent<Rigidbody>().useGravity = false;
        Obj.gameObject.GetComponent<BoxCollider>().enabled = false;
        Obj.gameObject.GetComponent<AudioSource>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            RockFall();
        }
    }

    private void RockFall()
    {
        Obj.gameObject.GetComponent<Rigidbody>().useGravity = true;
        Obj.gameObject.GetComponent<AudioSource>().enabled = true;
        Obj.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
