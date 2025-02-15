using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FindableObject : MonoBehaviour
{
    private static Dictionary<Type, HashSet<Component>> _componentDict = new();

    private Component[] _components;

    private void Awake()
    {
        _components = GetComponents<Component>();
        foreach (var component in _components)
        {
            var key = component.GetType();
            if (!_componentDict.ContainsKey(key))
            {
                _componentDict.Add(key, new());
            }
            _componentDict[key].Add(component);
        }
    }

    private void OnDestroy()
    {
        foreach (var component in _components)
        {
            var key = component.GetType();
            if (_componentDict.TryGetValue(key, out var hashSet))
            {
                hashSet.Remove(component);
                if (hashSet.Count == 0)
                {
                    _componentDict.Remove(key);
                }
            }
        }
    }

    public static TComponent[] Get<TComponent>() where TComponent : Component
    {
        if (_componentDict.TryGetValue(typeof(TComponent), out var hashSet))
        {
            var result = new TComponent[hashSet.Count];
            hashSet.CopyTo(result);
            return result;
        }
        return Array.Empty<TComponent>();
    }
}
