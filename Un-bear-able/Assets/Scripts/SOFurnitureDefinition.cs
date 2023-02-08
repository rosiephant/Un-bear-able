using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BearGame/FurnitureDefinition")]
public class SOFurnitureDefinition : ScriptableObject

{
    public enum FurnitureType
    {
        SOFA,
        BEDS,
        RUG
    }

    [SerializeField]
    private string displayName;
    [SerializeField]
    private Sprite displayIcon;
    [SerializeField]
    private int cost;
    [SerializeField]
    private FurnitureInstance prefab;
    [SerializeField]
    private FurnitureType type;

    public FurnitureInstance Spawn(Vector2 position)
    {
        FurnitureInstance instance = GameObject.Instantiate(prefab, position, Quaternion.identity);
        instance.Initialize(displayName, cost, type);
        return instance;
    }
    
    public string GetName()
    {
    return displayName;
    }

    public int GetCost()
    {
        return cost;
    }

    public Sprite GetIcon()
    {
        return displayIcon;
    }
}
