using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint;

    void Start()
    {
        // Caso ainda não tenha batido em nenhum checkpoint,
        // o respawnPoint será onde o Player nasceu.
        respawnPoint = transform.position;
    }

    public void SetCheckpoint(Vector3 newPoint)
    {
        respawnPoint = newPoint;
    }

    public void RespawnPlayer()
    {
        transform.position = respawnPoint;
    }
}
