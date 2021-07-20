using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform bird;
    public float yOffset;
    public float zOffset;
    
    private void Update()
    {
        transform.position = new Vector3(3f, bird.position.y + yOffset, bird.position.z + zOffset);
    }
}
