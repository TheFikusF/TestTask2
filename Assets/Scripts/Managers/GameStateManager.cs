using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum GameState { Start, Playing, Pause, End }
public enum GameResult { Lose, Win }

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;

    [SerializeField] private float _playingTime = 15f;
    [SerializeField] private UnityEvent<GameState> OnStateChange;
    [SerializeField] private UnityEvent<GameResult> OnGameEnd;
    [SerializeField] private UnityEvent OnGameStart;
    private GameState _gameState = GameState.Start;
    public static GameState GameState => _instance._gameState;
    public static float PlayingTime => _instance._playingTime;

    public static void EndGame(float delay, GameResult gameResult)
    {
        IEnumerator EndGameAction()
        {
            yield return new WaitForSeconds(delay);

            if (GameState == GameState.End) yield return null;
            
            Time.timeScale = 0;
            _instance._gameState = GameState.End;
            _instance.OnStateChange.Invoke(GameState);
            _instance.OnGameEnd.Invoke(gameResult);
            Debug.Log("game ended! you've " + gameResult);
        }

        _instance.StartCoroutine(EndGameAction());
    }

    private void Awake()
    {
        _instance = this;
    }
    
    private void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.touchCount > 0 && GameState == GameState.Start)
        {
            if(Input.GetTouch(0).phase != TouchPhase.Began) return;
            
            Debug.Log("game started");
            Time.timeScale = 1;
            _instance._gameState = GameState.Playing;
            _instance.OnGameStart.Invoke();
            _instance.OnStateChange.Invoke(GameState);
            EndGame(_playingTime, GameResult.Lose);
        }

        if (Input.touchCount > 0 && GameState == GameState.End)
        {
            if(Input.GetTouch(0).phase != TouchPhase.Began) return;

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
