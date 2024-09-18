using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Grenade grenadePrefab;
    //[SerializeField] private Transform aimLine;
    //[SerializeField] private Transform spawnPoint;
    [SerializeField] private UIMainScreen mainScreen;
    private Vector3 launchDirection;
    private bool isCanShoot = true;
    private Player player;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.GetAimLine().gameObject.SetActive(false); 
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
            Shoot(); // бросаем гранату
            player.ThrowGrenade();
        }

        // поворачиваем линию прицеливания за джойстиком если нажата левая кнопка мыши
        if (Input.GetMouseButton(0))
        {
            float angel = Vector2.Angle(Vector2.right, joystick.Direction);
            player.GetAimLine().eulerAngles = new Vector3(0, 0, angel * Mathf.Sign(joystick.Direction.y));
            launchDirection = joystick.Direction;
        }
    }

    // бросаем гранату
    private void Shoot()
    {
        if (!isCanShoot)
        {
            return;
        }

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
