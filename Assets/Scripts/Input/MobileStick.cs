using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MobileStick : EventTrigger {

    Vector2 initialPos = Vector2.zero;

    public Vector2 direction = Vector2.zero;

    public UnityEvent dragStart;
    public UnityEvent dragEnd;
    public bool resetToCero = true;

    GameObject image;

    void Awake()
    {
        dragStart = new UnityEvent();
        dragEnd = new UnityEvent();

        image = transform.GetChild(0).gameObject;
    }

    void Start()
    {
        GameManager.instance.StateChangeEvent.AddListener(OnStartGame);
    }

    void OnStartGame()
    {
        if (GameManager.instance.state == GameState.Start)
        {
            OnEndDrag(null);
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        initialPos = eventData.position;
        dragStart.Invoke();
        image.SetActive(true);
        image.transform.position = initialPos;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        direction = eventData.position - initialPos;
        direction.Normalize();
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (resetToCero)
        {
            initialPos = direction = Vector2.zero;
        }
        dragEnd.Invoke();
        image.SetActive(false);
    }
}
