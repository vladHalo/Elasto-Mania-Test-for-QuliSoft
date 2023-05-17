using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _movement;
    [SerializeField] private Button _btn;
    [SerializeField] private Sprite[] _touchSprites;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _gameManager._playerMove.movement = _movement;
        _btn.image.sprite = _touchSprites[0];
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _gameManager._playerMove.movement = 0;
        _btn.image.sprite = _touchSprites[1];
    }
}