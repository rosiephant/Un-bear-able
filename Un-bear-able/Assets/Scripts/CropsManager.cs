using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropTile
{
    public int growTimer;
}

public class CropsManager : MonoBehaviour
{
    [SerializeField]
    TileBase plowed;
    [SerializeField]
    TileBase carrotSeeded;
    [SerializeField]
    TileBase potatoSeeded;
    [SerializeField]
    Tilemap targetTilemap;

    Dictionary<Vector2Int, CropTile> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, CropTile>();
    }

    public bool Check(Vector3Int position)
    {
        return crops.ContainsKey((Vector2Int)position);
    }

    public void Plow(Vector3Int position)
    {
        if (crops.ContainsKey((Vector2Int)position))
        {
            return;
        }

        CreatePlowedTile(position);

    }

    public void Seed(Vector3Int position)
    {
        targetTilemap.SetTile(position, carrotSeeded);

    }

    public void PotatoSeed(Vector3Int position)
    {
      targetTilemap.SetTile(position, potatoSeeded);
    }

    private void CreatePlowedTile(Vector3Int position)
    {
        CropTile crop = new CropTile();
        crops.Add((Vector2Int)position, crop);

        targetTilemap.SetTile((Vector3Int)position, plowed);
    }

}
