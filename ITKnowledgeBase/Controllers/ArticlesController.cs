
using ITKnowledgeBase.Data;
using ITKnowledgeBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class ArticlesController : Controller
{
    private readonly AppDbContext _context;

    public ArticlesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: ARTICLES
    public async Task<IActionResult> Index()
    {
        var articles = _context.Articles
                               .Include(a => a.Category);

        return View(await articles.ToListAsync());
    }
    // GET: ARTICLES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var article = await _context.Articles
            .Include(a => a.Category)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (article == null)
        {
            return NotFound();
        }

        return View(article);
    }

    // GET: ARTICLES/Create
    public IActionResult Create()
    {
        ViewData["CategoryId"] = new SelectList(
            _context.Categories,
            "Id",
            "Name");

        return View();
    }

    // POST: ARTICLES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Content,CreatedDate,CategoryId")] Article article)
    {
        ViewData["CategoryId"] = new SelectList(
    _context.Categories,
    "Id",
    "Name",
    article.CategoryId);
        if (ModelState.IsValid)
        {
            _context.Add(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(article);
    }

    // GET: ARTICLES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {

        if (id == null)
        {
            return NotFound();
        }

        var article = await _context.Articles.FindAsync(id);
        if (article == null)
        {
            return NotFound();
        }
        ViewData["CategoryId"] = new SelectList(
    _context.Categories,
    "Id",
    "Name",
    article.CategoryId);
        return View(article);
    }

    // POST: ARTICLES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,Content,CreatedDate,CategoryId")] Article article)
    {
        if (id != article.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {

            try
            {
                _context.Update(article);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(article.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(
    _context.Categories,
    "Id",
    "Name",
    article.CategoryId);
        return View(article);
    }

    // GET: ARTICLES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var article = await _context.Articles
    .Include(a => a.Category)
    .FirstOrDefaultAsync(m => m.Id == id);
        if (article == null)
        {
            return NotFound();
        }

        return View(article);
    }

    // POST: ARTICLES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var article = await _context.Articles.FindAsync(id);
        if (article != null)
        {
            _context.Articles.Remove(article);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ArticleExists(int? id)
    {
        return _context.Articles.Any(e => e.Id == id);
    }
}
