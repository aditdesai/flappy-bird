using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    BirdMovement birdMovement;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        birdMovement = GameObject.FindObjectOfType<BirdMovement>();
    }

    private void OnTriggerExit(Collider other)
    {
        birdMovement.ForwardForceMultiplier += 0.1f;
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2f);
    }

    
}
