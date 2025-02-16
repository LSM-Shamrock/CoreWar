using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DifficultyUI : MonoBehaviour
{
    PointerEventHandler _difficultyUpButton;
    PointerEventHandler _difficultyDownButton;
    TextMeshProUGUI _difficultyText;

    private void Awake()
    {
        GetComponentsInChildren<Transform>();
    }


    
}
