using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class Bank : IBank
    {
        private string name;
        private List<ILoan> loans;
        private List<IClient> clients;

        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.loans = new List<ILoan>();
            this.clients = new List<IClient>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value;
            }
        }
        public int Capacity {  get; private set; }

        public IReadOnlyCollection<ILoan> Loans => loans;

        public IReadOnlyCollection<IClient> Clients => clients;

        public void AddClient(IClient Client)
        {
            if(Clients.Count<Capacity)
            {
                clients.Add(Client);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void AddLoan(ILoan loan)
        {
            loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}, Type: {GetType().Name}");
            sb.Append("Clients: ");
            if(clients.Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                var names = clients.Select(c => c.Name).ToArray();
                foreach (var client in this.clients)
                    sb.AppendLine(string.Join(" ", names));
            }
            sb.AppendLine($"Loans: {loans.Count}, Sum of Rates: {SumRates()}");
            return sb.ToString().TrimEnd();
        }

        public void RemoveClient(IClient Client)
        {
            clients.Remove(Client);
        }

        public double SumRates()
        {
           if(loans.Count == 0)
            {
                return 0;
            }
            return double.Parse(this.Loans.Select(l => l.InterestRate).Sum().ToString());
        }
    }
}
