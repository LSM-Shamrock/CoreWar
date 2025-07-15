using System.Collections;
using UnityEngine;

public class Lobby_DifficultyControl : ObjectBase
{
    enum IncreaseType
    {
        Up,
        Down,
    }

    [SerializeField]
    IncreaseType _increaseType;

    private void Start()
    {
        StartCoroutine(Loop_ClickLogic());
    }

    IEnumerator Loop_ClickLogic()
    {
        while (true)
        {
            transform.localScale = Vector3.one * 20f;
            if (IsContactMousePointer)
            {
                transform.localScale = Vector3.one * 25f;
                if (IsClickedMouse)
                {
                    transform.localScale = Vector3.one * 20f;

                    switch (_increaseType)
                    {
                        case IncreaseType.Up: Difficulty += 0.05f; break;
                        case IncreaseType.Down: Difficulty -= 0.05f; break;
                    }
                    Difficulty = Mathf.Clamp(Difficulty, 0.75f, 1.5f);

                    yield return WaitUntil(() => !IsClickedMouse);
                }
            }
            yield return null;
        }
    }


}
