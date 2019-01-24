using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;




public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    Vector3 movement;
    InputDevice inputDevice;

    MyCharacterActions characterActions;

    public int rotateSpeed = 100;
    public int strafeSpeed = 1500;
    public int torque = 500;
    public int thrust = 100;
    private float thrustAxis = 0;
    private float brakeAxis = 0;
    private float strafeAxis = 0;

    // VISUAL FX
    public GameObject[] thrusters;

    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
        InControlBindings();

    }

    // Update is called once per frame
    void Update()
    {
        //var inputDevice = InputManager.ActiveDevice;
        inputDevice = InputManager.ActiveDevice;


        Move();
        Rotate();
        Strafe();

    }

    void Move()
    {
        //var inputDevice = InputManager.ActiveDevice;
        //float thrustAxis = inputDevice.RightTrigger;
        //float brakeAxis = inputDevice.LeftTrigger;
        rb.AddForce(transform.forward * characterActions.ThrustAxis * Time.deltaTime * thrust);

        foreach (GameObject thruster in thrusters) {
            ParticleSystem particle = thruster.GetComponent<ParticleSystem>();
            var emission = particle.emission;
            var limitVelocityOverLifetime = particle.limitVelocityOverLifetime;
            limitVelocityOverLifetime.drag = 1 - characterActions.ThrustAxis;
        }
    }

    void Rotate()
    {
        //var inputDevice = InputManager.ActiveDevice;
        rb.AddTorque(Vector3.up * Time.deltaTime * torque * characterActions.RotateAxis);
        //transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * inputDevice.LeftStickX);
    }

    void Strafe()
    {
        strafeAxis = inputDevice.RightStickX;
        rb.AddForce(transform.right * strafeAxis * strafeSpeed * Time.deltaTime);
    }

    void InitVariables()
    {
        rb = GetComponent<Rigidbody>();
        movement = new Vector3(0, 0, 0);
        inputDevice = InputManager.ActiveDevice;
        

    }

    void InControlBindings()
    {

        characterActions = new MyCharacterActions();

        characterActions.RotateLeft.AddDefaultBinding(InputControlType.LeftStickLeft);
        characterActions.RotateLeft.AddDefaultBinding(Key.A);

        characterActions.RotateRight.AddDefaultBinding(InputControlType.LeftStickRight);
        characterActions.RotateRight.AddDefaultBinding(Key.D);

        characterActions.Forward.AddDefaultBinding(InputControlType.RightTrigger);
        characterActions.Forward.AddDefaultBinding(Key.W);

        characterActions.Backwards.AddDefaultBinding(InputControlType.LeftTrigger);
        characterActions.Backwards.AddDefaultBinding(Key.S);




    }
}
