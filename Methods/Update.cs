using StroyMaterials.DataAccess;
using StroyMaterials.Enums;
using StroyMaterials.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static PeanutButter.RandomGenerators.RandomValueGen;

namespace StroyMaterials.Methods;
public class Update
{
    public static void UpdateTables()
    {
        Context context = new Context();

        if (context.Customer.Count() == 0)
        {
            var customers = new List<Customer>() {
                new Customer(){
                Id = Guid.NewGuid(), FirstName = GetRandomFirstName(), LastName = GetRandomLastName(), PersonType = Enums.PersonTypes.individual,
                    Birthday = GetRandomDate(minDate: new DateTime(1950, 1, 1), maxDate: new DateTime(2000, 1, 1)),
                    PhoneNumber = $"+79{GetRandomInt(000000000, 999999999)}", Email = GetRandomEmail(), Gender = GetRandomEnum<Genders>(),
                    User = new User(){ Id = Guid.NewGuid(), Login = "customer", Password = "customer", Role = Enums.Roles.Customer }
                },
                new Customer(){
                Id = Guid.NewGuid(), FirstName = GetRandomFirstName(), LastName = GetRandomLastName(), PersonType = Enums.PersonTypes.individual,
                    Birthday = GetRandomDate(minDate: new DateTime(1950, 1, 1), maxDate: new DateTime(2000, 1, 1)),
                    PhoneNumber = $"+79{GetRandomInt(000000000, 999999999)}", Email = GetRandomEmail(), Gender = GetRandomEnum<Genders>(),
                    User = new User(){ Id = Guid.NewGuid(), Login = "guest", Password = "guest", Role = Enums.Roles.Guest }
                }};

            context.Customer.AddRange(customers);
            context.SaveChanges();
        }

        if (context.Employee.Count() == 0)
        {
            var employees = new List<Employee>() {
                new Employee()
                {
                   Id = Guid.NewGuid(), FirstName = GetRandomFirstName(), LastName = GetRandomLastName(), Position = new Position(){Id = Guid.NewGuid(), PositionName = "Администратор" },
                    Birthday = GetRandomDate(minDate: new DateTime(1950, 1, 1), maxDate: new DateTime(2000, 1, 1)), StartWork = DateTime.Now,
                    PhoneNumber = $"+79{GetRandomInt(000000000, 999999999)}", Email = GetRandomEmail(), Gender = GetRandomEnum<Genders>(),
                    User = new User(){ Id = Guid.NewGuid(), Login = "admin", Password = "admin", Role = Enums.Roles.Admin }
                },
                new Employee()
                {
                   Id = Guid.NewGuid(), FirstName = GetRandomFirstName(), LastName = GetRandomLastName(), Position = new Position(){Id = Guid.NewGuid(), PositionName = "Старший менеджер" },
                    Birthday = GetRandomDate(minDate: new DateTime(1950, 1, 1), maxDate: new DateTime(2000, 1, 1)), StartWork = DateTime.Now,
                    PhoneNumber = $"+79{GetRandomInt(000000000, 999999999)}", Email = GetRandomEmail(), Gender = GetRandomEnum<Genders>(),
                    User = new User(){ Id = Guid.NewGuid(), Login = "admin", Password = "admin", Role = Enums.Roles.Manager }
                }};
            context.Employee.AddRange(employees);
            context.SaveChanges();
        }

        if(context.Product.Count() == 0)
        {
            var provider = new Provider()
            {
                Id = Guid.NewGuid(),
                PersonType = PersonTypes.legal,
                CompanyName = "Трэп хаус",
                User = new User() { Id = Guid.NewGuid(), Login = "provider", Password = "provider", Role = Roles.Provider }
            };

            var webClient = new WebClient();
            var products = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(), Image = webClient.DownloadData("https://upload.wikimedia.org/wikipedia/commons/9/96/Dora_%282020-12-22%29.jpg"), ProductName = "Эй, Дора, готова?",
                    Description = "КАПЛИ КАПАЮТ НА АСФАЛЬТ", Сost = 4433.2, Provider = provider
                },
             new Product()
                {
                    Id = Guid.NewGuid(), Image = webClient.DownloadData("https://braer.ru/storage/products/ALAAA5/md/oblitsovochnyy_kirpich_krasnyy_gladkiy_1_nf.jpg"), ProductName = "Кирпич ГОСТ",
                    Description = "Хороший кирпич, крепкий", Сost = 333, Provider = provider
                }};
            context.Product.AddRange(products);
            context.SaveChanges();
        };
    }
}