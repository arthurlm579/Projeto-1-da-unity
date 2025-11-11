using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject bandeiraVermelha;
    public GameObject bandeiraVerde;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Troca as bandeiras
            bandeiraVermelha.SetActive(false);
            bandeiraVerde.SetActive(true);

            // Salva posição do checkpoint
            other.GetComponent<PlayerRespawn>().SetCheckpoint(transform.position);
        }
    }
}
