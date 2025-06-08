using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class Utile 
{
    public static void StartScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static GameObject FindGameObject(string objectName)
    {
        return GameObject.Find(objectName);
    }

    public static GameObject CreateClone(GameObject original)
    {
        GameObject go = GameObject.Instantiate(original);
        go.name = original.name;
        return go;
    }


    public static bool CheckContactRigidbody(Collider2D collider, Enum checkRigidbodyName)
    {
        ContactFilter2D filter = new ContactFilter2D();
        List<Collider2D> cols = new List<Collider2D>();
        Physics2D.OverlapCollider(collider, filter.NoFilter(), cols);
        return cols.Any(c => c.attachedRigidbody != null && c.attachedRigidbody.gameObject.name == checkRigidbodyName.ToString());
    }

    // Polygon
    public static void AsyncPolygon(PolygonCollider2D polygonCollider, Sprite sprite)
    {
        if (polygonCollider == null)
            return;

        int shapeCount = sprite.GetPhysicsShapeCount();
        polygonCollider.pathCount = sprite.GetPhysicsShapeCount();
        for (int i = 0; i < shapeCount; i++)
        {
            List<Vector2> points = new();
            sprite.GetPhysicsShape(i, points);
            polygonCollider.SetPath(i, points);
        }
    }
    public static void SetSpriteAndAsyncPolygon(GameObject gameObject, Sprite sprite)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        PolygonCollider2D polygonCollider = gameObject.GetComponent<PolygonCollider2D>();
        spriteRenderer.sprite = sprite;
        AsyncPolygon(polygonCollider, sprite);
    }


    public static Quaternion Direction2Rotation(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0, 0, angle);
    }

    public static string Enum2Path(Enum pathEnum)
    {
        string root = pathEnum.GetType().FullName;
        root = root.Replace('.', '/');
        root = root.Replace('+', '/');
        string name = pathEnum.ToString();
        string path = root + '/' + name;
        return path;
    }


    // Mouse
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


    // Random
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


    // Load
    private static readonly Dictionary<(Type, string), object> s_resources = new();
    public static T LoadResource<T>(string path) where T : UnityEngine.Object
    {
        Type type = typeof(T);

        if (s_resources.TryGetValue((type, path), out object saved))
            return saved as T; 

        T loaded = Resources.Load<T>(path);
        s_resources.Add((type, path), loaded);
        return loaded;
    }


    // Color
    public static Color StringToColor(string code)
    {
        Color color;
        
        ColorUtility.TryParseHtmlString(code, out color);

        return color;
    }
    public static Color RGB255(int r, int g, int b)
    {
        return new Color(r / 255f, g / 255f, b / 255f);
    }

    // Effect
    public static void SetTransparency(ref Color color, float value)
    {
        color.a = 1f - value;
        color.a = Mathf.Clamp01(color.a);
    }
    public static void AddTransparency(ref Color color, float value)
    {
        color.a -= value;
        color.a = Mathf.Clamp01(color.a);
    }
    public static void SetBrightness(SpriteRenderer spriteRenderer, float value)
    {
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        spriteRenderer?.GetPropertyBlock(block);
        block.SetFloat("_Brightness", Mathf.Clamp(value, -1f, 1f));
        spriteRenderer?.SetPropertyBlock(block);
    }
    public static void AddBrightness(SpriteRenderer spriteRenderer, float value)
    {
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        spriteRenderer?.GetPropertyBlock(block);
        float current = block.GetFloat("_Brightness");
        float next = Mathf.Clamp(current + value, -1f, 1f);
        block.SetFloat("_Brightness", next);
        spriteRenderer?.SetPropertyBlock(block);
    }
    public static void SetBrightness(Image image, float value)
    {
        if (image == null) 
            return;
        Material material = GetMaterialInstanceByImage(image);
        material.SetFloat("_Brightness", Mathf.Clamp(value, -1f, 1f));
    }
    public static void AddBrightness(Image image, float value)
    {
        if (image == null) 
            return;
        Material material = GetMaterialInstanceByImage(image);
        float current = material.GetFloat("_Brightness");
        float next = Mathf.Clamp(current + value, -1f, 1f);
        material.SetFloat("_Brightness", next);
    }
    private static Material GetMaterialInstanceByImage(Image image)
    {
        if (image == null) 
            return null;
        
        if (image.material != null && image.material.name.EndsWith("(Instance)"))
        {
            return image.material;
        }
        else
        {
            image.material = new Material(image.material);
            return image.material;
        }
    }

}

