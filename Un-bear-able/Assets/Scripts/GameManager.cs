using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ItemManager itemManager;
    public TileManager tileManager;

    public int curDay;
    public int cropInventory;
    public ItemData selectedCropToPlant;

    public event UnityAction onNewDay;

    void OnEnable()
    {
        Item.onPlantCrop += OnPlantCrop;
        Item.onHarvestCrop += OnHarvestCrop;
    }

    void OnDisable()
    {
        Item.onPlantCrop -= OnPlantCrop;
        Item.onHarvestCrop -= OnHarvestCrop;
    }

    private void Awake()
    {
        if(instance != null && instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        itemManager = GetComponent<ItemManager>();
        tileManager = GetComponent<TileManager>();
    }

    public void OnPlantCrop (ItemData item)
    {
        cropInventory--;
    }

    //public bool CanPlantCrop (ItemData item)
    //{
       // Debug.Log("ERROR");
    //}

    public void OnHarvestCrop (ItemData item)
    {

    }
}
