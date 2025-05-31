using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject bird;
    private MoveBird birdScript;
    public void OnPointerDown(PointerEventData eventData)
    {
        birdScript.fire();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdScript = bird.GetComponent<MoveBird>();
    }
}
