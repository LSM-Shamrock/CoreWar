using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DifficultyUI : UIBase
{
    PointerEventHandler _difficultyUpButton;
    PointerEventHandler _difficultyDownButton;
    TextMeshProUGUI _difficultyText;

    private new void Awake()
    {
        base.Awake();

    }

}
