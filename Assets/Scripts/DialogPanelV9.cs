﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Serialization;

public class DialogPanelV9 : MonoBehaviour
{
    public AnimationClip playDialogMessageAnimation;

    public AnimationClip openDialogAnimation;
    public AnimationClip closeDialogAnimation;

    public Text dialogMessageLabel;
    public ClickButton dialogButton;

    [FormerlySerializedAs("messages")]
    public string[] messageData;

    private Image _dialogPanel;
    private Animation _animation;

    public void Awake()
    {
        _dialogPanel = GetComponent<Image>();
        _animation = GetComponent<Animation>();
    }

    public IEnumerator Start()
    {
        yield return 開啟對話框();
        foreach (var msg in messageData)
        {
            yield return 播放對話(msg);
            yield return 等待按繼續鈕();
        }
        yield return 關閉對話框();
    }

    private IEnumerator 開啟對話框()
    {
        _animation.Play(openDialogAnimation.name);
        while (_animation.isPlaying)
            yield return null;
    }

    private IEnumerator 播放對話(string msg)
    {
        dialogMessageLabel.text = msg;

        _animation.Play(playDialogMessageAnimation.name);
        while (_animation.isPlaying)
            yield return null;
    }

    private IEnumerator 關閉對話框()
    {
        _animation.Play(closeDialogAnimation.name);
        while (_animation.isPlaying)
            yield return null;
    }

    private IEnumerator 等待按繼續鈕()
    {
        yield return dialogButton.WaitForClick();
    }
}
