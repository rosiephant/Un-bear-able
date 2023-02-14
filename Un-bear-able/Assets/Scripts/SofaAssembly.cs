using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaAssembly : ISofaFactory
{

    public IFurniture CreateBaseSofa()
    {
        return new BaseSofa();
    }

    public IFurniture CreateRedSofa()
    {
        return new RedSofa();
    }

    public IFurniture CreateBrownSofa()
    {
        return new BrownSofa();
    }

    public IFurniture CreateBlueSofa()
    {
        return new BlueSofa();
    }

    public IFurniture CreatePinkSofa()
    {
        return new PinkSofa();
    }

}

