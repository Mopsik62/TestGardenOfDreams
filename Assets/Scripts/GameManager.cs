using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public int enemyCount;

    [SerializeField] private Tilemap floorTilemap;
    [SerializeField] private Tilemap obstacleTilemap;
    [SerializeField] private Tilemap wallTilemap;


    public void Initialize()
    {
        BoundsInt bounds = floorTilemap.cellBounds;

        List<Vector3Int> validSpawnPositions = new List<Vector3Int>();

        foreach (var position in bounds.allPositionsWithin)
        {
            if (floorTilemap.HasTile(position) && !obstacleTilemap.HasTile(position) && !wallTilemap.HasTile(position))
            {
                validSpawnPositions.Add(position);
            }
        }

        for (int i = 0; i < enemyCount; i++)
        {
            if (validSpawnPositions.Count > 0)
            {
                Vector3Int spawnPos = validSpawnPositions[Random.Range(0, validSpawnPositions.Count)];
                Vector3 worldPos = floorTilemap.CellToWorld(spawnPos);  
                Instantiate(enemy, worldPos, Quaternion.identity);  
            }
        }
    }
}
