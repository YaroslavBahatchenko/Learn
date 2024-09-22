using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Grenade grenadePrefab;
    [SerializeField] private UIMainScreen mainScreen;
    [SerializeField] private float delayToShoot = 0.1f;
    private Vector3 launchDirection;
    private bool isCanShoot = true;
    private Player player;
    private Vector3 startScale;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.GetAimLine().gameObject.SetActive(false);
        startScale = player.GetPlayerPivot().localScale;
    }

    // Update is called once per frame
    private void Update()
    {
        // нажата левая кнопка мыши. Включаем линию прицеливания
        if (Input.GetMouseButtonDown(0) && isCanShoot)
        {
            player.GetAimLine().gameObject.SetActive(true);
            player.StartAim();
        }

        // отпускаем левую кнопку мыши. Выключаем линию прицеливания и бросаем гранату
        if (Input.GetMouseButtonUp(0) && isCanShoot)
        {
            player.GetAimLine().gameObject.SetActive(false);
            if (isCanShoot)
            {
                StartCoroutine(Shoot()); // бросаем гранату
                player.ThrowGrenade();
            }
        }

        // поворачиваем линию прицеливания за джойстиком если нажата левая кнопка мыши
        if (Input.GetMouseButton(0))
        {
            float angel = Vector2.Angle(Vector2.right, joystick.Direction);
            player.GetAimLine().eulerAngles = new Vector3(0, 0, angel * Mathf.Sign(joystick.Direction.y));
            launchDirection = joystick.Direction;
            Vector3 currentScale = startScale;                  // 2.3 2.3
            currentScale.x *= Mathf.Sign(joystick.Direction.x); // -2.3 -2.3
            player.GetPlayerPivot().localScale = currentScale;  // -2.3 -2.3
        }
    }

    // бросаем гранату
    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(delayToShoot);
        Debug.Log("shoot");
        //создаем гранату
        Grenade newGrenade = Instantiate(grenadePrefab, player.GetGrenadeSpawnPoint().position, Quaternion.identity);
        // вызываем у гранаты метод запуска
        newGrenade.Launch(launchDirection);
        mainScreen.UseGrenade();
    }

    public void CannotShoot()
    {
        isCanShoot = false;
    }
}