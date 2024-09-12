// using UnityEngine;
// using UnityEngine.EventSystems;

// public class CardDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     private RectTransform _rectTransform;
//     private CanvasGroup _canvasGroup;
//     private Transform _originalParent;
//     private Vector3 _originalLocalPosition;
//     private Tablero _tablero;

//     private void Awake()
//     {
//         _rectTransform = GetComponent<RectTransform>();
//         _canvasGroup = GetComponent<CanvasGroup>();
//     }

//     private void Start()
//     {
//         _tablero = FindObjectOfType<Tablero>();
//         if (_tablero == null)
//         {
//             Debug.LogError("Tablero no encontrado en la escena.");
//         }
//     }

//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         _originalParent = transform.parent;
//         _originalLocalPosition = _rectTransform.localPosition;
//         _canvasGroup.alpha = 0.6f;
//         _canvasGroup.blocksRaycasts = false;
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         _rectTransform.anchoredPosition += eventData.delta / _canvasGroup.transform.lossyScale;
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         _canvasGroup.alpha = 1.0f;
//         _canvasGroup.blocksRaycasts = true;

//         if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("DropZone"))
//         {
//             transform.SetParent(eventData.pointerEnter.transform);
//             _rectTransform.anchoredPosition = Vector2.zero;

//             Card card = GetComponent<Card>();
//             if (card != null)
//             {
//                 _tablero.PlaceCardInZone(card, eventData.pointerEnter.name);
//             }
//             else
//             {
//                 Debug.LogError("El componente Card no se encuentra en la carta.");
//             }
//         }
//         else
//         {
//             _rectTransform.localPosition = _originalLocalPosition;
//             transform.SetParent(_originalParent, false);
//         }
//     }
// }
