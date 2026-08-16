public interface IVWeapon
{
    public void V_Fire() {}
    public void V_AltFire() {}

    public virtual void AttachToPlayerInput(PInputSO so)
    {
        if(!so) return;

        so.attack.on += V_Fire;
    }

    public virtual void DeattachFromPlayerInput(PInputSO so)
    {
        if(!so) return;

        so.attack.on -= V_Fire;
    }
}   