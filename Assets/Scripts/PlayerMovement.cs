using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputMgr inputMgr;
    Vector2 inputVec;

    [SerializeField] private PlayerCore playerCore;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forwardForce = 2000f;
    [SerializeField] private float sidewaysForce = 1000f;

    private float voidHeight = 3f;

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
        GameMgr gameMgr = playerCore.GetGameMgr();

        if (gameMgr.GetState() == GameState.Normal)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            Vector3 inputForce = new Vector3(inputVec.x * sidewaysForce, 0, 0) * Time.deltaTime;
            rb.AddForce(inputForce, ForceMode.VelocityChange);

            if (rb.position.y < -voidHeight || rb.position.y > voidHeight)
            {
                gameMgr.SetState(GameState.End);
            }
        } else if (gameMgr.GetState() == GameState.End)
        {
            enabled = false;
        }
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
