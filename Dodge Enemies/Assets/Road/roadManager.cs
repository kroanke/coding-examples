using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadManager : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    public Transform playerTransform;
    [SerializeField] private float spawnZ = 0.0f;
    [SerializeField] private float roadLength = 150.0f;
    public int numberOfRoads = 5;
    private List<GameObject> activeRoads = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfRoads; i++){
            spawnRoad(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - 90 > spawnZ - (numberOfRoads * roadLength)){
            spawnRoad(0);
            DeleteRoad();
        }
    }

    public void spawnRoad(int roadIndex){
        GameObject gameObject = Instantiate(roadPrefabs[roadIndex], transform.forward * spawnZ, transform.rotation);
        activeRoads.Add(gameObject);
        spawnZ += roadLength;
    }
    private void DeleteRoad(){
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
    
}
