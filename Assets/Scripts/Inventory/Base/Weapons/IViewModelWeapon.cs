public interface IViewModelWeapon
{
    void V_Fire() {}
    void V_AltFire() {}

    virtual void AttachToPlayerInput(PInputSO so)
    {
        if(!so) return;

        so.eventAttack += V_Fire;
    }

    virtual void DeattachToPlayerInput(PInputSO so)
    {
        if(!so) return;

        so.eventAttack += V_Fire;
    }
}   