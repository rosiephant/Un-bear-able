using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class FurnitureInstance : MonoBehaviour
{   //public IGroupable ParentGroup { get; set; }
    public string DisplayName { get; private set; }
    public SOFurnitureDefinition.FurnitureType Type { get; private set; }

    private int CurrentValue;
    
    public void Initialize(string name, int cost, SOFurnitureDefinition.FurnitureType type)
    {
        DisplayName = name;
        CurrentValue = cost;
        Type = type; 
    }
}
