using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public CardData data;

    public TMP_Text nameText;
    public TMP_Text costText;
    public Image artwork;

    RectTransform rectTransform;
    Canvas canvas;
    Vector3 originalPosition;

    Enemy enemy;
    EnergyManager energyManager;

    TurnManager turnManager;
    DiscardManager discardManager;
    HandManager handManager;
    Transform originalParent;
    CanvasGroup canvasGroup;

    public static bool isDragging = false;

    public void Init(CardData newData)
    {
        data = newData;

        nameText.text = data.cardName;
        costText.text = data.cost.ToString();

        enemy = FindObjectOfType<Enemy>();
        energyManager = FindObjectOfType<EnergyManager>();
        turnManager = FindObjectOfType<TurnManager>();
        discardManager = FindObjectOfType<DiscardManager>();
        handManager = FindObjectOfType<HandManager>();
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    /*
    public void OnClick()
    {
        if (!turnManager.playerTurn)
        {
            Debug.Log("지금은 플레이어 턴이 아닙니다.");
            return;
        }

        if (!energyManager.UseEnergy(data.cost))
        {
            Debug.Log("에너지가 부족합니다!");
            return;
        }

        if (data.effect != null)
        {
            data.effect.Execute();
        }

        if (discardManager != null)
        {
            discardManager.AddToDiscard(data);
        }

        handManager.RemoveCard(this); // 👈 이거 추가

        Destroy(gameObject);
    }
    */

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.position;
        originalParent = transform.parent;

        transform.SetParent(canvas.transform); // 🔥 최상위로 이동
        transform.SetAsLastSibling();

        canvasGroup.blocksRaycasts = false; // 🔥 Enemy 감지 가능

        transform.localScale = Vector3.one * 1.2f;

        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        GameObject target = eventData.pointerEnter;

        bool isOnEnemy = false;

        if (target != null)
        {
            Transform t = target.transform;

            while (t != null)
            {
                if (t.CompareTag("Enemy"))
                {
                    isOnEnemy = true;
                    break;
                }
                t = t.parent;
            }
        }

        if (isOnEnemy)
        {
            bool success = UseCard();

            if (!success)
            {
                ResetPosition();
            }
        }
        else
        {
            ResetPosition();
        }

        isDragging = false;
    }

    bool UseCard()
    {
        if (!turnManager.playerTurn)
        {
            Debug.Log("지금은 플레이어 턴이 아닙니다.");
            return false;
        }

        if (!energyManager.UseEnergy(data.cost))
        {
            Debug.Log("에너지가 부족합니다!");
            return false;
        }

        if (data.effect != null)
        {
            data.effect.Execute();
        }

        if (discardManager != null)
        {
            discardManager.AddToDiscard(data);
        }

        handManager.RemoveCard(this);

        Destroy(gameObject);

        return true;
    }

    void ResetPosition()
    {
        transform.SetParent(originalParent); // 🔥 원래 위치로 복귀
        rectTransform.position = originalPosition;
        transform.localScale = Vector3.one;
    }
}