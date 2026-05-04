using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public static StateMachine instance;

    public GameState currentState;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = GameState.Menu;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.Menu:
                Debug.Log("Am in Menu");
                break;
            case GameState.Gameplay:
                Debug.Log("Am in Game");
                break;
            default:
                break;
        }
    }

    public void SetGameState(GameState state)
    {
        currentState = state;
    }

}

public enum GameState
{
    Gameplay,
    Menu,
    Dialog,
    Minigame,
    None
}
