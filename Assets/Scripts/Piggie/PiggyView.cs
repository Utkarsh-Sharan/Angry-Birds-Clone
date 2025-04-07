using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyView : MonoBehaviour
{
    [SerializeField] protected GameObject piggyDeathParticle;
    private PiggyController _piggyController;

    public void Initialize(PiggyController piggieController)
    {
        _piggyController = piggieController;

        GameService.Instance.GetLevelService().AddPiggyToLevelList(this);
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        _piggyController.OnPiggyCollision(other);
    }

    public void Die()
    {
        GameService.Instance.GetLevelService().RemovePiggyFromLevelList(this);
        GameService.Instance.GetAudioService().PlaySound(AudioType.Pop);

        Instantiate(piggyDeathParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
