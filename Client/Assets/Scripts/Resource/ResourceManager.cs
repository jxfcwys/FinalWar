using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    //protected ResourceLoader resLoader = null;
    protected ResourcePool resPool = null;

    protected override void Initialize()
    {
        resPool = new ResourcePool();
    }
}