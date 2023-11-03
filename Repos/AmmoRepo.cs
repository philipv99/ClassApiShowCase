using ClassApiShowCase.Class;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ClassApiShowCase.Repos
{
    public class AmmoRepo
    {
        public int NextId = 0;
        public Dictionary<string, AmmoType> AmmoTypes;
        private List<int> _StandartMagSize = new List<int>{ 20, 31, 50 };

        public AmmoRepo()
        {
            AmmoTypes = new Dictionary<string, AmmoType>
            {
                { "SMG FMJ", new AmmoType() { Id = NextId++, AmmoName = "SMG FMJ", Caseing = "9mm", AmmoPrice = 120, MagSizes = _StandartMagSize } },
                { "Small game hunter", new AmmoType() { Id = NextId++, AmmoName = "Small case hunter", Caseing = "5mm", AmmoPrice = 80, MagSizes = new List<int>{6, 8, 12 } } },
                { "Moose hunter", new AmmoType() { Id = NextId++, AmmoName = "Moose hunter", Caseing = "8mm", AmmoPrice = 80, MagSizes = new List<int>{8, 10, 16, 22 } } }
            };
        }

        public void IsNameOfAmmoInRepo(AmmoType testAmmoName)
        {
            if (AmmoTypes.ContainsKey(testAmmoName.AmmoName)) throw new ArgumentException("AmmoName allready exsists in ammoReop");
        }

        public AmmoType Add(AmmoType newAmmo)
        {
            IsNameOfAmmoInRepo(newAmmo);
            newAmmo.Validate();
            newAmmo.Id = NextId++;
            AmmoTypes.Add(newAmmo.AmmoName, newAmmo);
            return newAmmo;
        }

        public Dictionary<string, AmmoType> GetAll()
        {
            return AmmoTypes;
        }

        public AmmoType? GetSingle(int id)
        {
            if (id > AmmoTypes.Count) throw new ArgumentOutOfRangeException("id exceds the total number of mags");
            foreach(var item in AmmoTypes.Values)
            {
                if (item.Id == id) return item;
            }
            return null;
        }

        public KeyValuePair<string, AmmoType>? GetSingle(string key)
        {
            if (AmmoTypes.ContainsKey(key)) return AmmoTypes.Single(AmmoTypes[key]);
            return null;
        }

        public AmmoType Update(int id, AmmoType AmmoToUpate)
        {
            AmmoToUpate.Validate();
            AmmoToUpate.Id = id;
            GetSingle(id)
            return AmmoToUpate;
        }
        public AmmoType Update(string key, AmmoType AmmoToUpate)
        {
            return AmmoToUpate;
        }
    }
}
