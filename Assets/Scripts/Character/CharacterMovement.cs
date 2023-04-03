using UnityEngine;

internal class CharacterMovement
{
    private Transform characterTransform;
    private Rigidbody rb;
    private InputController inputController;
    private int speed = CharacterAttributes.speed;
    private float rotationSpeed = CharacterAttributes.rotationSpeed;
    
    internal CharacterMovement(Transform transform, Rigidbody rigidbody)
    {
        characterTransform= transform;
        rb = rigidbody;
        inputController = new InputController();
    }
    
    /// <summary>
    /// Логика движения персонажа.
    /// </summary>
    internal void Move()
    {
        LookOnCursor();
        MovementHorizontal();
    }
    
    /// <summary>
    /// Логика поворота в сторону курсора мыши.
    /// </summary>
    private void LookOnCursor()
    {
        Plane playerPlane = new Plane(Vector3.up, characterTransform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        float hitDistance = 0;
        if (playerPlane.Raycast(ray, out hitDistance))
        {
            Vector3 targetPoint = ray.GetPoint(hitDistance);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - characterTransform.position);
            characterTransform.rotation = Quaternion.Slerp(characterTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Логика горизонтального перемещения.
    /// </summary>
    private void MovementHorizontal()
    {
        Vector3 movement = new Vector3(inputController.GetHorizontal(), 0, inputController.GetVertical());
        rb.AddForce(movement * speed * Time.deltaTime, ForceMode.VelocityChange);
    }
}