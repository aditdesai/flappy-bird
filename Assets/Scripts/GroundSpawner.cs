using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    public GameObject cylinder;
    private Vector3 nextCylinder = new Vector3(0f, 15f, 20f);
    private Vector3 offset = new Vector3(0f, 0f, 30f);
    private Vector3 nextSpawnPoint;

    private float prev = -10f;
    private int upperCylinderLimit = 7;

    private void SpawnCylinders()
    {
        for(int i = 1; i <= 6; ++i)
        {
            Instantiate(cylinder, nextCylinder, Quaternion.identity);
            //todo next random no shouldnt be same and increase upper limit gradually
            //sort out height of rocks
            offset.y = Random.Range(-5, 10);

            while(prev == offset.y)
                offset.y = Random.Range(-5, upperCylinderLimit);
            prev = offset.y;

            nextCylinder.y = 15f;
            nextCylinder += offset;
        }

        if(upperCylinderLimit < 11)
            upperCylinderLimit++;
    }

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(3).transform.position;
        SpawnCylinders();
    }
    void Start()
    {
        for (int i = 1; i <= 4; ++i)
        {
            SpawnTile();
        }
        
    }

    
}
