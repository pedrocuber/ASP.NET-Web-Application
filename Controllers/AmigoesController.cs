using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assessment.Data;
using Assessment.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Assessment.Controllers
{
    public class AmigoesController : Controller
    {
        private readonly AssessmentContext _context;

        public AmigoesController(AssessmentContext context)
        {
            _context = context;
        }

        // GET: Amigoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Amigo.ToListAsync());
        }

        // GET: Amigoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Amigo == null)
            {
                return NotFound();
            }

            var amigo = await _context.Amigo
                .FirstOrDefaultAsync(m => m.AmigoId == id);
            if (amigo == null)
            {
                return NotFound();
            }

            return View(amigo);
        }

        // GET: Amigoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amigoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmigoId,AmigoNome,AmigoSobrenome,AmigoTelefone,AmigoEmail,AniversarioAmigo,PaisAmigo,EstadoAmigo,ImagemAmigo")] Amigo amigo, IFormFile ImagemAmigo)
        {
            if (ModelState.IsValid)
            {
                amigo.ImagemAmigo=UploadImage(ImagemAmigo);
                _context.Add(amigo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            return View(amigo);
        }

        // GET: Amigoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Amigo == null)
            {
                return NotFound();
            }

            var amigo = await _context.Amigo.FindAsync(id);
            if (amigo == null)
            {
                return NotFound();
            }
            return View(amigo);
        }

        // POST: Amigoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AmigoId,AmigoNome,AmigoSobrenome,AmigoTelefone,AmigoEmail,AniversarioAmigo,PaisAmigo,EstadoAmigo,ImagemAmigo")] Amigo amigo)
        {
            if (id != amigo.AmigoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amigo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmigoExists(amigo.AmigoId))
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
            return View(amigo);
        }

        // GET: Amigoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Amigo == null)
            {
                return NotFound();
            }

            var amigo = await _context.Amigo
                .FirstOrDefaultAsync(m => m.AmigoId == id);
            if (amigo == null)
            {
                return NotFound();
            }

            return View(amigo);
        }

        // POST: Amigoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Amigo == null)
            {
                return Problem("Entity set 'AssessmentContext.Amigo'  is null.");
            }
            var amigo = await _context.Amigo.FindAsync(id);
            if (amigo != null)
            {
                _context.Amigo.Remove(amigo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private static string UploadImage(IFormFile imageFile) {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=cargalleryinfnetpc;AccountKey=72Adkm+pGR+6uxpgrvI0QOeT3LaXxAnAUaJaFeq/Uwb3iZdUsnFmVDUsRMtyIK/9xu0SceG4SCtn+ASthTnyIg==;EndpointSuffix=core.windows.net";
            string containerName = "images";
            var reader = imageFile.OpenReadStream();
            var cloundStorageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = cloundStorageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            container.CreateIfNotExistsAsync();
            CloudBlockBlob blob = container.GetBlockBlobReference(imageFile.FileName);
            Thread.Sleep(10000);
            blob.UploadFromStreamAsync(reader);
            return blob.Uri.ToString();

        }

        private bool AmigoExists(int id)
        {
          return _context.Amigo.Any(e => e.AmigoId == id);
        }
    }
}
