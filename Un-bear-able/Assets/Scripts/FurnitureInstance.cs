using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class FurnitureInstance : MonoBehaviour
{
    public SOFurnitureDefinition.FurnitureType Type { get; private set; }
    private int CurrentValue;


}
