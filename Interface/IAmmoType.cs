namespace ClassApiShowCase.Interface
{
    public interface IAmmoType:IhasId
    {
        string AmmoName { get; set; }

        string Caseing { get ; set; }

        List<int> MagSizes { get; set; }
    }
}
