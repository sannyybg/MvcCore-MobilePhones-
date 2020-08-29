using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobilePhones.Models;

namespace MobilePhones.Controllers
{
    public class MobilePhonesController : Controller
    {
        private readonly MobilePhoneContext _context;

        public MobilePhonesController(MobilePhoneContext context)
        {
            _context = context;
        }

        // GET: MobilePhones
        public async Task<IActionResult> Index()
        {

            ViewBag.MobilePhoneManufacturer = new SelectList(_context.MobilePhones, "MobilePhoneId", "Manufacturer", 1);
            return View(await _context.MobilePhones.ToListAsync());
        }

        // GET: MobilePhones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobilePhone = await _context.MobilePhones
                .FirstOrDefaultAsync(m => m.MobilePhoneId == id);
            if (mobilePhone == null)
            {
                return NotFound();
            }

            return View(mobilePhone);
        }

        // GET: MobilePhones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MobilePhones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MobilePhoneId,Name,Manufacturer,Price,Weight,Height,Width,HardDrive,Ram,OperatingSystem,Processor,PhotoUrl")] MobilePhone mobilePhone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobilePhone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mobilePhone);
        }

        // GET: MobilePhones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobilePhone = await _context.MobilePhones.FindAsync(id);
            if (mobilePhone == null)
            {
                return NotFound();
            }
            return View(mobilePhone);
        }

        // POST: MobilePhones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MobilePhoneId,Name,Manufacturer,Price,Weight,Height,Width,HardDrive,Ram,OperatingSystem,Processor,PhotoUrl")] MobilePhone mobilePhone)
        {
            if (id != mobilePhone.MobilePhoneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobilePhone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobilePhoneExists(mobilePhone.MobilePhoneId))
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
            return View(mobilePhone);
        }

        // GET: MobilePhones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobilePhone = await _context.MobilePhones
                .FirstOrDefaultAsync(m => m.MobilePhoneId == id);
            if (mobilePhone == null)
            {
                return NotFound();
            }

            return View(mobilePhone);
        }

        // POST: MobilePhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mobilePhone = await _context.MobilePhones.FindAsync(id);
            _context.MobilePhones.Remove(mobilePhone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobilePhoneExists(int id)
        {
            return _context.MobilePhones.Any(e => e.MobilePhoneId == id);
        }

        public async Task<IActionResult> Search(string parameter, string manufacturer, int minprice, int maxprice)
        {
            
            if (parameter == null)
            {
                parameter = "";
            }

            if (maxprice== 0)
            {
                maxprice = 20000;
            }
            
            
            var phones = _context.MobilePhones.Where(x=>x.Manufacturer == manufacturer && x.Name.ToLower().Contains(parameter.ToLower()) && x.Price < maxprice && x.Price > minprice);

            return View("Index", phones);

        }
    }
}
