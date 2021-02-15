using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC_Core.Areas.Administor.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        [BindProperty]
        public RenameArticleCategory RenameArticleCategory { get; set; }

        public void OnGet(long id)
        {
            RenameArticleCategory = _articleCategoryApplication.Get(id);
        }

        public IActionResult OnPost()
        {
            _articleCategoryApplication.Rename(RenameArticleCategory);
            return RedirectToPage("./List");
        }
    }
}
