using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileMap {
    [System.Serializable]
    public struct TileMapSettings {
        public Transform parent;
        
        [Space(10)]
        public int width;
        public int height;

        public Material mat;
    }

    TileMapSettings settings;

    Dictionary<Vector2Int, Chunk> chunks;
    List<Chunk> activeChunks;

    Vector2Int prevPlayerChunk = Vector2Int.zero;

    bool firstMove = true;


    public TileMap(TileMapSettings settings) {
        this.settings = settings;

        chunks = new Dictionary<Vector2Int, Chunk>();
        activeChunks = new List<Chunk>();
    }

    public void UpdateChunks(Vector3 viewerPos, int viewDist) {
        Vector2Int curChunk = new Vector2Int(
            (int)viewerPos.x / settings.width,
            (int)viewerPos.z / settings.height
        );
        
        //Player in same chunk, no need to update
        if (!firstMove && prevPlayerChunk == curChunk) {
            return;
        }

        if (firstMove) firstMove = false;
        
        
        //Disable all chunks before updating
        for (int i = 0; i < activeChunks.Count; i++) {
            activeChunks[i].SetActive(false);
        }
        activeChunks.Clear();
        
        
        for(int x = curChunk.x - viewDist; x < curChunk.x + viewDist; x++)
        {
            for (int y = curChunk.y - viewDist; y < curChunk.y + viewDist; y++) {
                Vector2Int chunkPos = new Vector2Int(x, y);
                
                //Create chunk if it doesn't exist
                if (!chunks.ContainsKey(chunkPos)) 
                {
                    chunks.Add(chunkPos, new Chunk(chunkPos, settings));
                }
                chunks[chunkPos].SetActive(true);
                activeChunks.Add(chunks[chunkPos]);
            }
        }
    }
}
