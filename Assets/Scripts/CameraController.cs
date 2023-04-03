using UnityEngine;

/// <summary>
/// Висит на main camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Трансформ игрока.
    /// </summary>
    [SerializeField] Transform characterTransform;
    [SerializeField] private Vector3 offset;

    /// <summary>
    /// Следование за игроком.
    /// </summary>
    private void Update()
    {
        transform.position = characterTransform.position + offset;
    }

    /// <summary>
    /// Прекращения следования за игроком.
    /// </summary>
    //private void Stop()
    //{
    //    characterTransform = transform;
    //    offset = Vector3.zero;
    //}
}
