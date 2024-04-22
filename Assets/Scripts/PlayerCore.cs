using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private GameMgr gameMgr;
    private int playerScore;

    private void Start()
    {
        playerScore = 0;
    }

    private void Update()
    {
        // Only update the score while the game isn't over
        if (GetGameMgr().GetState() == GameState.Normal)
        {
            playerScore = (int)playerTransform.position.z;
        }
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public GameMgr GetGameMgr()
    {
        if (gameMgr == null)
        {
            gameMgr = FindObjectsOfType<GameMgr>()[0];
        }

        return gameMgr;
    }

}
