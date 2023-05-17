using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(PolygonCollider2D))]
public class RoadGenerator : MonoBehaviour
{
    [Range(20, 100)] [SerializeField] private int _numRoadPoints;
    [SerializeField] private Vector2 _heightRange;
    [SerializeField] private Vector2 _widthRange;
    [SerializeField] private Vector2 _startRange;
    [SerializeField] private float _backgroundRange;

    [SerializeField] private SpriteShapeController _spriteShapeController;
    private PolygonCollider2D _polygon;

    private Bezier _bezier;
    private List<Vector2> _roadPoints;

    public void Init()
    {
        _polygon = GetComponent<PolygonCollider2D>();
        _bezier = new Bezier();
        _roadPoints = new List<Vector2>();
    }

    [Button("Update")]
    public Vector2[] UpdateRoadPoints()
    {
        float widthLast = _startRange.y;
        float heightLast = 0;
        _roadPoints.Clear();

        for (int i = 0; i < _numRoadPoints; i++)
        {
            heightLast += Random.Range(_heightRange.x, _heightRange.y);
            widthLast += Random.Range(_widthRange.x, _widthRange.y);

            _roadPoints.Add(new Vector3(widthLast, heightLast));
        }

        return GenerateRoadPoints(widthLast);
    }

    private Vector2[] GenerateRoadPoints(float widthLast)
    {
        float step = 1f / _roadPoints.Count;
        List<Vector2> roadPoints = new List<Vector2>();

        roadPoints.Add(new Vector2(_startRange.x, 0));
        roadPoints.Add(new Vector2(_startRange.y, 0));

        for (int i = 0; i <= _roadPoints.Count; i++)
        {
            roadPoints.Add(_bezier.GetPoint(_roadPoints, i * step));
        }

        roadPoints.Add(new Vector2(widthLast, _backgroundRange));
        roadPoints.Add(new Vector2(0, _backgroundRange));

        _polygon.points = roadPoints.ToArray();
        AddTextureRoad();
        return _polygon.points;
    }

    private void AddTextureRoad()
    {
        _spriteShapeController.spline.Clear();

        for (int i = 0; i < _polygon.points.Length; i++)
        {
            _spriteShapeController.spline.InsertPointAt(i, _polygon.points[i]);
        }

        _spriteShapeController.BakeCollider();
        _spriteShapeController.BakeMesh();
    }
}