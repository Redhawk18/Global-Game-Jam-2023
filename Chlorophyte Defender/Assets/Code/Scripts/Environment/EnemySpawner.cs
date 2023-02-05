using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Vector2 position;
    [SerializeField] private float rate;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < rate)
        {
            timer += Time.deltaTime;
        } else {
            Vector3 position3d = new Vector3();
            position3d.x = position.x;
            position3d.y = position.y;
            position3d.z = 0; 
            Instantiate(enemy, new Vector3(position.x, position.y, 0), transform.rotation);
            timer = 0;
        }

    }  
}
