using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCell : MonoBehaviour
{
    private Transform cell;

    private void Start()
    {
        cell = GetComponent<Transform>();

        StartCoroutine(nameof(RotateCell));
    }

    private IEnumerator RotateCell()
    {
        cell.rotation = Quaternion.Lerp(cell.rotation, Quaternion.Euler(0, 0, 90), 10f *  Time.deltaTime);

        yield return new WaitForSeconds(3);

        cell.rotation = Quaternion.Lerp(cell.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime);

        yield return new WaitUntil(predicate: () => Input.GetKeyDown(KeyCode.Space));

        cell.rotation = Quaternion.Lerp(cell.rotation, Quaternion.Euler(0, 0, 180), Time.deltaTime);
    }
}
