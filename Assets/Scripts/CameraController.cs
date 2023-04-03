using UnityEngine;

/// <summary>
/// ����� �� main camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// ��������� ������.
    /// </summary>
    [SerializeField] Transform characterTransform;
    [SerializeField] private Vector3 offset;

    /// <summary>
    /// ���������� �� �������.
    /// </summary>
    private void Update()
    {
        transform.position = characterTransform.position + offset;
    }

    /// <summary>
    /// ����������� ���������� �� �������.
    /// </summary>
    //private void Stop()
    //{
    //    characterTransform = transform;
    //    offset = Vector3.zero;
    //}
}
