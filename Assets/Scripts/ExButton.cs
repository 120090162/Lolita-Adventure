using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
 
public class ExButton : Button
{
    private enum EnumExButtonState
    {
        /// <summary>空</summary>
        None,
        /// <summary>鼠标按下</summary>
        PointerDown,
        /// <summary>鼠标按下</summary>
        PointerUp,
        /// <summary>单击</summary>
        Click,
        /// <summary>双击</summary>
        DoubleClick,
        /// <summary>长按开始</summary>
        PressBegin,
        /// <summary>长按</summary>
        Press,
        /// <summary>长按结束</summary>
        PressEnd,
    }
 
    /// <summary>按钮状态</summary>
    private EnumExButtonState mButtonState = EnumExButtonState.None;
    /// <summary>鼠标按下时间</summary>
    private float mPointerDownTime = 0.0f;
    [SerializeField]
    /// <summary>双击间隔时间</summary>
    private float mDoubleClickInterval = 0.2f;
    [SerializeField]
    /// <summary>长按开始时间</summary>
    private float mPressBeginTime = 0.3f;
    [SerializeField]
    /// <summary>长按间隔时间，0为每帧调用</summary>
    private float mPressIntervalTime = 0.2f;
    /// <summary>长按缓存时间</summary>
    private float mPressCacheTime = 0f;
 
    public Action OnClick { get; set; }
    public Action OnDoubleClick { get; set; }
    public Action OnPressBegin { get; set; }
    public Action OnPress { get; set; }
    public Action OnPressEnd { get; set; }
 
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
 
		if (OnDoubleClick != null)
		{
			if (mButtonState == EnumExButtonState.None)
			{
				mButtonState = EnumExButtonState.PointerDown;
				mPointerDownTime = Time.time;
			}
			else if (mButtonState == EnumExButtonState.PointerUp)
			{
				if (Time.time - mPointerDownTime < mDoubleClickInterval)
				{
					mButtonState = EnumExButtonState.DoubleClick;
					return;
				}
				else
				{
					mButtonState = EnumExButtonState.PointerDown;
					mPointerDownTime = Time.time;
				}
			}
		}
 
		if (OnPressBegin != null || OnPress != null || OnPressEnd != null)
		{
			if (mButtonState != EnumExButtonState.DoubleClick)
			{
				mButtonState = EnumExButtonState.PointerDown;
				mPointerDownTime = Time.time;
			}
		}
 
		if (OnClick != null)
		{
			mButtonState = EnumExButtonState.PointerDown;
		}
    }
 
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
 
		if (OnDoubleClick != null)
		{
			if (mButtonState == EnumExButtonState.PointerDown)
			{
				mButtonState = EnumExButtonState.PointerUp;
				return;
			}
			else if (mButtonState == EnumExButtonState.DoubleClick)
			{
				return;
			}
		}
 
		if (OnPressBegin != null || OnPress != null || OnPressEnd != null)
		{
			if (mButtonState == EnumExButtonState.Press)
			{
				mButtonState = EnumExButtonState.PressEnd;
				return;
			}
		}
 
		if (OnClick != null)
		{
			if (mButtonState == EnumExButtonState.PointerDown)
				mButtonState = EnumExButtonState.PointerUp;
		}
    }
 
    private void Update()
    {
        ProcessUpdate();
        ResponseButtonState();
    }
 
    private void ProcessUpdate()
    {
        if (OnDoubleClick != null) { }
 
        if (OnPressBegin != null || OnPress != null || OnPressEnd != null)
        {
            if (mButtonState == EnumExButtonState.PointerDown)
            {
                if (Time.time - mPointerDownTime > mPressBeginTime)
                {
                    mButtonState = EnumExButtonState.PressBegin;
                    mPressCacheTime = 0f;
                    return;
                }
            }
        }
 
        if (OnClick != null)
        {
            if (mButtonState == EnumExButtonState.PointerUp)
            {
                if (OnDoubleClick != null)
                {
                    if (Time.time - mPointerDownTime > mDoubleClickInterval)
                        mButtonState = EnumExButtonState.Click;
                }
                else
                {
                    mButtonState = EnumExButtonState.Click;
                }
            }
        }
    }
 
    private void ResponseButtonState()
    {
        switch (mButtonState)
        {
            case EnumExButtonState.None:
                break;
            case EnumExButtonState.Click:
                OnClick?.Invoke();
                mButtonState = EnumExButtonState.None;
                break;
            case EnumExButtonState.DoubleClick:
                OnDoubleClick?.Invoke();
                mButtonState = EnumExButtonState.None;
                break;
            case EnumExButtonState.PressBegin:
                OnPressBegin?.Invoke();
                mButtonState = EnumExButtonState.Press;
                break;
            case EnumExButtonState.Press:
                {
                    mPressCacheTime += Time.deltaTime;
                    if (mPressCacheTime >= mPressIntervalTime)
                    {
                        mPressCacheTime = mPressCacheTime - mPressIntervalTime;
                        OnPress?.Invoke();
                    }
                    break;
                }
            case EnumExButtonState.PressEnd:
                OnPressEnd?.Invoke();
                mButtonState = EnumExButtonState.None;
                break;
            default:
                break;
        }
    }
}