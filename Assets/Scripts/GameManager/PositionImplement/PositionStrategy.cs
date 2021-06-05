using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PositionStrategy
{
    PlayerPosition Initialize();

    void SoundInitialize();
}
