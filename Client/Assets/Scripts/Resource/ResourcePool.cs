using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 资源缓存池
/// </summary>
public class ResourcePool
{
    protected Dictionary<string, UnityEngine.Object> dicCacheAssets;
    protected Dictionary<int, string> dicGuidKeys;

    public ResourcePool()
    {
        dicCacheAssets = new Dictionary<string, UnityEngine.Object>();
        dicGuidKeys = new Dictionary<int, string>();
    }

    public void AddCacheAsset(string path, UnityEngine.Object obj)
    {
        if (string.IsNullOrEmpty(path) || null == obj) {
            return;
        }
        if (dicCacheAssets.ContainsKey(path)) {
            return;
        }
        dicCacheAssets.Add(path, obj);
        dicGuidKeys.Add(obj.GetInstanceID(), path);
    }

    public void RemoveCacheAsset(UnityEngine.Object obj)
    {
        if (null == obj) {
            return;
        }
        int guid = obj.GetInstanceID();
        string path = string.Empty;
        if (dicGuidKeys.TryGetValue(guid, out path))
        {
            dicCacheAssets.Remove(path);
            dicGuidKeys.Remove(guid);
        }
    }

    public UnityEngine.Object GetCacheAsset(string path)
    {
        if (string.IsNullOrEmpty(path)) {
            return null;
        }
        UnityEngine.Object obj;
        if (dicCacheAssets.TryGetValue(path, out obj)) {
            return obj;
        }
        return null;
    }
}