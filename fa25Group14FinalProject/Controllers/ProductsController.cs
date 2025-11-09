using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // Needed for MultiSelectList
using Microsoft.EntityFrameworkCore;
using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace fa25Group14FinalProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products - Accessible by everyone
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5 - Accessible by everyone
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Part Four, Step 9: Include Suppliers for Admin display on Details page
            var product = await _context.Products
                .Include(p => p.Suppliers)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")] // Part Three, Step 1: Only Admins can create
        public IActionResult Create()
        {
            // Part Four, Step 2: Populate the ViewBag with the MultiSelectList
            ViewBag.AllSuppliers = GetAllSuppliers();
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [Authorize(Roles = "Admin")] // Part Three, Step 1: Only Admins can create
        [ValidateAntiForgeryToken]
        // Part Four, Step 3: Add parameter for selected suppliers and relationship logic
        public async Task<IActionResult> Create([Bind("ProductId,Name,Description,Price,ProductType")] Product product, int[] SelectedSuppliers)
        {
            // Ensure the navigational property is initialized
            if (product.Suppliers == null)
            {
                product.Suppliers = new List<Supplier>();
            }

            // Find the suppliers the user selected and add them to the product's list
            if (SelectedSuppliers != null)
            {
                foreach (int supplierID in SelectedSuppliers)
                {
                    Supplier supplierToAdd = _context.Suppliers.Find(supplierID);
                    if (supplierToAdd != null)
                    {
                        product.Suppliers.Add(supplierToAdd);
                    }
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If model is NOT valid, re-populate the ViewBag before returning the view
            ViewBag.AllSuppliers = GetAllSuppliers();
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")] // Part Three, Step 1: Only Admins can edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Part Four, Step 4: Use Include to pull in current suppliers for pre-selection
            Product product = await _context.Products
                                        .Include(p => p.Suppliers)
                                        .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            // Get the list of IDs for the product's current suppliers
            List<int> currentSupplierIDs = product.Suppliers.Select(s => s.SupplierID).ToList();

            // Populate the ViewBag using the overloaded helper method to pre-select current suppliers
            ViewBag.AllSuppliers = GetAllSuppliers(currentSupplierIDs);

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")] // Part Three, Step 1: Only Admins can edit
        [ValidateAntiForgeryToken]
        // Part Four, Step 4: Add parameter for selected suppliers and relationship update logic
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Description,Price,ProductType")] Product product, int[] SelectedSuppliers)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            // 1. Fetch the product from the DB with its current suppliers (needed to manage relationships)
            Product productToUpdate = _context.Products
                                        .Include(p => p.Suppliers)
                                        .FirstOrDefault(p => p.ProductId == product.ProductId);

            if (productToUpdate == null) // Check if the product still exists
            {
                return NotFound();
            }

            // 2. Clear the existing suppliers to prepare for the update
            productToUpdate.Suppliers.Clear();

            // 3. Add the newly selected suppliers
            if (SelectedSuppliers != null)
            {
                foreach (int supplierID in SelectedSuppliers)
                {
                    Supplier supplierToAdd = _context.Suppliers.Find(supplierID);
                    productToUpdate.Suppliers.Add(supplierToAdd);
                }
            }

            // 4. Update scalar properties from the form data
            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Price = product.Price;
            productToUpdate.ProductType = product.ProductType;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productToUpdate); // Update the DB product, not the bound one
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productToUpdate.ProductId))
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

            // Re-populate ViewBag and model if validation fails
            ViewBag.AllSuppliers = GetAllSuppliers(productToUpdate.Suppliers.Select(s => s.SupplierID).ToList());
            return View(productToUpdate);
        }

        // Part Three, Step 5: DELETE ACTIONS ARE REMOVED
        /* The GET: Products/Delete/5 and POST: Products/Delete/5 action methods are removed entirely. */

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        // Private helper method (Overload 1): For Create - no items are pre-selected
        private MultiSelectList GetAllSuppliers()
        {
            return GetAllSuppliers(new List<int>());
        }

        // Private helper method (Overload 2): For Edit - pre-selects current suppliers
        private MultiSelectList GetAllSuppliers(List<int> selectedIDs)
        {
            // Get all suppliers from the database
            List<Supplier> suppliers = _context.Suppliers.OrderBy(s => s.SupplierName).ToList();

            // Create the MultiSelectList object, using the selectedIDs list to pre-select items
            MultiSelectList allSuppliers = new MultiSelectList(suppliers, "SupplierID", "SupplierName", selectedIDs);

            return allSuppliers;
        }
    }
}