using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISofaFactory
{
    IFurniture CreateBaseSofa();
    IFurniture CreateRedSofa();
    IFurniture CreateBrownSofa();
    IFurniture CreateBlueSofa();
    IFurniture CreatePinkSofa();
}
