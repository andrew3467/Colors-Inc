using System;
using UnityEngine;

public class World : MonoBehaviour {
    public TileMap.TileMapSettings tileMapSettings;


    public Transform playerTransform;
    public int viewDist = 6;
    

    TileMap tileMap;


    void Awake() {
        tileMap = new TileMap(tileMapSettings);
    }

    void Update() {
        tileMap.UpdateChunks(playerTransform.position, viewDist);
    }
}
