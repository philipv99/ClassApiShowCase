using ClassApiShowCase.Class;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ClassApiShowCase.Repos
{
    public class AmmoRepo
    {
        #region fields
        public int NextId = 0;
        public Dictionary<string, AmmoType> AmmoTypes;
        private List<int> _StandartMagSize = new List<int>{ 20, 31, 50 };
        #endregion

        #region constructor
        public AmmoRepo()
        {
            AmmoTypes = new Dictionary<string, AmmoType>
            {
                { "SMG FMJ", new AmmoType() { Id = NextId++, AmmoName = "SMG FMJ", Caseing = "9mm", AmmoPrice = 120, MagSizes = _StandartMagSize } },
                { "Small game hunter", new AmmoType() { Id = NextId++, AmmoName = "Small case hunter", Caseing = "5mm", AmmoPrice = 80, MagSizes = new List<int>{6, 8, 12 } } },
                { "Moose hunter", new AmmoType() { Id = NextId++, AmmoName = "Moose hunter", Caseing = "8mm", AmmoPrice = 80, MagSizes = new List<int>{8, 10, 16, 22 } } }
            };
        }
        #endregion

        #region methods
        /// <summary>
        /// cheks if the name if AmmoType object, not in the repo, is allready used.
        /// </summary>
        /// <param name="testAmmoName"></param>
        /// <exception cref="ArgumentException"></exception>
        public void IsNameOfAmmoInRepo(AmmoType testAmmoName)
        {
            if (AmmoTypes.ContainsKey(testAmmoName.AmmoName)) throw new ArgumentException("AmmoName allready exsists in ammoReop");
        }

        /// <summary>
        /// takes an object type of AmmoType and adds it to the repo dictonary<![CDATA[<]]><paramref name="string"/>, <paramref name="AmmoType"/>><para />
        /// the object has its <paramref name="id"/> replaced, to math the repos maxValue.<para />
        /// takes the <paramref name="AmmoType"/>.<paramref name="AmmoName"/> as the <paramref name="string"/> besed <paramref name="Key"/> to the value <paramref name="AmmoType"/>
        /// </summary>
        /// <param name="newAmmo"></param>
        /// <returns>the newly added object type of AmmoType</returns>
        public AmmoType Add(AmmoType newAmmo)
        {
            IsNameOfAmmoInRepo(newAmmo);
            newAmmo.Validate();
            newAmmo.Id = NextId++;
            AmmoTypes.Add(newAmmo.AmmoName, newAmmo);
            return newAmmo;
        }

        #region gets
        /// <summary>
        /// gats all items in the repo 
        /// </summary>
        /// <returns>a dictonary same is the one in the repo</returns>
        public Dictionary<string, AmmoType> GetAll() => AmmoTypes;

        /// <summary>
        /// takes a int id = to a id in AmmoType.id 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>one AmmoType.value from AmmoTypes repo or null</returns>
        public AmmoType? GetSingle(int id)
        {
            if (id > AmmoTypes.Count) throw new ArgumentOutOfRangeException("id exceds the total number of mags");
            if (int.IsNegative(id)) throw new ArgumentOutOfRangeException("id is negative");
            foreach (var item in AmmoTypes.Values)
            {
                if (item.Id == id) return item;
            }
            return null;
        }

        /// <summary>
        /// helper method to get the key from an int.
        /// </summary>
        /// <param name="id">id paramator in type AmmoType.id</param>
        /// <returns>string recepling a key from AmmoTypes</returns>
        /// <exception cref="ArgumentOutOfRangeException">if the id is not in the repo or is negative</exception>
        /// <exception cref="ArgumentException"></exception>
        private string GetSingleKey(int id)
        {
            if (id > AmmoTypes.Count) throw new ArgumentOutOfRangeException("id exceds the total number of mags");
            if (int.IsNegative(id)) throw new ArgumentOutOfRangeException("id is negative");
            foreach (var item in AmmoTypes)
            {
                if (item.Value.Id == id) return item.Key.ToString();
            }
            throw new ArgumentException("somthings wrong white id could not find");
        }

        /// <summary>
        /// takes a string key = to a key in AmmoTypes repo 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>one AmmoType.value from AmmoTypes repo or null</returns>
        public AmmoType? GetSingle(string key)
        {
            if (AmmoTypes.ContainsKey(key)) return AmmoTypes[key];
            return null;
        }
        #endregion

        #region update
        /// <summary>
        /// takes an id = to any ammoType.id and an object, typeof: AmmoType and replaces the ammotype at the id's locction.
        /// the new object will take the old objects id. 
        /// </summary>
        /// <param name="key">string based key from the dictionary AmmoTypes</param>
        /// <param name="AmmoToUpate">the new full made ammo opject to replace the old one</param>
        /// <returns>returns the new object if the mothods secceds</returns>
        public AmmoType Update(int id, AmmoType AmmoToUpate)
        {
            return Update(GetSingleKey(id), AmmoToUpate);
        }

        /// <summary>
        /// takes a key from the ammoRepo and an object, typeof: AmmoType and replaces the ammotype at the keys locction.
        /// the new object will take the old objects id. 
        /// </summary>
        /// <param name="key">string based key from the dictionary AmmoTypes</param>
        /// <param name="AmmoToUpate">the new full made ammo opject to replace the old one</param>
        /// <returns>returns the new object if the mothods secceds</returns>
        public AmmoType Update(string key, AmmoType AmmoToUpate)
        {
            AmmoToUpate.Validate();
            AmmoToUpate.Id = AmmoTypes[key].Id;
            AmmoTypes[key] = AmmoToUpate;
            return AmmoToUpate;
        }
        #endregion
        #endregion
    }
}
