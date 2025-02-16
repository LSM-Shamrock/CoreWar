using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComponentRegistry : MonoBehaviour
{
    private static Dictionary<Type, HashSet<Component>> _componentsByType = new();
    private Component[] _myComponents;

    private void Awake()
    {
        _myComponents = GetComponents<Component>();
        foreach (var component in _myComponents)
        {
            var key = component.GetType();
            if (!_componentsByType.ContainsKey(key))
            {
                _componentsByType.Add(key, new());
            }
            _componentsByType[key].Add(component);
        }
    }

    private void OnDestroy()
    {
        foreach (var component in _myComponents)
        {
            var key = component.GetType();
            if (_componentsByType.TryGetValue(key, out var hashSet))
            {
                hashSet.Remove(component);
                if (hashSet.Count == 0)
                {
                    _componentsByType.Remove(key);
                }
            }
        }
    }

    public static TComponent[] GetComponentsInRegistry<TComponent>() where TComponent : Component
    {
        if (_componentsByType.TryGetValue(typeof(TComponent), out var hashSet))
        {
            var result = new TComponent[hashSet.Count];
            hashSet.CopyTo(result);
            return result;
        }
        return Array.Empty<TComponent>();
    }

    public static TComponent[] GetComponentsInRegistry<TComponent>(Func<TComponent, bool> predicate) where TComponent : Component
    {
        return GetComponentsInRegistry<TComponent>().Where(predicate).ToArray();
    }
}
