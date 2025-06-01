using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utile 
{

    public static Color StringToColor(string code)
    {
        Color color;
        
        ColorUtility.TryParseHtmlString(code, out color);

        return color;
    }

    public static Quaternion Direction2Rotation(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0, 0, angle);
    }


    public static Vector3 MousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public static float MouseX()
    {
        return MousePosition().x;
    }
    public static float MouseY()
    {
        return MousePosition().y;
    }


    public static int RandomNumber(int min, int max)
    {
        return UnityEngine.Random.Range(min, max + 1);
    }
    public static float RandomNumber(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }
    public static T RandomElement<T>(IEnumerable<T> collection)
    {
        int count = collection.Count();

        int randomIndex = UnityEngine.Random.Range(0, count);

        T result = collection.ElementAt(randomIndex);

        return result;
    }
    

    public static void StartScene(Enum scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public static GameObject FindGameObject(Enum name)
    {
        return GameObject.Find(name.ToString());
    }

    public static GameObject CreateClone(GameObject original)
    {
        GameObject go = GameObject.Instantiate(original);

        go.name = original.name;
        
        return go;
    }


    private static readonly Dictionary<(Type, string), object> s_resources = new();
    public static T LoadResource<T>(Enum pathEnum) where T : UnityEngine.Object
    {
        Type type = typeof(T);
        string name = pathEnum.ToString();
        string root = pathEnum.GetType().FullName;
        root = root.Replace('.', '/');
        root = root.Replace('+', '/');
        string path = root + '/' + name;

        if (s_resources.TryGetValue((type, path), out object saved))
            return saved as T; 

        T loaded = Resources.Load<T>(path);
        s_resources.Add((type, path), loaded);
        return loaded;
    }
    public static Sprite LoadSprite(Enum pathEnum)
    {
        return LoadResource<Sprite>(pathEnum);
    }
    public static GameObject LoadPrefab(Enum pathEnum)
    {
        return LoadResource<GameObject>(pathEnum);
    }

}

