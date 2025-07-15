using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speechbubble : ObjectBase
{
    Text _text;
    Transform _master;
    public void Init(Transform master)
    { 
        _text = GetComponentInChildren<Text>(); 
        _master = master; 
    }
    public void Show(string text)
    {
        _text.text = text;
        UpdatePosition();
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false); 
    }
    protected void UpdatePosition()
    {
        if (_master == null)
            return;
        Vector3 half = ((RectTransform)transform).rect.size / 2f;
        Vector3 position = _master.position;
        Vector3 direction = new Vector3();
        direction.x = position.x < 0 ? 1 : -1;
        direction.y = position.y < 0 ? 1 : -1;
        position += Vector3.Scale(direction, half);
        position += Vector3.Scale(direction, new Vector3(20, 10));
        transform.position = position;
    }
    private void FixedUpdate()
    {
        if (_master == null)
            Destroy(gameObject);
        UpdatePosition();
    }
}
