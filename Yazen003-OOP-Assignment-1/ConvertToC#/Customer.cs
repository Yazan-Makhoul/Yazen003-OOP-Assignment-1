namespace Yazen003_OOP_Assignment_1.ConvertToC_
{
    public sealed class Customer
    {

        public int Id { get; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string City { get; private set; }
        public bool IsVip { get; private set; }

        public Customer(int id, string name, string email, string city, bool isVip)
        {
            Id = id;
            Name = name;
            Email = email;
            City = city;
            IsVip = isVip;
        }

        public void UpdateContactInfo(string email, string city)
        {
            Email = email;
            City = city;
        }

        public void SetVipStatus(bool isVip) => IsVip = isVip;

        public void PrintDetails()
        {
            Console.WriteLine($"{Id}  {Name}  <{Email}>  {City}  vip={(IsVip ? "yes" : "no")}");
        }
    }

}

