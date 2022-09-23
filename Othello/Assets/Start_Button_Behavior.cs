using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using DG.Tweening;  
using UnityEngine.EventSystems;  

public class Start_Button_Behavior : MonoBehaviour,
    IPointerClickHandler,  
    IPointerDownHandler,  
    IPointerUpHandler
{
    public System.Action onClickCallback;  

    [SerializeField] private CanvasGroup _canvasGroup;  

    public void OnPointerClick(PointerEventData eventData)  
    {
        onClickCallback?.Invoke();  
        SceneManager.LoadScene("Board");
    }

    public void OnPointerDown(PointerEventData eventData)  
    {
        transform.DOScale(0.95f, 0.24f).SetEase(Ease.OutCubic);  
        _canvasGroup.DOFade(0.8f, 0.24f).SetEase(Ease.OutCubic);  
    }

    public void OnPointerUp(PointerEventData eventData)  
    {
        transform.DOScale(1f, 0.24f).SetEase(Ease.OutCubic);
        _canvasGroup.DOFade(1f, 0.24f).SetEase(Ease.OutCubic);
    }
}
