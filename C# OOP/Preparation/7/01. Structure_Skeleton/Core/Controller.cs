using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.CocktailTypes;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Models.DelicacyTypes;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository boothRepository;
        private DelicacyRepository delicacyRepository;
        private CocktailRepository cocktailRepository;

        public Controller()
        {
            boothRepository = new BoothRepository();
            delicacyRepository = new DelicacyRepository();
            cocktailRepository = new CocktailRepository();
        }
        public string AddBooth(int capacity)
        {
            int id = boothRepository.Models.Count + 1;
            var booth = new Booth(id, capacity);
            boothRepository.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, id, capacity).TrimEnd();
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail = null;

            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
            else if (size != "Large" && size != "Middle" && size != "Small")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }
            else if (cocktailRepository.Models.FirstOrDefault(x => x.Name == cocktailName && x.Size == size) != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }
            else
            {
                if (cocktailTypeName == nameof(Hibernation))
                {
                    cocktail = new Hibernation(cocktailName, size);
                }
                else if (cocktailTypeName == nameof(MulledWine))
                {
                    cocktail = new MulledWine(cocktailName, size);
                }
                var selectedBooth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
                selectedBooth.CocktailMenu.AddModel(cocktail);
            }
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy = null;
            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName).TrimEnd();
            }
            else if (delicacyRepository.Models.FirstOrDefault(x => x.Name == delicacyName) != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            else
            {
                if (delicacyTypeName == nameof(Gingerbread))
                {
                    delicacy = new Gingerbread(delicacyName);
                }
                else if (delicacyTypeName == nameof(Stolen))
                {
                    delicacy = new Stolen(delicacyName);
                }
                //delicacyRepository.AddModel(delicacy);
                var selectedBooth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
                selectedBooth.DelicacyMenu.AddModel(delicacy);
            }

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            booth.Charge();
            booth.ChangeStatus();

            return sb.ToString().TrimEnd();

        }

        public string ReserveBooth(int countOfPeople)
        {
            var availableBooth = boothRepository.Models.Where(r => r.IsReserved == false && r.Capacity >= countOfPeople)
                 .OrderBy(c => c.Capacity).ThenByDescending(c => c.BoothId).FirstOrDefault();

            if (availableBooth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            availableBooth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, availableBooth.BoothId, countOfPeople);

        }
            

        public string TryOrder(int boothId, string order)
        {
            string [] arr =order.Split("/").ToArray();

            string itemTypeName = arr[0];
            string itemName = arr[1];
            int countOfPieces = int.Parse(arr[2]);
            string cocktailSize = "";
            bool isCocktail= false;
            if (arr.Length>3)
            {
                cocktailSize = arr[3];
                isCocktail= true;
            }

            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (itemTypeName != nameof(Hibernation) && itemTypeName !=nameof(MulledWine) 
                && itemTypeName != nameof(Stolen) && itemTypeName != nameof (Gingerbread))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }
            else if (cocktailRepository.Models.Where(n=>n.Name == itemName) == null ||
                    delicacyRepository.Models.Where(n=>n.Name == itemName) == null)
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName,itemName);
            }
            else if (isCocktail)
            {
                double price = 0;
                if (itemTypeName != nameof(Hibernation) && itemTypeName != nameof(MulledWine) ||
                    booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName && x.Size == cocktailSize) == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName,cocktailSize,itemName);
                }
                else if (itemTypeName==nameof(Hibernation))
                {
                    price =booth.CocktailMenu.Models.FirstOrDefault(n => n.Name == itemName ).Price;
                }
                else if (itemTypeName == nameof(MulledWine))
                {
                    price = booth.CocktailMenu.Models.FirstOrDefault(n => n.Name == itemName).Price;
                }
                booth.UpdateCurrentBill(price * countOfPieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfPieces, itemName);
            }
            else
            {
                double price = 0;
                if (itemTypeName != nameof(Stolen) && itemTypeName != nameof(Gingerbread) ||
                    booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == itemName) == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);

                }
                else if (itemTypeName == nameof(Stolen))
                {
                    price = booth.DelicacyMenu.Models.FirstOrDefault(n => n.Name == itemName).Price;
                }
                else if (itemTypeName == nameof(Gingerbread))
                {
                    price = booth.DelicacyMenu.Models.FirstOrDefault(n => n.Name == itemName).Price;
                }
                booth.UpdateCurrentBill(price * countOfPieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId,countOfPieces, itemName);
            }


        }
    }
}
