using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DifficultyUI : MonoBehaviour
{
    [SerializeField] PointerEventHandler _difficultyUpButton;
    [SerializeField] PointerEventHandler _difficultyDownButton;
    [SerializeField] TextMeshProUGUI _difficultyText;

    private void Awake()
    {
        GetComponent<IPointerClickHandler>();
    }

}
