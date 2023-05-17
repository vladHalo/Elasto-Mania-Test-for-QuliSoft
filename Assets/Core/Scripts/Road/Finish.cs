using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Finish : MonoBehaviour
{
    [SerializeField] private Vector2 _offset;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
    }

    public void UpdatePosition(Vector2 positionFinish)
    {
        transform.position = positionFinish + _offset;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerBag playerBag))
        {
            _gameManager.gameStateView.OpenViewPanel(GameState.Win);
        }
    }
}