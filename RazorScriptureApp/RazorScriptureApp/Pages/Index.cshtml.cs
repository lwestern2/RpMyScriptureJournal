using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorScriptureApp.Models;
using System.Web.Razor;
using PagedList.Mvc;


namespace RazorScriptureApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RazorScriptureApp.Models.RazorScriptureAppContext _context;

        public IndexModel(RazorScriptureApp.Models.RazorScriptureAppContext context)
        {
            _context = context;
        }

        
        public IList<Scripture> Note { get; set; }
        public string SearchString { get; set; }
        public string SearchString2 { get; set; }

        public SelectList Books { get; set; }
        public SelectList Notes { get; set; }
        public string ScriptureBook { get; set; }// contains the specific book the user selects (for example Nephi)
       
        public string scriptureNote { get; set; }
        public string BookSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Scripture> Scripture { get; set; }


        public async Task OnGetAsync(string searchString, string scriptureBook, string searchNote, string sortOrder, string currentFilter,int? pageIndex)
        {
            CurrentSort = sortOrder;
            BookSort = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "Book";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;



            IQueryable<string> bookQuery = from m in _context.Scripture
                                           
                                           select m.Book;



            var scriptures = from s in _context.Scripture
                             select s;
            switch (sortOrder)
            {

                case "Book":
                    scriptures = scriptures.OrderBy(s => s.Book);
                    break;

                case "book_desc":
                    scriptures = scriptures.OrderByDescending(s => s.Book);
                    break;
                case "Date":
                    scriptures = scriptures.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    scriptures = scriptures.OrderByDescending(s => s.Date);
                    break;
                default:
                    scriptures = scriptures.OrderBy(s => s.Book);
                    break;
            }

           

           

            if (!String.IsNullOrEmpty(searchString))
            {
                scriptures = scriptures.Where(s => s.Book.Contains(searchString) || s.Note.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(scriptureBook))
            {
                scriptures = scriptures.Where(x => x.Book == scriptureBook);
            }




            
            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            int pageSize = 5;
            Scripture = await PaginatedList<Scripture>.CreateAsync(scriptures.AsNoTracking(),pageIndex ?? 1,pageSize);
            
            SearchString = searchString;
           

        }



          


        }

        
    }

