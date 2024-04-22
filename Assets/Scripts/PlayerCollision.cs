using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerCore playerCore;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            playerCore.GetGameMgr().SetState(GameState.End);
        }
    }
}
