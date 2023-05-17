using Sirenix.OdinInspector;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] private RoadGenerator _roadGenerator;
    [SerializeField] private Finish _finish;
    [SerializeField] private MoneySpawn _moneySpawn;
    [SerializeField] private MoneyView _moneyView;

    private int _money;

    public GameStateView gameStateView;
    public PlayerMove _playerMove;

    private void Start()
    {
        _roadGenerator.Init();
        UpdateAllComponents();
        gameStateView.InitButtons(UpdateAllComponents);
    }

    public void AddMoney(int indexMoney)
    {
        _money += indexMoney;
        _moneyView.UpdateMoneyText(_money);
    }

    [Button("UpdateAllComponents")]
    void UpdateAllComponents()
    {
        _playerMove.UpdatePlayer();

        var positions = _roadGenerator.UpdateRoadPoints();
        _finish.UpdatePosition(positions[positions.Length - 3]);
        _moneySpawn.Spawn(positions);

        gameStateView.OpenViewPanel(GameState.Play);

        _money = 0;
        AddMoney(0);
    }
}