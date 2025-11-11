using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 checkpointPos;

    private void Start()
    {
        // Player começa na posição original
        checkpointPos = transform.position;
    }

    public void SetCheckpoint(Vector3 pos)
    {
        checkpointPos = pos;
    }

    public void Respawn()
    {
        transform.position = checkpointPos;
    }
}
