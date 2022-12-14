using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using DG.Tweening;  
using UnityEngine.EventSystems;  

public class Buttons_Behavior : MonoBehaviour,
    IPointerClickHandler,  
    IPointerDownHandler,  
    IPointerUpHandler
{
    public System.Action onClickCallback;  

    [SerializeField] private CanvasGroup _canvasGroup;  

    public void OnPointerClick(PointerEventData eventData)  
    {
        onClickCallback?.Invoke();
        
        if (gameObject.tag == "Exit_Button") SceneManager.LoadScene("Start_Scene");
        else if (gameObject.tag == "Start_Button" || gameObject.tag == "Retry_Button") SceneManager.LoadScene("Board");
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
