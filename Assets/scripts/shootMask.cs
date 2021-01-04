using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class shootMask : MonoBehaviour
{
    [SerializeField] protected KeyCode keyToPress;
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected Vector3 velocityOfSpawnedObject = new Vector3(0, 0, 10);
    [SerializeField] protected float lifeSpan= 3f;

    protected GameObject spawnObject()
    {
        Vector3 positionOfSpawnedObject = transform.position + new Vector3(0, 0, 10); ;  // span at the containing object position.       
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);
        Rigidbody instFoamRB = newObject.GetComponent<Rigidbody>();
        instFoamRB.AddForce(gameObject.transform.forward * velocityOfSpawnedObject.z);
        Destroy(newObject, lifeSpan);
        //newObject.transform.position += velocityOfSpawnedObject;

        return newObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress)) prefabToSpawn = spawnObject();
        prefabToSpawn.transform.position += velocityOfSpawnedObject;

    }

}
