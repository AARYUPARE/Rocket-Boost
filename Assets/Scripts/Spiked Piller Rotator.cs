using UnityEngine;

public class SpikedPillerRotator : MonoBehaviour
{
    [SerializeField] float xAngle;
    void Update()
    {
        gameObject.transform.Rotate(xAngle, 0, 0);
    }
}
