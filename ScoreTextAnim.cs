using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextAnim : MonoBehaviour
{
    public float t;
    public float appearTime;
    public AnimationCurve positionCurve , fadingCurve;
    public Vector3 pos;
    public CanvasGroup canvasGroup;
    Text text;
    
    void Start()
    {
        pos = transform.parent.position + new Vector3(1.3f,1.17f,0f);
        transform.position = pos;
        text = transform.GetComponent<Text>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    IEnumerator Anim(){
        while(t <= appearTime){
            gameObject.transform.position = new Vector3(0.25f*positionCurve.Evaluate(t/appearTime),0f,0f) + pos;
            canvasGroup.alpha = fadingCurve.Evaluate(t/appearTime);
            yield return t += Time.deltaTime;
        }
    }

    public void Show(string grade){
        text.text = grade;
        t = 0f;
        StartCoroutine(Anim());
        Invoke("Disappear",1f);
    }

    void Disappear(){
        canvasGroup.alpha = 0;
    }
}
