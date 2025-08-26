using System;
using UnityEngine;

public class MoveMotherShip : MonoBehaviour
{
    [SerializeField] Transform Ship_Position;
    [SerializeField] Vector3 Ship_e_Position;

    bool Triggered = false;
    [SerializeField] float speed;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Triggered = true;
        }
    }

    void Update()
    {
        if(Triggered)
        {
            moveMotherShip();
        }
    }

    void moveMotherShip()
    {
        Ship_Position.transform.position = Vector3.MoveTowards(Ship_Position.transform.position, Ship_e_Position, Time.deltaTime * speed);
    }
}
