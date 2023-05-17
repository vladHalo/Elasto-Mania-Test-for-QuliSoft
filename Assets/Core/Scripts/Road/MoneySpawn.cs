using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoneySpawn : MonoBehaviour
{
    [SerializeField] private int _countMoney;
    [SerializeField] private Money _prefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private Sprite[] _spritesMoney;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private int _rangeSpawnMin, _rangeSpawnMax;

    private int[] _listIndexMoney = {5, 25, 100};
    private List<Money> _listMoney;

    private void Start()
    {
        _listMoney = new List<Money>();
    }

    public void Spawn(Vector2[] positions)
    {
        int indexPos = 0;

        _listMoney.ForEach(x => LeanPool.Despawn(x));
        _listMoney.Clear();

        for (int i = 0; i < _countMoney; i++)
        {
            indexPos += Random.Range(_rangeSpawnMin, _rangeSpawnMax);
            if (indexPos >= positions.Length) return;

            var money = LeanPool.Spawn(_prefab, _parent);
            money.name = $"{i}";
            int index = Random.Range(0, _listIndexMoney.Length);
            money.Init(_listIndexMoney[index], _spritesMoney[index]);
            money.transform.position = positions[indexPos] + _offset;
            _listMoney.Add(money);
        }
    }
}