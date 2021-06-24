using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItemTabStrategy
{
    void Refresh(List<ItemObject> itemObjects, Transform content);
}
