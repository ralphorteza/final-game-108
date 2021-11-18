using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Update is called once per frame
    public Animator animator; 
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;
    
    //inputed
    private float [] attackDetails = new float[2];

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Z)) {
            // Play attack animation
            animator.SetTrigger("Attack");

           /*Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            attackDetails[0] = attackDamage;
            attackDetails[1] = transform.position.x;

            foreach(Collider2D collider in detectedObjects) {
                collider.GetComponent<BasicEnemyController>().Damage(attackDetails);
                //Debug.Log("Hit "+ detectedObjects.name);
            } */
 
            // Detect enemies in  range of attack
             Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            // Damage them
            foreach(Collider2D enemy in hitEnemies) {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                Debug.Log("We hit " + enemy.name);
            }  
        }
    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null) { return; }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
