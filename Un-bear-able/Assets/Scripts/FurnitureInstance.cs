using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class FurnitureInstance : MonoBehaviour, IGroupable
{   public IGroupable ParentGroup { get; set; }
    public string DisplayName { get; private set; }
    public SOFurnitureDefinition.FurnitureType Type { get; private set; }

    [SerializeField]
    private NavMeshAgent agent;

    private int CurrentValue;
    
    public void Initialize(string name, int cost, SOFurnitureDefinition.FurnitureType type)
    {
        DisplayName = name;
        CurrentValue = cost;
        Type = type; 
    }

    public int GetValue()
    {
        return CurrentValue;
    }
 
    public bool IsComposite()
    {
        return false;
    }

    public void AddToGroup(List<IGroupable> toAdd)
    {
        Debug.LogError("SHOULD NEVER BE CALLED!");
    }
}
