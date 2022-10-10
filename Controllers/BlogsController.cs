using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using USFH.DTOs;
using USFH.Models;
using USFH.Repositories;

namespace USFH.Controllers
{
    [Route("[controller]")]
    public class BlogsController : Controller
    {
        private readonly IGeneralRepository _generalRepository;

        public BlogsController(IGeneralRepository generalRepository)
        {
            _generalRepository = generalRepository;
        }
        public async Task<IActionResult> Index(string search,int page=0)
        {
            page--;
            if (page < 0)
            {
                page = 0;
            }
            ViewData["NewBlogs"] = await _generalRepository.GetNewBlogs();
            ViewData["Search"] = search;
            ViewData["Settings"] = await _generalRepository.GetSettings();
            return View(await _generalRepository.GetBlogs(search, page));
        }

        [Route("details/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            ViewData["NewBlogs"] = await _generalRepository.GetNewBlogs();
            ViewData["Settings"] = await _generalRepository.GetSettings();
            return View(await _generalRepository.GetBlogBySlug(slug));
        }
    }
}
