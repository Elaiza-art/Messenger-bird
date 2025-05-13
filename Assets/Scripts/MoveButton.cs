using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject bird;
    private MoveBird birdScript;
    [SerializeField]
    private int moveDirection;
    public void OnPointerDown(PointerEventData eventData)
    {
        birdScript.moveDirection = moveDirection;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        birdScript.moveDirection = 0;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdScript = bird.GetComponent<MoveBird>();
    }
}
