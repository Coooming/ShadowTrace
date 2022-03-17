using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator theAnimator;
    [SerializeField] private bool isStop = true; // 标识当前是否停留
    [SerializeField] private bool isToRight = true; // 标识当前朝向是否为右
    [SerializeField] private bool isInteracting = false; // 标识当前是否正在交互
    [SerializeField] private bool isJumping = false; // 标识当前是否正在跳跃

    // 为Control提供的接口
    public void setIsStop(bool _isStop)
    {
        isStop = _isStop;
    }

    public void setIsToRight(bool _isToRight)
    {
        isToRight = _isToRight;
    }

    public void setIsInteracting(bool _isInteracting)
    {
        isInteracting = _isInteracting;
    }

    public void setIsJumping(bool _isJumping)
    {
        isJumping = _isJumping;
    }

    void Start()
    {
        theAnimator = this.GetComponent<Animator>();
    }

    void Update()
    {
        theAnimator.SetBool("isStop", isStop);
        theAnimator.SetBool("isInteracting", isInteracting);
        theAnimator.SetBool("isJumping", isJumping);

        if (isToRight && this.transform.eulerAngles.y < 1f)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }

        if (!isToRight && this.transform.eulerAngles.y > 179f)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
    }
}
