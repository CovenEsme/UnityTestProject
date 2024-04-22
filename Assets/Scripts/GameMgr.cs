using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    None,
    Init,
    Normal,
    End,
    Restart,
}

public class GameMgr : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float restartDelay = 3f;

    private GameState currentGameState = GameState.None;
    private GameState previousGameState;

    private void Awake()
    {
        SetState(GameState.Init);
    }

    private void Start()
    {
        player = Instantiate(player, new Vector3(0f, 1f, 0f), Quaternion.identity);
        SetState(GameState.Normal);
    }

    private void Update()
    {
        if (currentGameState != previousGameState)
        {
            previousGameState = currentGameState;

            switch (currentGameState)
            {
                case GameState.None:
                    break;
                case GameState.Init:
                    break;
                case GameState.Normal:
                    break;
                case GameState.End:
                    Debug.Log("GAME OVER!");
                    SetState(GameState.Restart);
                    break;
                case GameState.Restart:
                    Invoke("Restart", restartDelay);
                    break;
                default:
                    break;
            }

        }
    }

    private void Restart()
    {
        SetState(GameState.Init);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public GameState GetState()
    {
        return currentGameState;
    }

    public void SetState(GameState newGameState)
    {
        if (currentGameState == newGameState)
        {
            return;
        }

        currentGameState = newGameState;
        Debug.Log($"New GameState: {currentGameState}");
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
