using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemies : MonoBehaviour
{
    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        searchForEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void searchForEnemies()
    {
        Debug.Log("searchForEnemies()");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemies.Length > 0)
        {
            foreach(GameObject enemy in enemies)
            {
                Debug.Log("Enemy:" + enemy.name);
            }
        }
    }
}
