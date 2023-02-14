using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
    public ItemData data;
    private ItemData curCrop;
    private int plantDay;

    public SpriteRenderer sr;

    public static event UnityAction<ItemData> onPlantCrop;
    public static event UnityAction<ItemData> onHarvestCrop;

    public void Plant(ItemData item)
    {
        curCrop = item;
        plantDay = GameManager.instance.curDay;
        UpdateCropSprites();

        onPlantCrop?.Invoke(item);
    }

    public void NewDayCheck ()
    {
        UpdateCropSprites();
    }

    void UpdateCropSprites()
    {
        int cropProg = CropProgress();

        if(cropProg < curCrop.daysToGrow)
        {
            sr.sprite = curCrop.growProgressSprites[cropProg];
        }
        else
        {
            sr.sprite = curCrop.readyToHarvestSprite;
        }
    }

    public void Harvest()
    {
        if(CanHarvest())
        {
            onHarvestCrop?.Invoke(curCrop);
            Destroy(gameObject);
        }
    }

    int CropProgress()
    {
        return GameManager.instance.curDay - plantDay;
    }

    public bool CanHarvest()
    {
        return CropProgress() >= curCrop.daysToGrow;
    }

    [HideInInspector] public Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

}
