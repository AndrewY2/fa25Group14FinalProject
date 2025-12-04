using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;

namespace fa25Group14FinalProject.Seeding
{
    public class SeedCards
    {
        public static void SeedAllCards(AppDbContext db)
        {
            //Create a counter and a flag so we will know which record is causing problems
            Int32 intCardsAdded = 0;
            String strCardNumber = "Begin";

            //List of cards to add or update
            List<Card> Cards = new List<Card>();


            // 1001 9010 Christopher Baker Visa
            Card c1001 = new Card()
            {
                //CardID = 1001,
                CardNumber = "3517193267072490",
                CardType = CardType.Visa
            };
            c1001.Customer = db.Users.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker");
            Cards.Add(c1001);

            // 1002 9010 Christopher Baker Mastercard
            Card c1002 = new Card()
            {
                //CardID = 1002,
                CardNumber = "5653264624505624",
                CardType = CardType.Mastercard
            };
            c1002.Customer = db.Users.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker");
            Cards.Add(c1002);

            // 1003 9012 Franco Broccolo Mastercard
            Card c1003 = new Card()
            {
                //CardID = 1003,
                CardNumber = "2340139018242888",
                CardType = CardType.Mastercard
            };
            c1003.Customer = db.Users.FirstOrDefault(u => u.FirstName == "Franco" && u.LastName == "Broccolo");
            Cards.Add(c1003);

            // 1004 9013 Wendy Chang Visa
            Card c1004 = new Card()
            {
                //CardID = 1004,
                CardNumber = "4888561830797648",
                CardType = CardType.Visa
            };
            c1004.Customer = db.Users.FirstOrDefault(u => u.FirstName == "Wendy" && u.LastName == "Chang");
            Cards.Add(c1004);

            // 1005 9014 Lim Chou AmericanExpress
            Card c1005 = new Card()
            {
                //CardID = 1005,
                CardNumber = "7874839329412510",
                CardType = CardType.AmericanExpress
            };
            c1005.Customer = db.Users.FirstOrDefault(u => u.FirstName == "Lim" && u.LastName == "Chou");
            Cards.Add(c1005);

            // 1006 9021 Jeffrey Hampton Visa
            Card c1006 = new Card()
            {
                //CardID = 1006,
                CardNumber = "8882933892564410",
                CardType = CardType.Visa
            };
            c1006.Customer = db.Users.FirstOrDefault(u => u.FirstName == "Jeffrey" && u.LastName == "Hampton");
            Cards.Add(c1006);

            // 1007 9034 Charles Miller Mastercard
            Card c1007 = new Card()
            {
                //CardID = 1007,
                CardNumber = "9577230402048890",
                CardType = CardType.Mastercard
            };
            c1007.Customer = db.Users.FirstOrDefault(u => u.FirstName == "Charles" && u.LastName == "Miller");
            Cards.Add(c1007);

            // 1008 9028 Ernest Lowe AmericanExpress
            Card c1008 = new Card()
            {
                //CardID = 1008,
                CardNumber = "3391194669212420",
                CardType = CardType.AmericanExpress
            };
            c1008.Customer = db.Users.FirstOrDefault(u => u.FirstName == "Ernest" && u.LastName == "Lowe");
            Cards.Add(c1008);

            // 1009 9035 Kelly Nelson Visa
            Card c1009 = new Card()
            {
                //CardID = 1009,
                CardNumber = "4186773703003410",
                CardType = CardType.Visa
            };
            c1009.Customer = db.Users.FirstOrDefault(u => u.FirstName == "Kelly" && u.LastName == "Nelson");
            Cards.Add(c1009);

            try //attempt to add or update the card
            {
                foreach (Card cardToAdd in Cards)
                {
                    //set the flag to the current card number to help with debugging
                    strCardNumber = cardToAdd.CardNumber;

                    //look to see if the card is in the database – assumes CardID is unique
                    Card dbCard = db.Cards.FirstOrDefault(c => c.CardID == cardToAdd.CardID);

                    //if the dbCard is null, this card is not in the database
                    if (dbCard == null)
                    {
                        //add the card to the database and save changes
                        db.Cards.Add(cardToAdd);
                        db.SaveChanges();

                        //update the counter to help with debugging
                        intCardsAdded += 1;
                    }
                    else //dbCard is not null – this card *is* in the database
                    {
                        //update all of the card's properties
                        dbCard.CardNumber = cardToAdd.CardNumber;
                        dbCard.CardType = cardToAdd.CardType;
                        dbCard.Customer = cardToAdd.Customer;

                        //update the database and save the changes
                        db.Update(dbCard);
                        db.SaveChanges();

                        //update the counter to help with debugging
                        intCardsAdded += 1;
                    }
                }
            }
            catch (Exception ex) //something went wrong with adding or updating
            {
                //Build a message using the flags we created
                String msg = " Cards added: " + intCardsAdded + "; Error on card " + strCardNumber;

                //throw the exception with the new message
                throw new InvalidOperationException(ex.ToString() + msg);
            }
        }
    }
}
