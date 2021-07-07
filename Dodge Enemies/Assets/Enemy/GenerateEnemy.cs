using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public GameObject theEnemy;
    public GameObject player;
    public GameObject jumpingEnemy;
    Rigidbody rb;
    public float xPos;
    public int zPos;
    public float zPoss;
    public int enemyCount;
    public int jumpyEnemy;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(EnemyDrop());
        
    }

    IEnumerator EnemyDrop(){
        while(enemyCount < 4){
            xPos = Random.Range(-2f, 7f);
            zPoss = player.transform.position.z;
            zPos = Random.Range((int)zPoss + 200, (int)zPoss + 300);
            Instantiate(theEnemy,new Vector3(xPos, 0.9f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount++;
        }
        while(jumpyEnemy < 4){
            xPos = Random.Range(-2f, 7f);
            zPoss = player.transform.position.z;
            zPos = Random.Range((int)zPoss + 350, (int)zPoss + 650);
            Instantiate(jumpingEnemy,new Vector3(xPos, 0.9f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            jumpyEnemy++;
        }
    }
}
