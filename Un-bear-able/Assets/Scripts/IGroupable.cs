using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGroupable
{

    IGroupable ParentGroup { get; set; }

    bool IsComposite();

    int GetValue();

    void AddToGroup(List<IGroupable> toAdd);

}
