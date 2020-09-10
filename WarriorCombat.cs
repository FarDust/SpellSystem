using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorCombat : MonoBehaviour
{
    public Animator animator;
    // Solo ataca a los objetos que se encuentren en la capa enemyLayer
    public LayerMask enemyLayer;

    // Punto desde donde se efectuan los ataques
    public Transform attackPoint;
    // Radio del ataque, medido desde attackPoint
    public float attackRange = 0.5f;
    // Tiempo que se debe esperar entre ataques
    public float attackCooldown = 0.5f;
    // Tiempo a partir del cual puede ocurrir el siguiente ataque
    float nextAttackTime = 0f;
    
    // Stats
    public int attackDamage = 40;
    public int maxHealth = 100;
    int currentHealth;

    public HealthBar healthBar;

    void Start () {
        currentHealth = maxHealth;
        healthBar.setHealth((float)currentHealth / maxHealth);
    }

    void Update(){
        if (Time.time >= nextAttackTime){
            if (Input.GetButtonDown("Attack_warrior")){
                Attack();
                // Audio
                SoundManagingScript.PlaySound("warriorSword");
                // Fin Audio
                nextAttackTime = Time.time + attackCooldown;
            }
        }
        if (Debug.isDebugBuild) {
            if (Input.GetKeyDown("g")) {
                SoundManagingScript.PlaySound("warriorHit");
                TakeHit(10);
            }
        }
        
    }

    void Attack(){
        // Activa la animacion
        animator.SetTrigger("Attack");
        // Detectar enemigos en el rango de ataque y la capa elegida
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        // Dañar enemigos
        foreach(Collider2D enemy in hitEnemies){
            //enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            Debug.Log("Enemy hit:" + enemy.name);
        }
    }

    void TakeHit(int damage){
        animator.SetTrigger("Hurt");
        currentHealth -= damage;
        healthBar.setHealth(Mathf.Max((float)currentHealth / maxHealth, 0f));

        if (currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        animator.SetBool("isDead", true);
    }

    private void OnDrawGizmosSelected() {
        if (attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
