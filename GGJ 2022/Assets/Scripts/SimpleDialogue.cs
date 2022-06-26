using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SimpleDialogue : SingleTon<SimpleDialogue>
{

    public GameObject dialogue;
    public Text dialogueText;

    public void StartDialogue(string text, float time)
    {
        StartCoroutine(ShowDialogue(text, time));
    }

    IEnumerator ShowDialogue(string text, float time)
    {
        dialogueText.text = string.Empty;
        dialogue.SetActive(true);
        yield return dialogueText.DOText(text, time).WaitForCompletion();
        dialogue.SetActive(false);
    }

    public void ShowBrandDia()
    {
        StartCoroutine(ShowDialogue("你捡起了“正在打扫”的牌子，也许可以放在什么地方", 4f));
    }

    public void ShowToolDia()
    {
        StartCoroutine(ShowDialogue("你捡起了“工具箱”，也许可以在哪里用得上", 4f));
    }

}
