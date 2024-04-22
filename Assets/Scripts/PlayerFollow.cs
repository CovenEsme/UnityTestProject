using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private GameMgr gameMgr;
    [SerializeField] public Vector3 cameraOffset;

    // Update is called once per frame
    void Update()
    {
        transform.position = gameMgr.GetPlayer().transform.position + cameraOffset;
    }
}
