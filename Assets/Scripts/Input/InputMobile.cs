using UnityEngine;

public class InputMobile : MonoBehaviour ,IInput
{
    public MobileStick movement;
    public MobileStick shooting;

    bool fireDown;
    bool fireUp;

    void Start()
    {
        shooting.resetToCero = false;
        GameManager.instance.StateChangeEvent.AddListener(OnGameState);

        shooting.dragStart.AddListener(OnFireDown);
        shooting.dragEnd.AddListener(OnFireUp);

        gameObject.SetActive(false);
    }

    void OnGameState()
    {
        gameObject.SetActive(GameManager.instance.state == GameState.Game);
        fireDown = fireUp = false;
    }

    void LateUpdate()
    {
        fireDown = fireUp = false;
    }

    void OnFireDown()
    {
        fireDown = true;
    }

    void OnFireUp()
    {
        fireUp = true;
    }

    public bool ChangeWeapon()
    {
        return false;
    }

    public Vector2 GetAimDirection()
    {
        return shooting.direction;
    }

    

    public bool GetFireDown()
    {
        return fireDown;
    }

    public bool GetFireUp()
    {
        return fireUp;
    }

    public Vector2 GetMovementDirection()
    {
        return movement.direction;
    }
}
