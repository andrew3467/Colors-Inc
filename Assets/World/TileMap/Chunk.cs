using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk {
    GameObject gameObject;

    public Chunk(Vector2Int pos, TileMap.TileMapSettings settings) {
        gameObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
        gameObject.name = pos.ToString();

        gameObject.transform.position = new Vector3(pos.x * settings.width,0, pos.y * settings.height);
        gameObject.transform.parent = settings.parent;
        gameObject.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f));

        gameObject.transform.localScale = new Vector3(settings.width, settings.height, 1);
        
        
        gameObject.GetComponent<MeshRenderer>().material = settings.mat;
        
        
        SetActive(false);
    }

    public void SetActive(bool active) {
        gameObject.SetActive(active);
    }
}
