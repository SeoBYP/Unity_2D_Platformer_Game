using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_3
{
    public class ParallaxEffect : MonoBehaviour
    {
        public Camera cam;               // ī�޶� �����ϱ� ���� ���� ����
        public Transform followTarget;   // �ȷο��� ����� �����ϱ� ���� ���� ����

        Vector2 startingPosition;        // �з����� ���� ������Ʈ�� ���� ��ġ�� �����ϴ� ����
        float startingZ;                 // �з����� ���� ������Ʈ�� ���� Z ��

        // ī�޶� �̵����� ����Ͽ� ��ȯ�ϴ� �͸� �Ӽ� (Property)
        Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

        // ���� �з����� ������Ʈ ���� Z �Ÿ��� ��ȯ�ϴ� �͸� �Ӽ� (Property)
        float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

        // Ŭ���� �÷��� (Ŭ���� ���)�� ����Ͽ� ��ȯ�ϴ� �͸� �Ӽ� (Property)
        // �÷��̾�� ��� ������Ʈ ������ �Ÿ����� ���� �ٸ� ������ ȿ���� ��Ÿ���� ���� ����
        // ������ ȿ���� �ְ� ������ 0.1f�� �����ص� �˴ϴ�.
        float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget) > 0 ? cam.farClipPlane : cam.nearClipPlane);

        // �з����� ����� ����Ͽ� ��ȯ�ϴ� �͸� �Ӽ� (Property)
        float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

        // Start �Լ��� ù ��° ������ ������ ȣ��˴ϴ�.
        void Start()
        {
            // �з����� ���� ������Ʈ�� ���� ��ġ�� Z ���� �����մϴ�.
            startingPosition = transform.position;
            startingZ = transform.localPosition.z;
        }

        // Update �Լ��� �� �����Ӹ��� ȣ��˴ϴ�.
        void Update()
        {
            // ���ο� ��ġ�� ����Ͽ� �з����� ���� ������Ʈ�� ��ġ�� ������Ʈ�մϴ�.
            Vector2 newPosition = startingPosition + camMoveSinceStart / parallaxFactor;

            // �з����� ������Ʈ�� ��ġ�� ���� ���� ��ġ�� ������Ʈ�ϸ� Z ���� ���� Z ������ �����մϴ�.
            transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
        }
    }
}