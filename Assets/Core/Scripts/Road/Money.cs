using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Money : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public int indexMoney;

    public void Init(int index, Sprite sprite)
    {
        indexMoney = index;
        _spriteRenderer.sprite = sprite;
    }
}