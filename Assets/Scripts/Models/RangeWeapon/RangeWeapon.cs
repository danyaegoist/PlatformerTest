using UnityEngine;

[CreateAssetMenu(menuName = "Platformer/Create Range Weapon")]
public class RangeWeapon : ItemBase
{
    public float AttackSpeed;
    public float AttackAmount;
    public float BulletSpeed;
    public GameObject BulletPrefab;

    public override void Activate(Vector2 position, float direction, LayerMask targets)
    {
        if (BulletPrefab == null) return;
        
        var go = Instantiate(BulletPrefab, position, new Quaternion());
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        BulletController contrl = go.GetComponent<BulletController>();
        contrl.Damage = AttackAmount;
        contrl.Targets = targets;
        rb.velocity = new Vector2(direction * BulletSpeed, 0);
        go.transform.localScale = new Vector3(direction, go.transform.localScale.y, go.transform.localScale.z);
    }

    public override float GetReloadingSpeed()
    {
        return AttackSpeed;
    }

    public override void Mount(SpriteRenderer renderer)
    {
        renderer.sprite = Sprite;
    }
}