using ClassApiShowCase.Interface;

namespace ClassApiShowCase.Class
{
    public class AmmoType : IAmmoType, IhasId
    {
        public int Id { get; set; } = 0; // id is set by the repo
        public string AmmoName { get; set; } // has to be more the 3 charecters long, and under 50 long
        public string Caseing { get; set; } // more the 3 char and under 10 long
        public List<int> MagSizes { get; set; } // at list of 1 or more, and not containing negattive or zero
        public double AmmoPrice { get; set; } // over 0 

        public AmmoType() : base() { }

        public override string ToString()
        {
            return $"{AmmoName}: Cassing: {Caseing} comes in {Magsices()} Mag sizes";
        }

        public string Magsices()
        {
            string Sizes = ""; 
            foreach (var item in MagSizes)
            {
                Sizes += item;
            }
            return Sizes ;
        }

        public void Validate()
        {
            ValidateName();
            ValidateMag();
            ValidateCasing();
            ValideteAmmoPrice();
        }

    
        private void ValidateName()
        {
            if (string.IsNullOrEmpty(AmmoName))
            {
                throw new ArgumentNullException("class AmmoType.name is null or empty");
            }
            if (AmmoName.Length < 3)
            {
                throw new ArgumentOutOfRangeException("AmmoType.name is lower then 3 charectors long");
            }
            if (AmmoName.Length > 50)
            {
                throw new ArgumentOutOfRangeException("AmmoType.name is more then 50 charectors long");
            }
        }
        private void ValidateMag()
        {
            int errors = 0;
            if (!MagSizes.Any())
            {
                throw new ArgumentException("AmmoType.MagSize is empty");
            }
            foreach (var item in MagSizes)
            {
                if (item < 1)
                {
                   errors++;
                }
            }
            if (errors != 0)
            {
                throw new ArgumentException($"AmmoType.MagSize contains {errors} mags under 1");
            }
        }
        private void ValidateCasing()
        {
            if (string.IsNullOrEmpty(Caseing)) throw new ArgumentNullException("AmmoType.Caseing is null or empty");
            if (Caseing.Length < 3) throw new ArgumentOutOfRangeException("AmmoType.Caseing is under 3");
            if (Caseing.Length < 10) throw new ArgumentOutOfRangeException("AmmoType.Caseing is over 10");
        }
        private void ValideteAmmoPrice()
        {
            if (double.IsNegative(AmmoPrice)) throw new ArgumentException("Ammotype.price is negative");
            if (AmmoPrice > 1000000) throw new ArgumentOutOfRangeException("Ammotype.price is over one milion");
        }
    }
}
