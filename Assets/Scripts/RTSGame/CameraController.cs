/*-----------------------------------------------
 // 作    者：RCY
 // 文 件 名：CameraController
 // 创建日期：2022/3/10 23:38:35
 // 功能描述：摄像机控制
 // 修改日期：
 // 修改描述：
-----------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed;
    public float moveTime;
    public Vector3 zoomAmount;

    private Vector3 newPos;
    private Quaternion newRotation;
    private Vector3 newZoom;
    private Vector3 dragStartPos, dragCurrentPos;
    private Vector3 rotateStart, rotateCurrent;

    public Transform cameraTrans;
    
    void Start()
    {
        newPos = transform.position;
        newZoom = cameraTrans.localPosition;
        newRotation = transform.rotation;
    }

    public void CameraTransform()
    {
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * moveTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * moveTime);
        cameraTrans.localPosition = Vector3.Lerp(cameraTrans.localPosition, newZoom, Time.deltaTime * moveTime);
    }

    /// <summary>
    /// 键盘控制摄像机移动
    /// </summary>
    public void CameraMovementInputByKey()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPos += transform.forward * panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPos -= transform.right * panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPos -= transform.forward * panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPos += transform.right * panSpeed * Time.deltaTime;
        }

    }


    /// 通过鼠标输入控制摄像机移动
    /// </summary>
    public void CameraMovementInputByMouse()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float distance))
            {
                dragStartPos = ray.GetPoint(distance);
            }
        }

        if (Input.GetMouseButton(2))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float distance))
            {
                dragCurrentPos = ray.GetPoint(distance);

                Vector3 difference = dragStartPos - dragCurrentPos;
                newPos = transform.position + difference;
            }
        }
    }

    /// <summary>
    /// 通过鼠标输入控制摄像机缩放
    /// </summary>
    public void CameraZoomInputByMouse()
    {
        newZoom += Input.mouseScrollDelta.y * zoomAmount;
    }

    /// <summary>
    /// 通过鼠标输入控制摄像机旋转
    /// </summary>
    public void CameraRotationInputByMouse()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.visible = false;
            rotateStart = Input.mousePosition;

        }
        if (Input.GetMouseButton(1))
        {
            rotateCurrent = Input.mousePosition;
            Vector3 difference = rotateStart - rotateCurrent;
            rotateStart = rotateCurrent;
            newRotation *= Quaternion.Euler(Vector3.up * -difference.x / 10);

        }
        if (Input.GetMouseButtonUp(1))
        {
            Cursor.visible = true;
        }
    }
}
