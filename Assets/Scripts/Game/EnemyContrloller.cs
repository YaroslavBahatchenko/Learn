using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private UIController uIController;
    [SerializeField] private PlayerController playerController;
    private List<Enemy> enemies = new List<Enemy>(); // список противников на текущем уровне

    // регистрация противника в контроллере
    public void Register(Enemy newEnemy)
    {
        enemies.Add(newEnemy); // добавление нового противника в общий список
    }

    // удаление при его смерти
    public void RemoveEnemy(Enemy enemyToRemove)
    {
        enemies.Remove(enemyToRemove); // удаление противника из общего списка

        // проверяем есть ли еще противника на уровне
        if (enemies.Count == 0)
        {
            // делаем если все противники мертвы
            Debug.Log("Player Win!");

            uIController.PlayerWin(); // показываем экран победы
            playerController.CannotShoot(); // отлючаем возможность бросать гранаты у игрока
        }
    }

    public int EnemyCount()
    {
        return enemies.Count;
    }
}
