using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameObjectPooled
{
    void OnObjectSpawn();

    ObjectPool Pool { get; set; }
}
