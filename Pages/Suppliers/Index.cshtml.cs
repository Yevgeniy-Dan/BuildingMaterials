using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuildingMaterials.Data;
using BuildingMaterials.Models;

namespace BuildingMaterials.Pages.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly BuildingMaterialsContext _context;

        public IndexModel(BuildingMaterialsContext context)
        {
            _context = context;
        }

        //свойства, содержащие параметры сортировки
        public string ChiefNameSort { get; set; }
        public string CompanyNameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Supplier> Suppliers { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            ChiefNameSort = string.IsNullOrEmpty(sortOrder) ? "chiefname_desc" : "";
            CompanyNameSort = sortOrder == "CompanyName" ? "companyname_desc" : "CompanyName";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Supplier> suppliersIQ = from s in _context.Suppliers
                                               select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                suppliersIQ = suppliersIQ.Where(s => s.ChiefFullName.Contains(searchString));
            }

            suppliersIQ = sortOrder switch
            {
                "chiefname_desc" => suppliersIQ.OrderByDescending(s => s.ChiefFullName),
                "CompanyName" => suppliersIQ.OrderBy(s => s.CompanyName),
                "companyname_desc" => suppliersIQ.OrderByDescending(s => s.CompanyName),
                _ => suppliersIQ.OrderBy(s => s.ChiefFullName),
            };

            int pageSize = ConstantValues.pageSize;//КОНФИГУРАЦИЯ
            Suppliers = await PaginatedList<Supplier>.CreateAsync(suppliersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
