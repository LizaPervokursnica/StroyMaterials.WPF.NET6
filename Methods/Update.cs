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
        var firstProductId = Guid.NewGuid();
        var secondProductId = Guid.NewGuid();

        //Заполнение таблицы товаров, если в ней нет записей
        if (context.Product.Count() == 0)
        {
            var webClient = new WebClient();

            #region Производители
            var manufacturerМ500 = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "М500",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerIzontorg = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Изостронг",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerKnauf = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Knauf",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerMixMaster = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "MixMaster",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerLSR = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "ЛСР",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerVolma = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "ВОЛМА",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerVinylon = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Vinylon",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerPavlovZavod = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Павловский завод",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerWeber = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Weber",
                ManufacturerAdress = GetRandomAddress()

            };
            var manufacturerHesler = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Hesler",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerArmero = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Armero",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerWenzoRoma = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Wenzo Roma",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerKILIMGRIN = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "KILIMGRIN",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerIstok = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Исток",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerRUIZ = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "RUIZ",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerHusqvarna = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Husqvarna",
                ManufacturerAdress = GetRandomAddress()
            };
            var manufacturerDelta = new Manufacturer()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Delta",
                ManufacturerAdress = GetRandomAddress()
            };
            #endregion

            #region Поставщики
            var providerМ500 = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "М500",
                ProviderAdress = GetRandomAddress()
            };
            var providerIzontorg = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "Изостронг",
                ProviderAdress = GetRandomAddress()
            };
            var providerKnauf = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "Knauf",
                ProviderAdress = GetRandomAddress()
            };
            var providerMixMaster = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "MixMaster",
                ProviderAdress = GetRandomAddress()
            };
            var providerLSR = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "ЛСР",
                ProviderAdress = GetRandomAddress()
            };
            var providerVolma = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "ВОЛМА",
                ProviderAdress = GetRandomAddress()
            };
            var providerVinylon = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "Vinylon",
                ProviderAdress = GetRandomAddress()
            };
            var providerPavlovZavod = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "Павловский завод",
                ProviderAdress = GetRandomAddress()
            };
            var providerWeber = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "Weber",
                ProviderAdress = GetRandomAddress()

            };
            var providerHesler = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "Hesler",
                ProviderAdress = GetRandomAddress()
            };
            var providerArmero = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "Armero",
                ProviderAdress = GetRandomAddress()
            };
            var providerWenzoRoma = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "Wenzo Roma",
                ProviderAdress = GetRandomAddress()
            };
            var providerKILIMGRIN = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "KILIMGRIN",
                ProviderAdress = GetRandomAddress()
            };
            var providerIstok = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "Исток",
                ProviderAdress = GetRandomAddress()
            };
            var providerRUIZ = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "RUIZ",
                ProviderAdress = GetRandomAddress()
            };
            var providerHusqvarna = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "Husqvarna",
                ProviderAdress = GetRandomAddress()
            };
            var providerDelta = new Provider()
            {
                Id = Guid.NewGuid(),
                ProviderName = "Delta",
                ProviderAdress = GetRandomAddress()
            };
            #endregion

            #region Категории товаров
            var categoryGeneralMaterial = new ProductCategory()
            {
                Id = Guid.NewGuid(),
                CategoryName = "Общестроительные материалы"
            };
            var categoryWallAndFront = new ProductCategory()
            {
                Id = Guid.NewGuid(),
                CategoryName = "Стеновые и фасадные материалы"
            };
            var categoryDryMix = new ProductCategory()
            {
                Id = Guid.NewGuid(),
                CategoryName = "Сухие строительные смеси и гидроизоляция"
            };
            var categoryHandTool = new ProductCategory()
            {
                Id = Guid.NewGuid(),
                CategoryName = "Ручной инструмент"
            };
            var categoryProtectiveTool = new ProductCategory()
            {
                Id = Guid.NewGuid(),
                CategoryName = "Защита лица, глаз, головы"
            };
            #endregion

            #region Товары
            var products = new List<Product>()
            {
                new Product()
                {
                    Id = firstProductId, ProductArticle = "PMEZMH", MaxDiscount = 10, ProductImage = webClient.DownloadData("https://github.com/LizaPervokursnica/ProjectAssets/blob/main/StroyMaterialsImages/PMEZMH.jpg?raw=true"), 
                    ProductName = "Цемент", CurrentDiscount = 8, AmountInStock = 34,
                    ProductDescription = "Цемент Евроцемент М500 Д0 ЦЕМ I 42,5 50 кг", Сost = 440, Provider = providerМ500, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryGeneralMaterial, Manufacturer = manufacturerМ500,
                },
                new Product()
                {
                    Id = secondProductId, ProductArticle = "BPV4MM", MaxDiscount = 13, ProductImage = webClient.DownloadData("https://github.com/LizaPervokursnica/ProjectAssets/blob/main/StroyMaterialsImages/BPV4MM.jpg?raw=true"), 
                    ProductName = "Пленка техническая", CurrentDiscount = 8, AmountInStock = 2,
                    ProductDescription = "Пленка техническая полиэтиленовая Изостронг 60 мк 3 м рукав 1,5 м, пог.м", Сost = 8, Provider = providerIzontorg, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryGeneralMaterial, Manufacturer = manufacturerIzontorg
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "JVL42J", MaxDiscount = 1, ProductImage = webClient.DownloadData("https://github.com/LizaPervokursnica/ProjectAssets/blob/main/StroyMaterialsImages/JVL42J.jpg?raw=true"), 
                    ProductName = "Пленка техническая", CurrentDiscount = 4, AmountInStock = 34,
                    ProductDescription = "Пленка техническая полиэтиленовая Изостронг 100 мк 3 м рукав 1,5 м, пог.м", Сost = 13, Provider = providerIzontorg, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryGeneralMaterial, Manufacturer = manufacturerIzontorg
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "F895RB", MaxDiscount = 17, ProductImage = webClient.DownloadData("https://github.com/LizaPervokursnica/ProjectAssets/blob/main/StroyMaterialsImages/F895RB.jpg?raw=true"), 
                    ProductName = "Песок строительный", CurrentDiscount = 6, AmountInStock = 7,
                    ProductDescription = "Песок строительный 50 кг", Сost = 102, Provider = providerKnauf, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryGeneralMaterial, Manufacturer = manufacturerKnauf
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "3XBOTN", MaxDiscount = 14, ProductImage = webClient.DownloadData("https://github.com/LizaPervokursnica/ProjectAssets/blob/main/StroyMaterialsImages/3XBOTN.jpeg?raw=true"), 
                    ProductName = "Керамзит фракция", CurrentDiscount = 5, AmountInStock = 21,
                    ProductDescription = "Керамзит фракция 10-20 мм 0,05 куб.м", Сost = 110, Provider = providerMixMaster, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryGeneralMaterial, Manufacturer = manufacturerMixMaster
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "3L7RCZ", MaxDiscount = 7, ProductImage = webClient.DownloadData("https://github.com/LizaPervokursnica/ProjectAssets/blob/main/StroyMaterialsImages/3L7RCZ.jpg?raw=true"), 
                    ProductName = "Газобетон", CurrentDiscount = 2, AmountInStock = 20,
                    ProductDescription = "Газобетон ЛСР 100х250х625 мм D400", Сost = 7400, Provider = providerLSR, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryWallAndFront, Manufacturer = manufacturerLSR
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "S72AM3", MaxDiscount = 9, ProductImage = webClient.DownloadData("https://github.com/LizaPervokursnica/ProjectAssets/blob/main/StroyMaterialsImages/S72AM3.jpg?raw=true"), 
                    ProductName = "Пазогребневая плита", CurrentDiscount = 5, AmountInStock = 35,
                    ProductDescription = "Пазогребневая плита ВОЛМА Гидро 667х500х80 мм полнотелая", Сost = 500, Provider = providerVolma, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryWallAndFront, Manufacturer = manufacturerVolma
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "2G3280", MaxDiscount = 16, ProductImage = webClient.DownloadData("https://github.com/LizaPervokursnica/ProjectAssets/blob/main/StroyMaterialsImages/2G3280.jpg?raw=true"), 
                    ProductName = "Угол наружный", CurrentDiscount = 9, AmountInStock = 20,
                    ProductDescription = "Угол наружный Vinylon 3050 мм серо-голубой", Сost = 795, Provider = providerVinylon, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryWallAndFront, Manufacturer = manufacturerVolma
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "MIO8YV", MaxDiscount = 9, ProductImage = webClient.DownloadData("https://github.com/LizaPervokursnica/ProjectAssets/blob/main/StroyMaterialsImages/MIO8YV.jpg?raw=true"), 
                    ProductName = "Кирпич", CurrentDiscount = 9, AmountInStock = 31,
                    ProductDescription = "Кирпич рядовой Боровичи полнотелый М150 250х120х65 мм 1NF", Сost = 30, Provider = providerVolma, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryWallAndFront, Manufacturer = manufacturerVolma
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "UER2QD", MaxDiscount = 20, ProductImage = webClient.DownloadData("https://github.com/LizaPervokursnica/ProjectAssets/blob/main/StroyMaterialsImages/UER2QD.jpg?raw=true"), 
                    ProductName = "Скоба для пазогребневой плиты", CurrentDiscount = 8, AmountInStock = 27,
                    ProductDescription = "Скоба для пазогребневой плиты Knauf С1 120х100 мм", Сost = 25, Provider = providerKnauf, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryWallAndFront, Manufacturer = manufacturerKnauf
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductName = "Кирпич", ProductArticle = "MIO8YV", CurrentDiscount = 3, MaxDiscount = 10, AmountInStock = 26,
                    ProductDescription = "Кирпич рядовой силикатный Павловский завод полнотелый М200 250х120х65 мм 1NF", Сost = 16, Provider = providerPavlovZavod, MeasurementUnit = MeasurementUnits.piece,
                    ProductCategory = categoryWallAndFront, Manufacturer = manufacturerPavlovZavod
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "LPDDM4", MaxDiscount = 17, ProductName = "Штукатурка гипсовая",
                    ProductDescription = "Штукатурка гипсовая Knauf Ротбанд 30 кг", Сost = 500, Provider = providerKnauf, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryDryMix, Manufacturer = manufacturerKnauf, CurrentDiscount = 6, AmountInStock = 38
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "LQ48MW", MaxDiscount = 16, ProductName = "Штукатурка гипсовая",
                    ProductDescription = "Штукатурка гипсовая Knauf МП-75 машинная 30 кг", Сost = 462, Provider = providerWeber, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryDryMix, Manufacturer = manufacturerWeber, CurrentDiscount = 6, AmountInStock = 33
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "O43COU", MaxDiscount = 9, ProductName = "Шпаклевка",
                    ProductDescription = "Шпаклевка полимерная Weber.vetonit LR + для сухих помещений белая 20 кг", Сost = 750, Provider = providerVolma, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryDryMix, Manufacturer = manufacturerVolma, CurrentDiscount = 1, AmountInStock =16
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "M26EXW", MaxDiscount = 8, ProductName = "Клей для плитки, керамогранита и камня",
                    ProductDescription = "Клей для плитки, керамогранита и камня Крепс Усиленный серый (класс С1) 25 кг", Сost = 340, Provider = providerKnauf, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryDryMix, Manufacturer = manufacturerKnauf, CurrentDiscount = 8, AmountInStock = 2
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "K0YACK", MaxDiscount = 9, ProductName = "Смесь цементно-песчаная",
                    ProductDescription = "Смесь цементно-песчаная (ЦПС) 300 по ТУ MixMaster Универсал 25 кг", Сost = 160, Provider = providerMixMaster, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryDryMix, Manufacturer = manufacturerMixMaster, CurrentDiscount = 8, AmountInStock = 19
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "ASPXSG", MaxDiscount = 17, ProductName = "Ровнитель",
                    ProductDescription = "Ровнитель (наливной пол) финишный Weber.vetonit 4100 самовыравнивающийся высокопрочный 20 кг", Сost = 711, Provider = providerWeber, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryDryMix, Manufacturer = manufacturerWeber, CurrentDiscount = 10, AmountInStock = 20
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "ZKQ5FF", MaxDiscount = 13, ProductName = "Лезвие для ножа",
                    ProductDescription = "Лезвие для ножа Hesler 18 мм прямое (10 шт.)", Сost = 65, Provider = providerHesler, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryHandTool, Manufacturer = manufacturerHesler, CurrentDiscount = 6, AmountInStock = 6
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "4WZEOT", MaxDiscount = 2, ProductName = "Лезвие для ножа",
                    ProductDescription = "Лезвие для ножа Armero 18 мм прямое (10 шт.)", Сost = 110, Provider = providerArmero, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryHandTool, Manufacturer = manufacturerArmero, CurrentDiscount = 6, AmountInStock = 17
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "4JR1HN", MaxDiscount = 3, ProductName = "Шпатель",
                    ProductDescription = "Шпатель малярный 100 мм с пластиковой ручкой", Сost = 26, Provider = providerHesler, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryHandTool, Manufacturer = manufacturerHesler, CurrentDiscount = 6, AmountInStock = 7
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "Z3XFSP", MaxDiscount = 19, ProductName = "Нож строительный",
                    ProductDescription = "Нож строительный Hesler 18 мм с ломающимся лезвием пластиковый корпус", Сost = 63, Provider = providerHesler, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryHandTool, Manufacturer = manufacturerHesler, CurrentDiscount = 8, AmountInStock = 5
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "I6MH89", MaxDiscount = 12, ProductName = "Валик",
                    ProductDescription = "Валик Wenzo Roma полиакрил 250 мм ворс 18 мм для красок грунтов и антисептиков на водной основе с рукояткой", Сost = 326, 
                    Provider = providerWenzoRoma, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryHandTool, Manufacturer = manufacturerWenzoRoma, CurrentDiscount = 6, AmountInStock = 3
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "83M5ME", MaxDiscount = 16, ProductName = "Кисть",
                    ProductDescription = "Кисть плоская смешанная щетина 100х12 мм для красок и антисептиков на водной основе", Сost = 122, Provider = 
                    providerArmero, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryHandTool, Manufacturer = manufacturerArmero, CurrentDiscount = 9, AmountInStock = 26
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "61PGH3", MaxDiscount = 2, ProductName = "Очки защитные",
                    ProductDescription = "Очки защитные Delta Plus KILIMANDJARO (KILIMGRIN) открытые с прозрачными линзами", Сost = 184, Provider = 
                    providerKILIMGRIN, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryProtectiveTool, Manufacturer = manufacturerKILIMGRIN, CurrentDiscount = 6, AmountInStock = 25
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "GN6ICZ", MaxDiscount = 10, ProductName = "Каска защитная ",
                    ProductDescription = "Каска защитная Исток (КАС001О) оранжевая", Сost = 154, 
                    Provider = providerIstok, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryProtectiveTool, Manufacturer = manufacturerIstok, CurrentDiscount = 6, AmountInStock = 8
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "Z3LO0U", MaxDiscount = 19, ProductName = "Очки защитные ",
                    ProductDescription = "Очки защитные Delta Plus RUIZ (RUIZ1VI) закрытые с прозрачными линзами", Сost = 228, 
                    Provider = providerRUIZ, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryProtectiveTool, Manufacturer = manufacturerRUIZ, CurrentDiscount = 9, AmountInStock = 11
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "QHNOKR", MaxDiscount = 6, ProductName = "Маска защитная",
                    ProductDescription = "Маска защитная Исток (ЩИТ001) ударопрочная и термостойкая", Сost = 251, 
                    Provider = providerIstok, MeasurementUnit = MeasurementUnits.piece, 
                    ProductCategory = categoryProtectiveTool, Manufacturer = manufacturerIstok, CurrentDiscount = 2, AmountInStock = 22
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "EQ6RKO", MaxDiscount = 17, ProductName = "Подшлемник",
                    ProductDescription = "Подшлемник для каски одноразовый", Сost = 36, 
                    Provider = providerHusqvarna, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryProtectiveTool, Manufacturer = manufacturerHusqvarna, CurrentDiscount = 3, AmountInStock = 22
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "81F1WG", MaxDiscount = 1, ProductName = "Каска защитная",
                    ProductDescription = "Каска защитная Delta Plus BASEBALL DIAMOND V UP (DIAM5UPBCFLBS) белая", Сost = 1500, 
                    Provider = providerDelta, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryProtectiveTool, Manufacturer = manufacturerDelta, CurrentDiscount = 2, AmountInStock = 13
                },
                new Product()
                {
                    Id = Guid.NewGuid(), ProductArticle = "0YGHZ7", MaxDiscount = 9, ProductName = "Очки защитные ",
                    ProductDescription = "Очки защитные Husqvarna Clear (5449638-01) открытые с прозрачными линзами", Сost = 700, 
                    Provider = providerHusqvarna, MeasurementUnit = MeasurementUnits.piece,  
                    ProductCategory = categoryProtectiveTool, Manufacturer = manufacturerHusqvarna, CurrentDiscount = 9, AmountInStock = 36
                },
            };

            #endregion

            context.Product.AddRange(products);
            context.SaveChanges();
        };

        //Заполнение таблицы пользователей, если в ней нет записей
        if (context.User.Count() == 0)
        {

            #region Пользователи
            var users = new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(), FirstName = "Амина", MiddleName = "Кирилловна", LastName = "Басова", 
                    Login = "klh7pi4rcbtz@gmail.com", Password = "2L6KZG", Role = Roles.Admin
                },
                new User()
                {
                    Id = Guid.NewGuid(), FirstName = "Андрей", MiddleName = "Денисович", LastName = "Михайлов",
                    Login = "gn0354mbiork@outlook.com", Password = "uzWC67", Role = Roles.Admin
                },
                new User()
                {
                    Id = Guid.NewGuid(), FirstName = "Егор", MiddleName = "Александрович", LastName = "Сидоров",
                    Login = "1o4l05k8dwpv@yahoo.com", Password = "8ntwUp", Role = Roles.Admin
                },
                new User()
                {
                    Id = Guid.NewGuid(), FirstName = "Ульяна", MiddleName = "Ивановна", LastName = "Аксенова",
                    Login = "hsqixl2vebuz@mail.com", Password = "YOyhfR", Role = Roles.Manager
                },
                new User()
                {
                    Id = Guid.NewGuid(), FirstName = "Камила", MiddleName = "Ивановна", LastName = "Васильева",
                    Login = "towkse0hf26b@outlook.com", Password = "RSbvHv", Role = Roles.Manager
                },
                new User()
                {
                    Id = Guid.NewGuid(), FirstName = "Артём", MiddleName = "Родионович", LastName = "Ильин",
                    Login = "khx0ncdwz4uj@gmail.com", Password = "rwVDh9", Role = Roles.Manager
                },
                new User()
                {
                    Id = Guid.NewGuid(), FirstName = "Василиса", MiddleName = "Фёдоровна", LastName = "Васильева",
                    Login = "01zji3wfuq7h@outlook.com", Password = "LdNyos", Role = Roles.Client
                },
                new User()
                {
                    Id = Guid.NewGuid(), FirstName = "Василиса", MiddleName = "Матвеевна", LastName = "Кудрявцева",
                    Login = "am65k18q7bwp@mail.com", Password = "gynQMT", Role = Roles.Client
                },
                new User()
                {
                    Id = Guid.NewGuid(), FirstName = "Николь", MiddleName = "Святославовна", LastName = "Кириллова",
                    Login = "wt9q8i6ypx47@outlook.com", Password = "AtnDjr", Role = Roles.Client
                },
                new User()
                {
                    Id = Guid.NewGuid(), FirstName = "Полина", MiddleName = "Артёмовна", LastName = "Андреева",
                    Login = "4o72gufv3xlz@tutanota.com", Password = "JlFRCZ", Role = Roles.Client
                },
                new User()
                {
                    Id = Guid.NewGuid(), FirstName = "Дора", MiddleName = "Не", LastName = "Дура",
                    Login = "admin", Password = "admin", Role = Roles.Admin
                }
            };

            #endregion

            context.User.AddRange(users);
            context.SaveChanges();
        };

        //Заполнение таблицы пунктов выдачи, если в ней нет записей
        if (context.DeliveryPoint.Count() == 0)
        {
            #region Пункты выдачи
            var deliveryPoints = new List<DeliveryPoint>()
            {
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "344288", PointAdress = "г. Сыктывкар, ул. Чехова, 1"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "614164", PointAdress = "г.Сыктывкар,  ул. Степная, 30"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "394242", PointAdress = "г. Сыктывкар, ул. Коммунистическая, 43"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "660540", PointAdress = "г. Сыктывкар, ул. Солнечная, 25"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "125837", PointAdress = "г. Сыктывкар, ул. Шоссейная, 40"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "125703", PointAdress = "г. Сыктывкар, ул. Партизанская, 49"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "625283", PointAdress = "г. Сыктывкар, ул. Победы, 46"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "614611", PointAdress = "г. Сыктывкар, ул. Молодежная, 50"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "454311", PointAdress = "г.Сыктывкар, ул. Новая, 19"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "660007", PointAdress = "г.Сыктывкар, ул. Октябрьская, 19"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "603036", PointAdress = "г. Сыктывкар, ул. Садовая, 4"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "450983", PointAdress = "г.Сыктывкар, ул. Комсомольская, 26"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "394782", PointAdress = "г. Сыктывкар, ул. Чехова, 3"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "603002", PointAdress = "г. Сыктывкар, ул. Дзержинского, 28"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "450558", PointAdress = "г. Сыктывкар, ул. Набережная, 30"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "394060", PointAdress = "г.Сыктывкар, ул. Фрунзе, 43"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "410661", PointAdress = "г. Сыктывкар, ул. Школьная, 50"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "625590", PointAdress = "г. Сыктывкар, ул. Коммунистическая, 20"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "625683", PointAdress = "г. Сыктывкар, ул. 8 Марта"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "400562", PointAdress = "г. Сыктывкар, ул. Зеленая, 32"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "614510", PointAdress = "г. Сыктывкар, ул. Маяковского, 47"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "410542", PointAdress = "г. Сыктывкар, ул. Светлая, 46"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "620839", PointAdress = "г. Сыктывкар, ул. Цветочная, 8"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "443890", PointAdress = "г. Сыктывкар, ул. Коммунистическая, 1"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "603379", PointAdress = "г. Сыктывкар, ул. Спортивная, 46"},
                new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "603721", PointAdress = "г. Сыктывкар, ул. Гоголя, 41"},
            };
            #endregion

            context.DeliveryPoint.AddRange(deliveryPoints);
            context.SaveChanges();
        }

        //Заполнение таблицы заказов, если в ней нет записей
        if (context.Order.Count() == 0)
        {
            var firstOrderId = Guid.NewGuid();

            var orders = new List<Order>()
            {
                new Order()
                {
                    Id = firstOrderId, DeliveryDate = new DateTime(2022, 5, 21), Statuse = Statuses.Close,
                    GetCode = 701, DeliveryPoint = new DeliveryPoint(){Id = Guid.NewGuid(), PointName = "190949", PointAdress = "г. Сыктывкар, ул. Мичурина, 26" }, RegistrationDate = new DateTime(2022, 5, 15)
                },
                new Order()
                {
                    Id = Guid.NewGuid(), DeliveryDate = new DateTime(2022, 5, 21), Statuse = Statuses.New,
                    GetCode = 702, DeliveryPoint = new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "630201", PointAdress = "г. Сыктывкар, ул. Комсомольская, 17"}, RegistrationDate = new DateTime(2022, 5, 15),
                },
                new Order()
                {
                    Id = Guid.NewGuid(), DeliveryDate = new DateTime(2022, 5, 21), Statuse = Statuses.Close,
                    GetCode = 703, DeliveryPoint = new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "625560", PointAdress = "г. Сыктывкар, ул. Некрасова, 12"}, RegistrationDate = new DateTime(2022, 5, 15),
                    User = new User(){Id = Guid.NewGuid(), FirstName = "Николь", LastName = "Кириллова", MiddleName ="Святославовна", Login = GetRandomEmail(), Password = GetRandomWords(), Role = Roles.Client}
                },
                new Order()
                {
                    Id = Guid.NewGuid(), DeliveryDate = new DateTime(2022, 5, 21), Statuse = Statuses.New,
                    GetCode = 704, DeliveryPoint = new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "450375", PointAdress = "г. Сыктывкар ул. Клубная, 44"}, RegistrationDate = new DateTime(2022, 5, 15),
                },
                new Order()
                {
                    Id = Guid.NewGuid(), DeliveryDate = new DateTime(2022, 5, 21), Statuse = Statuses.Close,
                    GetCode = 705, DeliveryPoint = new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "426030", PointAdress = "г. Сыктывкар, ул. Маяковского, 44"}, RegistrationDate = new DateTime(2022, 5, 15),
                    User = new User(){Id = Guid.NewGuid(), FirstName = "Василиса", LastName = "Кудрявцева", MiddleName ="Матвеевна", Login = GetRandomEmail(), Password = GetRandomWords(), Role = Roles.Client}
                },
                new Order()
                {
                    Id = Guid.NewGuid(), DeliveryDate = new DateTime(2022, 5, 21), Statuse = Statuses.New,
                    GetCode = 706, DeliveryPoint = new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "614753", PointAdress = "г. Сыктывкар, ул. Полевая, 35"}, RegistrationDate = new DateTime(2022, 5, 15),
                },
                new Order()
                {
                    Id = Guid.NewGuid(), DeliveryDate = new DateTime(2022, 5, 21), Statuse = Statuses.Close,
                    GetCode = 707, DeliveryPoint = new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "630370", PointAdress = "г. Сыктывкар, ул. Шоссейная, 24"}, RegistrationDate = new DateTime(2022, 5, 15),
                    User = new User(){Id = Guid.NewGuid(), FirstName = "Полина", LastName = "Андреева", MiddleName ="Артёмовна", Login = GetRandomEmail(), Password = GetRandomWords(), Role = Roles.Client}
                },
                new Order()
                {
                    Id = Guid.NewGuid(), DeliveryDate = new DateTime(2022, 5, 21), Statuse = Statuses.New,
                    GetCode = 708, DeliveryPoint = new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "125061", PointAdress = "г. Сыктывкар, ул. Подгорная, 8"}, RegistrationDate = new DateTime(2022, 5, 15),
                },
                new Order()
                {
                    Id = Guid.NewGuid(), DeliveryDate = new DateTime(2022, 5, 21), Statuse = Statuses.Close,
                    GetCode = 709, DeliveryPoint = new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "420151", PointAdress = "г. Сыктывкар, ул. Вишневая, 32"}, RegistrationDate = new DateTime(2022, 5, 15),
                },
                new Order()
                {
                    Id = Guid.NewGuid(), DeliveryDate = new DateTime(2022, 5, 21), Statuse = Statuses.Close,
                    GetCode = 710, DeliveryPoint = new DeliveryPoint(){ Id = Guid.NewGuid(), PointName = "410172", PointAdress = "г. Сыктывкар, ул. Северная, 13"}, RegistrationDate = new DateTime(2022, 5, 15),
                    User = new User(){Id = Guid.NewGuid(), FirstName = "Василиса", LastName = "Васильева", MiddleName ="Фёдоровна", Login = GetRandomEmail(), Password = GetRandomWords(), Role = Roles.Client}
                },
            };

            var orderDetails = new List<ProductAmount>()
            {
                new ProductAmount(){Id = Guid.NewGuid(), OrderId = firstOrderId, Amount = 2, ProductId = firstProductId},
                new ProductAmount(){Id = Guid.NewGuid(), OrderId = firstOrderId, Amount = 2, ProductId = secondProductId},
            };

            context.Order.AddRange(orders);
            context.ProductAmount.AddRange(orderDetails);
            context.SaveChanges();
        }
    }
}