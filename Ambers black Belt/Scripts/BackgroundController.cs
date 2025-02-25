using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour
{

    public bool isSwitched = false;
    public Image Image1;
    public Image Image2;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchImage(Sprite sprite)
    {
        if(!isSwitched)
        {
            Image1.sprite = sprite;
            animator.SetTrigger("SwitchZero");
        }
        else
        {
            Image2.sprite = sprite;
            animator.SetTrigger("SwitchOne");
        }
        isSwitched = !isSwitched;
    }

    public void SetImage(Sprite sprite)
    {
        if(!isSwitched)
        {
            Image1.sprite = sprite;
        }
        else
        {
            Image2.sprite = sprite;
        }
    }

}
