using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputMgr inputMgr;
    Vector2 inputVec;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forwardForce = 2000f;
    [SerializeField] private float sidewaysForce = 1000f;

    // Awake is called before Start
    private void Awake()
    {
        inputMgr = new InputMgr();

        inputMgr.Gameplay.Movement.performed += context => inputVec = context.ReadValue<Vector2>();
        inputMgr.Gameplay.Movement.canceled += context => inputVec = Vector2.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        Vector3 inputForce = new Vector3(inputVec.x * sidewaysForce, 0, 0) * Time.deltaTime;
        rb.AddForce(inputForce, ForceMode.VelocityChange);
    }

    // InputMgr stuff
    private void OnEnable()
    {
        inputMgr.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputMgr.Gameplay.Disable();
    }
}
