using UnityEngine;

public class CrusherInitiator : MonoBehaviour
{
    [SerializeField] GameObject First_Crusher;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            First_Crusher.GetComponent<Crusher>().enabled = true;
        }
    }
}
