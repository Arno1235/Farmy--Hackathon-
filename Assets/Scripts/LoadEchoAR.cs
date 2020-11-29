using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using SimpleJSON;
using System.IO;
using System.Collections.Generic;
using AsImpL;
using Siccity.GLTFUtility;
using System.Globalization;
using UnityEngine.Video;

public class LoadEchoAR : MonoBehaviour
{
    private string type;
    private echoAR myEchoAR;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTile(Tile tile)
    {
        myEchoAR = new echoAR();
        if (tile.GetRoad())
        {
            type = "tileRoad";
        }
        else
        {
            type = "tileGrass";
        }
        myEchoAR.Start();
        
    }





    
}
