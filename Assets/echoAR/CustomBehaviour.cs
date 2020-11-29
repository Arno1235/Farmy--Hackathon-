/**************************************************************************
* Copyright (C) echoAR, Inc. 2018-2020.                                   *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echoar.xyz/terms, or another agreement                      *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;
    

    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>

    // Use this for initialization
    void Start()
    {
        
        // Add RemoteTransformations script to object and set its entry
        //this.gameObject.AddComponent<RemoteTransformations>().entry = entry;

        // Qurey additional data to get the name
        string value = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("name", out value))
        {
            // Set name
            this.gameObject.name = value;
            // Make invisible
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
            if ( value == "tileGrass")
            {
                TileManager tileManager = FindObjectOfType<TileManager>();
                this.gameObject.transform.Rotate(180, 0, 0);
                this.gameObject.transform.position = new Vector3(0, -0.01f, 0);
                GameObject grassTile = new GameObject();                
                tileManager.SetGrassObject(grassTile);
                tileManager.SetupGrass();
                this.gameObject.transform.localScale = new Vector3(1, 1, 1);                
            }
            if(value == "tileRoad")
            {
                TileManager tileManager = FindObjectOfType<TileManager>();
                tileManager.SetRoadObject(this.gameObject);
                tileManager.SetupRoad();
                
            }
            else if(value == "hunterCabin")
            {
                TowerManager towerManager = FindObjectOfType<TowerManager>();
                towerManager.SetHunterCabin(this.gameObject);
            }
            else if (value == "scareCrow")
            {
                TowerManager towerManager = FindObjectOfType<TowerManager>();
                towerManager.SetScareCrow(this.gameObject);
            }
            else if (value == "sprinkler")
            {
                TowerManager towerManager = FindObjectOfType<TowerManager>();
                towerManager.SetSprinkler(this.gameObject);
            }
            else if (value == "angryFarmer")
            {
                TowerManager towerManager = FindObjectOfType<TowerManager>();
                towerManager.SetAngryFarmer(this.gameObject);
            }
            else if (value == "grassHopper")
            {
                EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
                enemyManager.SetGrassHopper(this.gameObject);
            }
            else if (value == "bunny")
            {
                EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
                enemyManager.SetBunny(this.gameObject);
            }
            else if (value == "wolf")
            {
                EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
                enemyManager.SetWolf(this.gameObject);
            }
            else if (value == "bear")
            {
                EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
                enemyManager.SetBear(this.gameObject);
            }
            else if (value == "monkey")
            {
                EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
                enemyManager.SetMonkey(this.gameObject);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}