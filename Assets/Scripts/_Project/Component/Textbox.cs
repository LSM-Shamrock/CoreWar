using UnityEngine;
using UnityEngine.UI;

public class Textbox : MonoBehaviour
{
    private Image _image;
    private Text _text;

    private Image GetImage()
    {
        if (_image == null)
            _image = GetComponent<Image>();
        return _image;
    }
    private Text GetText()
    {
        if (_text == null)
            _text = GetComponentInChildren<Text>();
        return _text;
    }

    
    public string Text 
    { 
        get => GetText().text; 
        set => GetText().text = value; 
    }
    public Color TextColor 
    { 
        get => GetText().color; 
        set => GetText().color = value; 
    }
    public Color BackgroundColor 
    { 
        get => GetImage().color; 
        set => GetImage().color = value; 
    }
}
