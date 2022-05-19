using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameObjectPooled
{
    ObjectPool Pool { get; set; }
}
