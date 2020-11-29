using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int health;
    private int grain;
    // Start is called before the first frame update
    void Start()
    {
        health = 1000;
        grain = 3000;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SubstractHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //GAME OVER
        }
    }
    public void AddLoot(int loot)
    {
        grain += loot;
    }
}
