using UnityEngine;


public class MoveObjectsScript : MonoBehaviour
{
    [SerializeField] GameObject StoneGate1;
    [SerializeField] GameObject StoneGate2;
    [SerializeField] Vector3 StoneGate1EndPosition;
    [SerializeField] Vector3 StoneGate2EndPosition;
    [SerializeField] float MoveSpeed;
    [SerializeField] AudioClip DoorSound;

    [SerializeField] GameObject Oscillators;

    bool Triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Triggered = true;
            StoneGate1.GetComponent<AudioSource>().PlayOneShot(DoorSound, 2);
        }

    }

    private void Update()
    {
        if (Triggered)
        {
            StoneGate1.transform.position = Vector3.MoveTowards(StoneGate1.transform.position, StoneGate1EndPosition, Time.deltaTime * MoveSpeed);
            StoneGate2.transform.position = Vector3.MoveTowards(StoneGate2.transform.position, StoneGate2EndPosition, Time.deltaTime * MoveSpeed);

            if ((StoneGate1.transform.position == StoneGate1EndPosition) && (StoneGate2.transform.position == StoneGate2EndPosition))
            {
                Triggered = false;
                Destroy(gameObject);
                Oscillators.SetActive(true);
                StoneGate1.GetComponent<AudioSource>().Stop();

            }
        }
    }
}
