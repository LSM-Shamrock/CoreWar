using System.Collections;
using UnityEngine;

public class Lobby_PlayButton : ObjectBase
{
    Textbox _textbox;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _textbox = GetComponent<Textbox>();
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            yield return WaitForFixedUpdate();

            _textbox.BackgroundColor = Utile.RGB255(255, 200, 0);
            _textbox.TextColor = Utile.RGB255(255, 255, 255);
            if (IsMouseClicked && IsContactMousePointer)
            {
                transform.localScale = Vector3.one * 20.1f;
                yield return WaitUntil(() => !IsMouseClicked);
                transform.localScale = Vector3.one * 30.1f;
                if (IsContactMousePointer)
                {
                    _textbox.BackgroundColor = Utile.RGB255(128, 100, 0);
                    _textbox.TextColor = Utile.RGB255(128, 128, 128);
                    yield return WaitForSeconds(0.1f);
                    Utile.StartScene(Scenes.PlayScene.ToString());
                }
            }
        }
    }
}
