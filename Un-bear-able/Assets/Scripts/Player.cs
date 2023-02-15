using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
	[SerializeField]
	CropsManager cropsManager;
	[SerializeField]
	MarkerManager markerManager;
	[SerializeField]
	TilemapReader tileMapReader;
	[SerializeField]
	float maxDistance = 2f;
	[SerializeField]
	TileData plowableTiles;

	Vector3Int selectedTilePosition;
	bool selectable;

	public Inventory inventory;

	private void Awake()
	{
		inventory = new Inventory(21);
	}

	private void Update()
	{
		SelectTile();
		CanSelectCheck();
		Marker();

		if (Input.GetMouseButtonDown(0))
		{
			UseToolGrid();
		}
	}

	private void SelectTile()
    {
		selectedTilePosition = tileMapReader.GetGridPosition(Input.mousePosition, true);
    }

	void CanSelectCheck()
    {
		Vector2 playerPosition = transform.position;
		Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		selectable = Vector2.Distance(playerPosition, cameraPosition) < maxDistance;
		markerManager.Show(selectable);
    }

	private void Marker()
    {
		markerManager.markedCellPosition = selectedTilePosition;
    }

	public void DropItem(Item item)
	{
		Vector2 spawnLocation = transform.position;

		Vector2 spawnOffset = Random.insideUnitCircle * 1.25f;

		Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

		droppedItem.rb2d.AddForce(spawnOffset * 0.2f, ForceMode2D.Impulse);
	}

	private void UseToolGrid()
    {
		if(selectable == true)
        {
			cropsManager.Seed(selectedTilePosition);
		}
		else
		{
			cropsManager.Plow(selectedTilePosition);
		}
	}
}


