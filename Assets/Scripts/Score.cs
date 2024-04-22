using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private GameMgr gameMgr;
    [SerializeField] private TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameMgr.GetPlayer().GetComponent<PlayerCore>().GetPlayerScore().ToString();
    }
}
