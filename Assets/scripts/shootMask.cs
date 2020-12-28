using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootMask : MonoBehaviour
{
    [SerializeField] protected KeyCode keyToPress;
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected Vector3 velocityOfSpawnedObject = new Vector3(0, 0, 10);

    protected GameObject spawnObject()
    {
        Vector3 positionOfSpawnedObject = transform.position + new Vector3(0, 0, 10); ;  // span at the containing object position.       
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);
        newObject.transform.position += velocityOfSpawnedObject;

        return newObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress)) prefabToSpawn = spawnObject();
        prefabToSpawn.transform.position += velocityOfSpawnedObject;

    }

    public void Destroyer(Collision collision)
    {
        if (collision.gameObject.tag == "Virus")
        {
            Destroy(collision.gameObject);
        }

    }
}
