using System.Collections;
using System.Collections.Generic;
using DG.Tweening;  
using UnityEngine;  
using UnityEngine.EventSystems;  

public class Buttons : MonoBehaviour,  
    IPointerClickHandler,  
    IPointerDownHandler,  
    IPointerUpHandler  
{
    public int Flag = 0;
    public System.Action onClickCallback;  

    [SerializeField] private CanvasGroup _canvasGroup;  

    public void OnPointerClick(PointerEventData eventData)  
    {
        onClickCallback?.Invoke(); 

    }

    public void OnPointerDown(PointerEventData eventData)  
    {
        transform.DOScale(8f, 0.24f).SetEase(Ease.OutCubic);  
        _canvasGroup.DOFade(8f, 0.24f).SetEase(Ease.OutCubic);  
    }

    public void OnPointerUp(PointerEventData eventData)  
    {
        transform.DOScale(10f, 0.24f).SetEase(Ease.OutCubic);  
        _canvasGroup.DOFade(10f, 0.24f).SetEase(Ease.OutCubic);  
    }
}