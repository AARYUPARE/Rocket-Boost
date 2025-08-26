using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotate;
    [SerializeField] AudioClip MainEngine;
    [SerializeField] ParticleSystem MainThrustParticles;
    [SerializeField] ParticleSystem RightThrustParticles;
    [SerializeField] ParticleSystem LeftThrustParticles;

    Rigidbody rb;
    AudioSource thrust_sound;

    [SerializeField] float rotate_force = 1;      
    [SerializeField] float thrustPower = 20; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrust_sound = GetComponent<AudioSource>();

    }

    private void OnEnable()
    {
        thrust.Enable();
        rotate.Enable();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        float rotate_input = rotate.ReadValue<float>();
        if(rotate_input < 0)
        {
            RotateLeft(rotate_input);
        }
        else if(rotate_input > 0)
        {
            RotateRight(rotate_input);
        }
        else
        {
            StopRotating();
        }
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustPower * Time.fixedDeltaTime);
        if (!MainThrustParticles.isPlaying)
        {
            MainThrustParticles.Play();
        }
        if (!thrust_sound.isPlaying)
        {
            thrust_sound.PlayOneShot(MainEngine);
        }
    }

    private void StopThrusting()
    {
        thrust_sound.Stop();
        MainThrustParticles.Stop();
    }

    private void StopRotating()
    {
        RightThrustParticles.Stop();
        LeftThrustParticles.Stop();
    }

    private void RotateRight(float rotate_input)
    {
        if (!LeftThrustParticles.isPlaying)
        {
            LeftThrustParticles.Play();
        }
        ProcessRotation(rotate_input);
    }

    private void RotateLeft(float rotate_input)
    {
        if (!RightThrustParticles.isPlaying)
        {
            RightThrustParticles.Play();
        }
        ProcessRotation(rotate_input);
    }

    void ProcessRotation(float rotate_input)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * (-rotate_input) * rotate_force * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
