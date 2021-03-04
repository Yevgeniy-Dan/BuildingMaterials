using BuildingMaterials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingMaterials.Data
{
    public class DbInitializer
    {
        public static void Initialize(BuildingMaterialsContext context)
        {
            //context.Database.EnsureCreated();

            //Ищем поставщиков
            if (context.Suppliers.Any())
            {
                return; // БД заполнена
            }

            var suppliers = new Supplier[]
            {
                new Supplier{ChiefFullName="Гайчук Трофим ", Address="Киев, Киево-Святошинский р-н, Петропавловская Борщаговка, ул. Петропавловская, д. 6 ТЦ \"4ROOM\"", Phone="+38 (097) 899-45-34", CompanyName ="ООО «МЕТРОТАЙЛ-УКРАИНА»"},

                new Supplier{ChiefFullName="Семёнов Марат",
                Address="Одесса, одесса", Phone="+38 (000) 000-00-00", CompanyName="ООО «НИКОЛЬ ЮКРЕЙН»"},

                new Supplier{ChiefFullName="Острожский Валерий ", Address="Вишневое, ул. Киевская, 17", CompanyName="ООО Комплекс Дах", Phone="+38 (044) 594-21-21"},

                new Supplier{CompanyName="Вистарк Евроклинкер", Phone="+38 (067) 575-02-22", Address="Киев, ул. Федора Эрнста, 16 Б", ChiefFullName="Макаров Эдуард"},

                new Supplier{ChiefFullName="Гамула Тимофей", Address="Киев, пр-т Победы, 136, оф. 34", Phone="+38 (067) 325-25-58", CompanyName="ROOFART"},

                new Supplier{CompanyName="ООО \"ВЕЛЮКС Украина\"", Phone="+38 (0800) 50-50-20", Address="Киев, ул. Ревуцкого, 44а", ChiefFullName="Батейко Олег"},

                new Supplier{ChiefFullName="Рогов Ярослав", Address="Харьков, -", Phone="-", CompanyName="ООО «БИГ «МЕГА СІТІ»"},

                new Supplier{CompanyName="САЮЗ", Phone="+38 (0352) 52-21-02", Address="Тернополь, ул. Полесская 3, 46000", ChiefFullName="Павлив Радислав"},

                new Supplier{ChiefFullName="Гришин Донат", Address="Обухов, г. Обухов, ул. Промышленная, 6, 08700", Phone="+38 (044) 391-31-92", CompanyName="«СEЛЛ-ФАСТ Украина»"},

                new Supplier{CompanyName="«Акведук водосточные системы»", Phone="+38 (044) 451-83-65", Address="Бровары, ул. Кутузова, 61", ChiefFullName="Фокин Закир"},

                 new Supplier{CompanyName="«Алютех-К»", Phone="+38 (044) 451-83-65", Address="Бровары, ул. Кутузова, 61", ChiefFullName="Фокин Закир"},

                 new Supplier{CompanyName="Экодом", Phone="+38 (093) 800-28-28", Address="Винница, ул. Хмельницкое шоссе 107 Б", ChiefFullName="Каськив Иван"},

                 new Supplier{CompanyName="ТПК", Phone="+38 (067) 323-99-83", Address="Киев, просп. Степана Бандеры, 8", ChiefFullName="Филатов Йозеф"},

                 new Supplier{CompanyName="Bukwood", Phone="+38 (099) 647-22-00", Address="Черновцы, пер. Складской, 1", ChiefFullName="Гришин Донат"},

                 new Supplier{CompanyName="Керми", Phone="+38 (000) 000-00-00", Address="Киев, -", ChiefFullName="Горобчук Роберт"},

                 new Supplier{CompanyName="Тайл", Phone="+38 (032) 227-27-94", Address="Нагоряны, ул. Стуса, 17-Б", ChiefFullName="Некрасов Борис"},

                 new Supplier{CompanyName="Альта-Профиль", Phone="+38 (044) 537-70-24", Address="Киев, ул. Старовокзальная, 24", ChiefFullName="Панфилов Леон"},

                 new Supplier{CompanyName="KAWMET", Phone="+38 (050) 424-30-41", Address="Львов, ул. Луганская, 1Б", ChiefFullName="Афанасьев Эрик"},

                 new Supplier{CompanyName="ООО \"Торговый Дом \"ЕВРОТОН\"\"", Phone="+38 (0332) 78-34-71", Address="Луцк, ул. Ершова, 11 офис 7", ChiefFullName="Аксёнов Эрик"}
            };

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            var materials = new Material[]
            {
                new Material{SupplierID=3, Name="Минеральная вата Неман+ М-11 Лайт 15 м2 11832555", Manufacturer="ООО \"ФАСАДТЕХНО\"", UnitCost=259.00M, MinimumBatch=1, ShelfLife=520},

                new Material{SupplierID=5, Name="Минеральная вата Неман+ М-11 Лайт 15 м2 11832555", Manufacturer="ООО \"ФАСАДТЕХНО\"", UnitCost=579.73M, MinimumBatch=5, ShelfLife=180},

                new Material{SupplierID=10, Name="Гидроизоляционая смесь Ceresit СR-65 25 кг (IG25012)", Manufacturer="Royal House (Роял Хаус)", UnitCost=396M, MinimumBatch=10, ShelfLife=50},

                new Material{SupplierID=10, Name="Грунтовка глубокопроникающая Anserglob EG 58 10 л Прозрачная", Manufacturer="ZEPPELIN (ЦЕППЕЛИН УКРАИНА, ООО, ТМ КАТЕРПИЛЛЕР)", UnitCost=1856.99M, MinimumBatch=5, ShelfLife=150},

                new Material{SupplierID=5, Name="Гидроизоляционная мастика Ceresit CL 51 Express 7 кг (CR1329158)", Manufacturer="АВТЕК, ООО", UnitCost=1350M, MinimumBatch=10, ShelfLife=450},

                new Material{SupplierID=10, Name="Поликарбонат Rober 2000 x 1045 x 0.5 мм трапеция Прозрачный (4250185150083)", Manufacturer="БОШ ТЕРМОТЕХНИКА (РОБЕРТ БОШ ЛТД, ООО)", UnitCost=469M, MinimumBatch=45, ShelfLife=300}
            };

            context.Materials.AddRange(materials);
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order{MaterialID=materials.Single(m=>m.ID==1).ID, Quantity=10, Unit="кг", DeliveryDate=DateTime.Parse("2021-03-13")},

                new Order{MaterialID=materials.Single(m=>m.ID==2).ID, Quantity=100, Unit="л", DeliveryDate=DateTime.Parse("2021-03-13")},

                new Order{MaterialID=materials.Single(m=>m.ID==3).ID, Unit="кг", DeliveryDate=DateTime.Parse("2021-03-13")},

                new Order{MaterialID=materials.Single(m=>m.ID==4).ID, Quantity=90, Unit="кг", DeliveryDate=DateTime.Parse("2021-03-13")},

                new Order{MaterialID=materials.Single(m=>m.ID==5).ID, Quantity=10, Unit="кг", DeliveryDate=DateTime.Parse("2021-03-13")},

                new Order{MaterialID=materials.Single(m=>m.ID==6).ID, Quantity=100, Unit="палет", DeliveryDate=DateTime.Parse("2021-03-13")},
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
