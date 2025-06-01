using System.Collections;
using UnityEngine;

public class Lobby_DifficultyText : ObjectBase
{
    private void Start()
    {
        Init();
    }

    Textbox _textbox;

    void Init()
    {
        _textbox = GetComponent<Textbox>();

        Difficulty = 1f;
        StartCoroutine(Loop_Update());
    }

    IEnumerator Loop_Update()
    {
        while (true)
        {
            _textbox.Text = $"난이도:{Difficulty:F2}";
            _textbox.BackgroundColor = Color.HSVToRGB(0f, 0f, 0.75f);

            Color textColor;
            switch (Difficulty)
            {
                case 1.5f:
                    textColor = new Color(1f, 0f, 0f);
                    break;

                case >= 1.25f:
                    textColor = new Color(0.5f, 0f, 0f);
                    break;

                case 0.75f:
                    textColor = new Color(1f, 1f, 0f);
                    break;

                default:
                    textColor = new Color(0f, 0f, 0f);
                    break;
            }
            _textbox.TextColor = textColor;

            yield return null;
        }
    }
}
