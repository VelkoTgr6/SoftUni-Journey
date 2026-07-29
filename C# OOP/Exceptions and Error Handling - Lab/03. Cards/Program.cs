namespace _03._Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            char[] separators = { ' ', ',' };
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();
            foreach (var card in input)
            {
                try 
                {
                    string[] cardInfo = card.Split();
                    string face = cardInfo[0];
                    string suit = cardInfo[1];

                    Card currentCard = new Card(face, suit);
                    cards.Add(currentCard);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(String.Join(" ", cards));
        }
    }
    public class Card
    {
        
        public Card(string face, string suit)
        {
            if(IsValid(face,suit))
            {
                Face = face;
                Suit = suit;
            }
            else
            {
                throw new ArgumentException("Invalid card!");
            } 
        }

        public string Face {  get; set; }
        public string Suit { get; set; }
        private char Transform(string suit)
        {
            char spades = '\u2660';
            char hearts = '\u2665';
            char diamonds = '\u2666';
            char clubs = '\u2663';
            List<char> chars = new List<char> {spades,hearts,diamonds,clubs};
            switch(suit)
            {
                case "S":
                    return chars[0];
                case "H":
                    return chars[1];
                case "D":
                    return chars[2];
                case "C":
                    return chars[3];
                default:
                    return char.ToUpper(clubs);
            }
        }

        public override string ToString()
        { 
            return $"[{Face}{Transform(Suit)}]";
        }
        private bool IsValid(string face,string suit)
        {
            List<string> validFaces = new List<string>{ "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            List<string>validSuits=new List<string> { "S","H","D","C"};
            if (validFaces.Contains(face) && validSuits.Contains(suit))
            {
                return true;
            }
            return false;
        }


    }
}