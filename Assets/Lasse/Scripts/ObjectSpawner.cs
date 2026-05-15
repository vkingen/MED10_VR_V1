using UnityEngine;
public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    public void SpawnObject(Transform position)
    {
        GameObject clone = Instantiate(objectToSpawn);
        clone.transform.position = position.position;
    }
}


